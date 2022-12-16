using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class PostManager : IUserInterfaceManager 
    {
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private AuthorRepository _authorRepository;
        private string _connectionstring;

        public PostManager(IUserInterfaceManager parentUI, string connectionstring)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionstring);
            _connectionstring = connectionstring;
        }

        public IUserInterfaceManager Execute()
        {
            // this is where you'll add teh new menu list option. you'll need a GetAll() sort of thing)
            List<Post> posts = _postRepository.GetAll(); // build out teh post list before user selections
            List<Author> authorList = _authorRepository.GetAll(); // figur eout how to builf teh list of authors
            
            // this has to come from Ryan's Blog code, commenting for now
            //List<Blog> blogList = _BlogRepository.GetAll(); 
           
            Console.WriteLine("**Post Management Menu**");
            Console.WriteLine("Choose an option number from this menu: ");
            Console.WriteLine();
            Console.WriteLine("1: List All Posts");
            Console.WriteLine("2: Add A New Post");
            Console.WriteLine();
            Console.Write("Enter your choice number here:");
            int postMenuChoice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (postMenuChoice == 1)
            {
                foreach (Post post in posts)
                {

                    Console.WriteLine($"The post '{post.Title}' is located at URL: {post.Url}!");

                }
                Console.WriteLine();
                Console.Write("enter any key to continue");
                Console.ReadKey();
                return _parentUI; // definitely try to remember that you need a return for a Method

            }
            else if (postMenuChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a Title for your post:");
                string newPostTitle = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Thank you! Next, please enter a URL for your post:");
                string newPostURL = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Thank you! a Publish Date & time has been set for you to right this instant");



                // author list & choice:
                Console.WriteLine();
                Console.WriteLine("Next, Please choose an author from the list provided");
                Console.WriteLine();
                Console.WriteLine("**Author List**");
                Console.WriteLine("-------------");
                foreach (Author author in authorList)
                {

                    Console.WriteLine($"Option #{author.Id} is {author.FirstName} {author.LastName}");
                }

                int postAuthorIdChoice = int.Parse(Console.ReadLine());
                //this should capture and parse the input

                // blog list & choice:
                //! uncomment this when you merge Ryan's blog work to found his blog repository and his GetAll() method
                /*
                Console.WriteLine();
                Console.WriteLine("Thank you! Next, Please choose a Blog from the list provided");
                foreach (Blog blog in blogList)
                {
                    Console.WriteLine();
                    Console.WriteLine("**Blog List**");
                    Console.WriteLine("-------------");
                    Console.WriteLine($"Option #{blog.Id}");
                }
                int postBlogIdChoice = int.Parse(Console.ReadLine());

                return null;
            }   */

                //build teh object that is gonna be inserted:

                /*
                Post postToAdd = new Post()
                {
                    Title = newPostTitle,
                    Url = newPostURL,
                    PublishDateTime = DateTime.Now,
                    AuthorId = postAuthorIdChoice,



                };

                posts.Insert()
                */  return _parentUI;

            }
            
            else
            {
                Console.WriteLine("invalid choice. please make another selection");
                return new PostManager(_parentUI, _connectionstring);
            }
            
        }
    }
}
