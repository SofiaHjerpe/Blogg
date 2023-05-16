using Blogg.Models;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blogg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var db = new SqlDatabase();
            var post = db.GetPosts();
            return View(post);
        }

        public IActionResult Details(int Id)
        {
            var db = new SqlDatabase();
            var post = db.GetPostById(Id);

            return View(post);

        }
        public IActionResult Create(int Id)
        {
            var db = new SqlDatabase();
            var posts = db.GetPostById(Id);

            return View(posts);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string title, string summary, int number, string data)
        {
            var db = new SqlDatabase();
            db.SavePost(title, summary, number, data);
            return Redirect("/Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}