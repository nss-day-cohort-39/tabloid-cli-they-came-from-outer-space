using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class JournalManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private JournalRepository _journalRepository;

        public JournalManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _journalRepository = new JournalRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine(" 1) List Entries");
            Console.WriteLine(" 2) Add Entry");
            Console.WriteLine(" 3) Edit Entry");
            Console.WriteLine(" 4) Remove Entry");
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

        private JournalEntry Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a journal entry:";
            }
            Console.WriteLine(prompt);

            List<JournalEntry> entries = _journalRepository.GetAll();
            for (int i = 0; i < entries.Count; i++)
            {
                JournalEntry entry = entries[i];
                Console.WriteLine($" {i + 1}) {entry.Title}");
            }

            Console.Write("> ");
            string input = Console.ReadLine();
            JournalEntry chosen = null;
            try
            {
                int choice = int.Parse(input);
                chosen = entries[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
            }

            return chosen;
        }
 
        private void List()
        {
            List<JournalEntry> entries = _journalRepository.GetAll();
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        private void Add()
        {
            Console.WriteLine("New Journal Entry");

            JournalEntry entry = new JournalEntry();

            Console.Write("Title: ");
            entry.Title = Console.ReadLine();

            Console.WriteLine("Content: ");
            entry.Content = "";
            string content = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(content))
            {
                entry.Content += content + "\n";
                content = Console.ReadLine();
            }

            entry.CreateDateTime = DateTime.Now;

            _journalRepository.Insert(entry);
        }

        private void Edit()
        {
            JournalEntry entryToEdit = Choose("Which journal entry would you like to edit?");
            if (entryToEdit == null)
            {
                return;
            }

            Console.WriteLine();
            Console.Write("New title (blank to leave unchanged): ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                entryToEdit.Title = title;
            }

            Console.WriteLine("New content (blank to leave unchanged): ");
            string content = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(content))
            {
                entryToEdit.Content = content;
            }

            _journalRepository.Update(entryToEdit);
        }

        private void Remove()
        {
            JournalEntry entryToDelete = Choose("Which journal entry would you like to remove?");
            if (entryToDelete != null)
            {
                _journalRepository.Delete(entryToDelete.Id);
            }
        }
    }
}
