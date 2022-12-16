using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class BackgroundManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private string _connectionString;



        public BackgroundManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _connectionString = connectionString;
        }
        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Color Menu");
            Console.WriteLine(" 1) Background color");
            Console.WriteLine(" 2) Font Color");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            //Console.BackgroundColor = ConsoleColor.
            List<string> colors = new List<string>()
            {"Red", "Yellow", "Green", "Blue"};
            switch (choice)
            {
                case "1":
                    foreach (string color in colors)
                    {
                        Console.WriteLine($"{color}");
                    }
                    Console.WriteLine("What color would you like");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput == "red")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        
                    }
                    if (userInput == "yellow")
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    if (userInput == "green")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    if (userInput == "blue")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    return this;
                case "2":
                    foreach (string color in colors)
                    {
                        Console.WriteLine($"{color}");
                    }
                    Console.WriteLine("What color font would you like");
                    string fontUserInput = Console.ReadLine().ToLower();
                    if (fontUserInput == "red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                    }
                    if (fontUserInput == "yellow")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (fontUserInput == "green")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (fontUserInput == "blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    return this;
                case "0":
                    return _parentUI;
                    default: return this;



            }
        }
    }
}