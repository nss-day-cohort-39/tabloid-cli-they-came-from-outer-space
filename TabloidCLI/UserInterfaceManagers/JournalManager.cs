using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class JournalManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private JournalRepository _journalRepository;
        private string _connectionString;

        public JournalManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _journalRepository = new JournalRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine(" 1) List Journal Entries");
            Console.WriteLine(" 2) Add Journal Entry");
            Console.WriteLine(" 3) Edit Journal Entry");
            Console.WriteLine(" 4) Remove Journal Entry");
            Console.WriteLine(" 0) Go Back");

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
            List<Journal> journalEntries = _journalRepository.GetAll();
            foreach (Journal journalEntry in journalEntries)
            {
                Console.WriteLine(journalEntry);
            }
        }

        private Journal Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a Journal entry:";
            }

            Console.WriteLine(prompt);

            List<Journal> journalEntries = _journalRepository.GetAll();

            for (int i = 0; i < journalEntries.Count; i++)
            {
                Journal journalEntry = journalEntries[i];
                Console.WriteLine($" {i + 1}) {journalEntry.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return journalEntries[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
            {
                Console.WriteLine("New Journal Entry:");
                Journal journalEntry = new Journal();

                Console.Write("Title: ");
                journalEntry.Title = Console.ReadLine();

                Console.Write("Content: ");
                journalEntry.Content = Console.ReadLine();

                journalEntry.CreateDateTime = DateTime.Now;


                _journalRepository.Insert(journalEntry);
            }

            private void Edit()
            {
                Journal journalEntryToEdit = Choose("Which entry would you like to edit?");
                if (journalEntryToEdit == null)
                {
                    return;
                }

                Console.WriteLine();
                Console.Write("New Title (blank to leave unchanged: ");
                string title = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(title))
                {
                    journalEntryToEdit.Title = title;
                }
                Console.Write("New Content (blank to leave unchanged: ");
                string content = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    journalEntryToEdit.Content = content;
                }
                Console.Write("New Date Creation (blank to leave unchanged: ");
                string dateTime = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dateTime))
                {
                journalEntryToEdit.CreateDateTime = DateTime.Now;
                }

                _journalRepository.Update(journalEntryToEdit);
            }

        private void Remove()
        {
            Journal journalEntryToDelete = Choose("Which journal entry would you like to remove?");
            if (journalEntryToDelete != null)
            {
                _journalRepository.Delete(journalEntryToDelete.Id);
            }
        }

    }
}
