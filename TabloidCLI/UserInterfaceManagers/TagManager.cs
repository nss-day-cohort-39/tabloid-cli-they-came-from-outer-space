using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class TagManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private TagRepository _tagRepository;

        public TagManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _tagRepository = new TagRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Tag Menu");
            Console.WriteLine(" 1) List Tags");
            Console.WriteLine(" 2) Add Tag");
            Console.WriteLine(" 3) Edit Tag");
            Console.WriteLine(" 4) Remove Tag");
            Console.WriteLine(" 0) Return to Main Menu");

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
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            Console.WriteLine();
            Console.WriteLine("All Tags");
            List<Tag> tags = _tagRepository.GetAll();
            foreach (Tag tag in tags)
            {
                Console.WriteLine(" " + tag);
            }
            Console.WriteLine();
        }

        private void Add()
        {
            Console.WriteLine("New Tag");

            Tag tag = new Tag();

            Console.Write("> ");
            tag.Name = Console.ReadLine();

            _tagRepository.Insert(tag);
        }

        private void Edit()
        {
            Console.WriteLine("Which tag would you like to edit?");

            List<Tag> tags = _tagRepository.GetAll();

            for (int i = 0; i < tags.Count; i++)
            {
                Tag tag = tags[i];
                Console.WriteLine($" {i + 1}) {tag.Name}");
            }

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                Tag tagToEdit = tags[choice - 1];

                Console.Write("New value (blank will keep original) ");
                string newValue = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newValue))
                {
                    tagToEdit.Name = newValue;
                    _tagRepository.Update(tagToEdit);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection. Won't edit any tags.");
            }
        }

        private void Remove()
        {
            Console.WriteLine("Which tag would you like to remove?");

            List<Tag> tags = _tagRepository.GetAll();

            for (int i = 0; i < tags.Count; i++)
            {
                Tag tag = tags[i];
                Console.WriteLine($" {i + 1}) {tag.Name}");
            }

            Console.WriteLine("> ");
            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                Tag tagToDelete = tags[choice - 1];
                _tagRepository.Delete(tagToDelete.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection. Won't remove any tags.");
            }
        }
    }
}
