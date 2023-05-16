namespace Blogg.Models
{
    public class Post
    {
       

      
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Data { get; set; }
        public int Number { get; set; }

        public Post(int id, string title, int number, string summary, string data)
        {
            Id = id;
            Title = title;
            Number = number;
            Summary = summary;
            Data = data;
        }

    }

}