using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class AuthorManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private AuthorRepository _authorRepository;

        public AuthorManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _authorRepository = new AuthorRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Author Menu");
            Console.WriteLine(" 1) List Authors");
            Console.WriteLine(" 2) Add Author");
            Console.WriteLine(" 3) Remove Author");
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
            List<Author> authors = _authorRepository.GetAll();
            foreach (Author author in authors)
            {
                Console.WriteLine(author);
            }
        }

        private void Add()
        {
            Console.WriteLine("New Author");
            Author author = new Author();

            Console.Write("First Name: ");
            author.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            author.LastName = Console.ReadLine();

            Console.Write("Bio: ");
            author.Bio = Console.ReadLine();

            _authorRepository.Insert(author);
        }

        private void Remove()
        {
            Console.WriteLine("Which author would you like to remove?");

            List<Author> authors = _authorRepository.GetAll();

            for (int i = 0; i < authors.Count; i++)
            {
                Author author = authors[i];
                Console.WriteLine($" {i + 1}) {author.FullName}");
            }

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                Author authorToDelete = authors[choice - 1];
                _authorRepository.Delete(authorToDelete.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection. Won't remove any author authors.");
            }
        }
    }
}
