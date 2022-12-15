using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;

namespace TabloidCLI.Repositories
{
    public class PostRepository : DatabaseConnector, IRepository<Post>
    {
        public PostRepository(string connectionString) : base(connectionString) { }

        public List<Post> GetAll()
        {
           using (SqlConnection connection = Connection) 
            { 
                connection.Open(); //this opens the connection to the SQL database
                using (SqlCommand command = connection.CreateCommand()) // <<--use teh command
                {
                    command.CommandText = "SELECT Id, Title, URL FROM Post"; //<<--this query ghets what you need from the Database
                    using (SqlDataReader reader = command.ExecuteReader()) //<--executes SQL and gets a reader that lets you access teh data
                    {
                        List<Post> allPosts = new List<Post>(); //new list of objects from database
                        while(reader.Read())
                        {
                            int idColumnPosition = reader.GetOrdinal("Id");
                            int idValue = reader.GetInt32(idColumnPosition);

                            // create title position varable, convert to string
                            int titleColumnPosition = reader.GetOrdinal("Title");
                            string titleValue = reader.GetString(titleColumnPosition);

                            // create URL position varable, convert to string
                            int urlColumnPosition = reader.GetOrdinal("URL");
                            string urlValue = reader.GetString(urlColumnPosition);

                            //assemble new post object for display
                            Post post = new Post
                            {
                                Id = idValue,
                                Title = titleValue,
                                Url = urlValue,
                            };
                            allPosts.Add(post);
                        }
                        reader.Close();

                        return allPosts;
                    }
                }
            }
        }

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetByAuthor(int authorId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT p.id,
                                               p.Title As PostTitle,
                                               p.URL AS PostUrl,
                                               p.PublishDateTime,
                                               p.AuthorId,
                                               p.BlogId,
                                               a.FirstName,
                                               a.LastName,
                                               a.Bio,
                                               b.Title AS BlogTitle,
                                               b.URL AS BlogUrl
                                          FROM Post p 
                                               LEFT JOIN Author a on p.AuthorId = a.Id
                                               LEFT JOIN Blog b on p.BlogId = b.Id 
                                         WHERE p.AuthorId = @authorId";
                    cmd.Parameters.AddWithValue("@authorId", authorId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Post> posts = new List<Post>();
                    while (reader.Read())
                    {
                        Post post = new Post()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("PostTitle")),
                            Url = reader.GetString(reader.GetOrdinal("PostUrl")),
                            PublishDateTime = reader.GetDateTime(reader.GetOrdinal("PublishDateTime")),
                            Author = new Author()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("AuthorId")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Bio = reader.GetString(reader.GetOrdinal("Bio")),
                            },
                            Blog = new Blog()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("BlogId")),
                                Title = reader.GetString(reader.GetOrdinal("BlogTitle")),
                                Url = reader.GetString(reader.GetOrdinal("BlogUrl")),
                            }
                        };
                        posts.Add(post);
                    }

                    reader.Close();

                    return posts;
                }
            }
        }

        public void Insert(Post post)
        {
            throw new NotImplementedException();
        }

        public void Update(Post post)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
