using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class AuthorDetailManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private AuthorRepository _authorRepository;
        private TagRepository _tagRepository;
        private int _authorId;

        public AuthorDetailManager(IUserInterfaceManager parentUI, string connectionString, int authorId)
        {
            _parentUI = parentUI;
            _authorRepository = new AuthorRepository(connectionString);
            _tagRepository = new TagRepository(connectionString);
            _authorId = authorId;
        }

        public IUserInterfaceManager Execute()
        {
            Author author = _authorRepository.Get(_authorId);
            Console.WriteLine($"{author.FullName} Details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 2) Add Tag");
            Console.WriteLine(" 3) Remove Tag");
            Console.WriteLine(" 0) Return");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View();
                    return this;
                case "2":
                    AddTag();
                    return this;
                case "3":
                    RemoveTag();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void View()
        {
            Author author = _authorRepository.Get(_authorId);
            Console.WriteLine($"Name: {author.FullName}");
            Console.WriteLine($"Bio: {author.Bio}");
            Console.WriteLine("Tags:");
            foreach (Tag tag in author.Tags)
            {
                Console.WriteLine(" " + tag);
            }
        }

        private void AddTag()
        {
            Author author = _authorRepository.Get(_authorId);

            Console.WriteLine($"Which tag would you like to add to {author.FullName}?");
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
                Tag tag = tags[choice - 1];
                _authorRepository.InsertTag(author, tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection. Won't add any tags.");
            }
        }

        private void RemoveTag()
        {
            Author author = _authorRepository.Get(_authorId);

            Console.WriteLine($"Which tag would you like to remove from {author.FullName}?");
            List<Tag> tags = author.Tags;

            for (int i = 0; i < tags.Count; i++)
            {
                Tag tag = tags[i];
                Console.WriteLine($" {i + 1}) {tag.Name}");
            }

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                Tag tag = tags[choice - 1];
                _authorRepository.DeleteTag(author.Id, tag.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection. Won't remove any tags.");
            }
        }
     }
}