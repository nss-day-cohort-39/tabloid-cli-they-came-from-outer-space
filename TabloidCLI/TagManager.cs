using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;

namespace TabloidCLI
{
    public class TagManager : DatabaseEntityManager, IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;

        public TagManager(IUserInterfaceManager parentUI, string connectionString) : base(connectionString)
        {
            _parentUI = parentUI;
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
            List<Tag> tags = GetAllTags();
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

            Insert(tag);
        }

        private void Edit()
        {
            Console.WriteLine("Which tag would you like to edit?");

            List<Tag> tags = GetAllTags();

            for (int i=0; i<tags.Count; i++)
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
                    Update(tagToEdit);
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

            List<Tag> tags = GetAllTags();

            for (int i=0; i<tags.Count; i++)
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
                Delete(tagToDelete.Id);
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection. Won't remove any tags.");
            }
        }

        private List<Tag> GetAllTags()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, Name FROM Tag"; 
                    List<Tag> tags = new List<Tag>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Tag tag = new Tag()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        };
                        tags.Add(tag);
                    }

                    reader.Close();

                    return tags;
                }
            }
        }

        private void Insert(Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Tag (Name) VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", tag.Name);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void Update(Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Tag SET Name = @name WHERE id = @id";
                    cmd.Parameters.AddWithValue("@name", tag.Name);
                    cmd.Parameters.AddWithValue("@id", tag.Id);

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
                    cmd.CommandText = @"DELETE FROM Tag WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
