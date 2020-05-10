using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class NoteManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private NoteRepository _noteRepository;
        private PostRepository _postRepository;
        private int _postId;

        public NoteManager(IUserInterfaceManager parentUI, string connectionString, int postId)
        {
            _parentUI = parentUI;
            _noteRepository = new NoteRepository(connectionString);
            _postRepository = new PostRepository(connectionString);
            _postId = postId;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Note Menu");
            Console.WriteLine(" 1) List Notes");
            Console.WriteLine(" 2) Add Note");
            Console.WriteLine(" 3) Remove Note");
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

        private Note Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a note note:";
            }
            Console.WriteLine(prompt);

            List<Note> notes = _noteRepository.GetAll();
            for (int i = 0; i < notes.Count; i++)
            {
                Note note = notes[i];
                Console.WriteLine($" {i + 1}) {note.Title}");
            }

            Console.Write("> ");
            string input = Console.ReadLine();
            Note chosen = null;
            try
            {
                int choice = int.Parse(input);
                chosen = notes[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
            }

            return chosen;
        }
 
        private void List()
        {
            List<Note> notes = _noteRepository.GetByPost(_postId);
            foreach (Note note in notes)
            {
                Console.WriteLine(note);
            }
            Console.WriteLine();
        }

        private void Add()
        {
            Console.WriteLine("New Note");

            Note note = new Note();
            note.Post = _postRepository.Get(_postId);

            Console.Write("Title: ");
            note.Title = Console.ReadLine();

            Console.WriteLine("Content: ");
            note.Content = "";
            string content = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(content))
            {
                note.Content += content + "\n";
                content = Console.ReadLine();
            }

            note.CreateDateTime = DateTime.Now;

            _noteRepository.Insert(note);
        }

        private void Remove()
        {
            Note noteToDelete = Choose("Which note would you like to remove?");
            if (noteToDelete != null)
            {
                _noteRepository.Delete(noteToDelete.Id);
            }
        }
     }
}