using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;

namespace TabloidCLI
{
    public class JournalManager : DatabaseEntityManager, IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;

        public JournalManager(IUserInterfaceManager parentUI, string connectionString) : base(connectionString)
        {
            _parentUI = parentUI;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine(" 1) List Entries");
            Console.WriteLine(" 2) Add Entry");
            Console.WriteLine(" 3) Remove Entry");
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
            List<Journal> entries = GetAllJournalEntries();
            foreach (Journal entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        private void Add()
        {
            Console.WriteLine("New Journal Entry");

            Journal entry = new Journal();

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

            Insert(entry);
        }

        private void Remove()
        {
            Console.WriteLine("Which journal entry would you like to remove?");

            List<Journal> entries = GetAllJournalEntries();

            for (int i=0; i<entries.Count; i++)
            {
                Journal entry = entries[i];
                Console.WriteLine($" {i + 1}) {entry.Title}");
            }

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                Journal entryToDelete = entries[choice - 1];
                Delete(entryToDelete.Id);
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection. Won't remove any journal entries.");
            }
        }

        private List<Journal> GetAllJournalEntries()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                               Title,
                                               Content,
                                               CreateDatetime
                                          FROM Journal";

                    List<Journal> entries = new List<Journal>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Journal entry = new Journal()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                        };
                        entries.Add(entry);
                    }

                    reader.Close();

                    return entries;
                }
            }
        }

        private void Insert(Journal entry)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Journal (Title, Content, CreateDatetime )
                                                     VALUES (@title, @content, @createDateTime)";
                    cmd.Parameters.AddWithValue("@title", entry.Title);
                    cmd.Parameters.AddWithValue("@content", entry.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", entry.CreateDateTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Journal WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
