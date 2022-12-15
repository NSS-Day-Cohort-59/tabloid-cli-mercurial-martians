using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class BackgroundManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        

        public BackgroundManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            
        }
        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Color Menu");
            Console.WriteLine(" 1) Background color");
            Console.WriteLine(" 2) Font Color");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            string lol = "lol";

            switch (choice)
            {
                case "1":
                   
                        
            }
            }
    }
}