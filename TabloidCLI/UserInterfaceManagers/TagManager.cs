using System;
using System.Collections.Generic;
using System.Linq;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class TagManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private TagRepository _tagRepository;
        private string _connectionString;

        // constructor
        public TagManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _tagRepository = new TagRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine();
            Console.WriteLine("Tag Menu »");
            Console.WriteLine(" 1) List Tags");
            Console.WriteLine(" 2) Add Tag");
            Console.WriteLine(" 3) Edit Tag");
            Console.WriteLine(" 4) Remove Tag");
            Console.WriteLine(" 0) Main Menu");

            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Add();
                    return this;
                case "3":
                    Edit();
                    return this;
                case "4":
                    Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid option, try again please!!");
                    return this;
            }
        }

        private void List()
        {
            List<Tag> tagList = _tagRepository.GetAll();

            Console.WriteLine();
            Console.WriteLine($"Tags");
            Console.WriteLine($"----------------------");

            foreach (Tag t in tagList)
            {
                Console.WriteLine($"#{t.Id}: {t.Name}");
            }
        }

        private void Add()
        {
            Console.WriteLine();
            Console.Write("Tag name: ");
            string name = Console.ReadLine();

            Tag tagNew = new Tag()
                     {
                         Name = name
                     };

            _tagRepository.Insert(tagNew);

            Console.WriteLine();
            Console.WriteLine($"{tagNew.Name} with ID of {tagNew.Id} has been added!!");
            Console.WriteLine("================================================");
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }

        private void Edit()
        {
            List<Tag> tagOptions = _tagRepository.GetAll();

            Console.WriteLine();
            Console.WriteLine($"Tags");
            Console.WriteLine($"----------------------");

            foreach (Tag t in tagOptions)
            {
                Console.WriteLine($"#{t.Id}: {t.Name}");
            }

            Console.Write("Select tag # you'd like to update:  ");
            int selectedTagId = int.Parse(Console.ReadLine());
            Tag selectedTag = tagOptions.FirstOrDefault(t => t.Id == selectedTagId);

            Console.Write("New Tag Name: ");
            selectedTag.Name = Console.ReadLine();
            Console.WriteLine();

            _tagRepository.Update(selectedTag);

            Console.WriteLine("Tag has been successfully updated!!");
            Console.WriteLine("=====================================");
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }

        private void Remove()
        {
            List<Tag> tagsAvailable = _tagRepository.GetAll();

            Console.WriteLine();
            Console.WriteLine($"Tags");
            Console.WriteLine($"----------------------");

            foreach (Tag t in tagsAvailable)
            {
                Console.WriteLine($"{t.Id}: {t.Name}");
            }

            Console.WriteLine();
            Console.Write("Select tag # you'd like to delete:  ");
            int tagIdSelected = int.Parse(Console.ReadLine());
            Console.WriteLine();

            _tagRepository.Delete(tagIdSelected);

            Console.WriteLine("Tag has been successfully been deleted!!");
            Console.WriteLine("==============================================");
            Console.Write("Press any key to continue");
            Console.ReadKey();

            //while (true)
            //    {
            //        try
            //        {

            //            Console.WriteLine();
            //            Console.Write("Select an option > ");

            //            string input = Console.ReadLine();
            //            int index = int.Parse(input) - 1;
            //            return options[index];
            //        }
            //        catch (Exception)
            //        {

            //            continue;
            //        }
            //    }

        }
    }
}
