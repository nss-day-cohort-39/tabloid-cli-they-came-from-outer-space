using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    public class NoteRepository : DatabaseConnector, IRepository<Note>
    {
        public NoteRepository(string connectionString) : base(connectionString) { }

        public List<Note> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT n.Id,
                                               n.Title,
                                               n.Content,
                                               n.CreateDateTime,
                                               p.Title AS PostTitle,
                                               p.URL
                                          FROM Note n
                                          LEFT JOIN Post p ON p.Id = n.PostId";


                    List<Note> notes = new List<Note>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Note note = new Note()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreationDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                            
                            Post = new Post()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("PostTitle")),
                                Url = reader.GetString(reader.GetOrdinal("URL")),
                            },
                        };
                        notes.Add(note);
                    }

                    reader.Close();

                    return notes;
                }
            }
        }

        public Note Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT n.Id,
                                               n.Title,
                                               n.Content,
                                               n.CreateDateTime
                                               p.Title AS PostTitle
                                               p.URL
                                          FROM Note n
                                          LEFT JOIN Post p ON p.Id = n.PostId
                                         WHERE n.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);


                    Note note = null;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        note = new Note()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreationDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                        };
                    }

                    reader.Close();

                    return note;
                }
            }
        }
        public void Insert(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Note (Title, Content, CreateDateTime, PostId )
                                                     VALUES (@title, @content, @createDateTime, @postId)";
                    cmd.Parameters.AddWithValue("@title", note.Title);
                    cmd.Parameters.AddWithValue("@content", note.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", note.CreationDateTime);
                    cmd.Parameters.AddWithValue("@postId", note.Post.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Note 
                                           SET Title = @title,
                                               Content = @content,
                                               CreateDateTime = @createDateTime,
                                               PostId = @postId
                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@title", note.Title);
                    cmd.Parameters.AddWithValue("@content", note.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", note.CreationDateTime);
                    cmd.Parameters.AddWithValue("@postId", note.Post.Id);
                    cmd.Parameters.AddWithValue("@id", note.Id);

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
                    cmd.CommandText = @"DELETE FROM Note WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
