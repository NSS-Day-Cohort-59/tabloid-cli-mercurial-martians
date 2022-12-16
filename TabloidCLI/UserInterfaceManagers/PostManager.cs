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
        private string _connectionstring;

        public PostManager(IUserInterfaceManager parentUI, string connectionstring)
        {
            _parentUI = parentUI;
            _postRepository= new PostRepository(connectionstring);
            _connectionstring = connectionstring;
        }

        public IUserInterfaceManager Execute()
        {
            // this is where you'll add teh new menu list option. you'll need a GetAll() sort of thing)
            List<Post> posts = _postRepository.GetAll(); // build out teh post list before user selections
            Console.WriteLine("**Post Management Menu**");
            Console.WriteLine("Choose an option number from this menu: ");
            Console.WriteLine();
            Console.WriteLine("1: List All Posts");
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
                
            } else 
                {
                 Console.WriteLine("invalid choice. please make another selection");
                return new PostManager(_parentUI, _connectionstring);
                }
            
        }
    }
}
