using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    public class AuthorRepository : DatabaseConnector, IRepository<Author>
    {
        public AuthorRepository(string connectionString) : base(connectionString) { }

        public List<Author> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                               FirstName,
                                               LastName,
                                               Bio
                                          FROM Author";

                    List<Author> authors = new List<Author>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Author author = new Author()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Bio = reader.GetString(reader.GetOrdinal("Bio")),
                        };
                        authors.Add(author);
                    }

                    reader.Close();

                    return authors;
                }
            }
        }

        public void Insert(Author author)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Author (FirstName, LastName, Bio )
                                                     VALUES (@firstName, @lastName, @bio)";
                    cmd.Parameters.AddWithValue("@firstName", author.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", author.LastName);
                    cmd.Parameters.AddWithValue("@bio", author.Bio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Author WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
