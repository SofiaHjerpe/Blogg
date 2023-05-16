using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SqlDatabase
    {
        public List<Post> GetPosts()
        {
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = "SELECT * FROM Posts";


            var reader = cmd.ExecuteReader();
            var post = new List<Post>();
            while (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string title = reader["Title"].ToString();
                int number = int.Parse(reader["Number"].ToString());
                string summary = reader["Summary"].ToString();
                string data = reader["Data"].ToString();

                post.Add(new Post(id, title, number, summary, data));

            }
            return post;
        }
        public Post GetPostById(int Id)
        {

            string connection = "Data Source=localhost;Initial Catalog=Bloggdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);
            string query = "SELECT * FROM Posts WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", Id);

            conn.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string title = reader["Title"].ToString();
                string summary = reader["Summary"].ToString();
                int number = int.Parse(reader["Number"].ToString());
                string data = reader["Data"].ToString();
                return new Post(id, title, number, summary, data);
            }
            else
            {
                return null;
            }

        }
        public void SavePost(string title, string summary, int number, string data)
        {
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = $"INSERT INTO Posts (Title, Summary, Number, Data) VALUES ('{title}', '{summary}', {number}, '{data}')";
            cmd.ExecuteNonQuery();
        }
        private static SqlCommand GetDbCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Bloggdb;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
    }
    }

