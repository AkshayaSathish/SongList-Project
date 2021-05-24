using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using SongAPI.Models;


namespace SongAPI.Services
{
    public class SongService
    {
        string connectionString = "Data Source=.\\SQLExpress;Initial Catalog=MyProject;Integrated Security=True;";
        public Song GetSong(int songId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //
                // Open the SqlConnection.
                //
                con.Open();
                //
                // This code uses an SqlCommand based on the SqlConnection.
                //
                string sqlStmt = String.Format("Select SongId, Name, Genre, Instruments,Directors from Song Where SongId ={0}", songId);
                
                Console.WriteLine(sqlStmt);
               

                using (SqlCommand command = new SqlCommand(sqlStmt, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Song s = new Song();
                            s.SongId = reader.GetInt32(0);
                          //  s.SingerId = reader.GetInt32(1);
                            s.Name = reader.GetString(1);
                            s.Genre = reader.GetString(2);
                            s.Instruments = reader.GetString(3);
                            s.Directors = reader.GetString(4);
                            
                            Console.WriteLine(s.Name);
                            return s;
                        }
                    }
                }
                return null;
            }
        }

        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sqlStmt = String.Format("Select SongId, Name, Genre, Instruments, Directors from song");

                using (SqlCommand command = new SqlCommand(sqlStmt, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Song s = new Song();
                            s.SongId = reader.GetInt32(0);
                           // s.SingerId = reader.GetInt32(1);
                            s.Name = reader.GetString(1);
                            s.Genre = reader.GetString(2);
                            s.Instruments = reader.GetString(3);
                            s.Directors = reader.GetString(4);
                           



                            songs.Add(s);
                        }
                    }
                }
                return songs;
            }
        }

        public int InsertSong(Song newSong)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open Connection
                con.Open();

                // Get SQL Statement
                
                string sqlStmt = $"INSERT INTO [dbo].[song] ([Name],[Genre],[Instruments], [Directors]) OUTPUT INSERTED.SongId VALUES ('{newSong.Name}','{newSong.Genre}', '{newSong.Instruments}', '{newSong.Directors}')";

                Console.WriteLine(sqlStmt);

                // Execute Statement
                using (SqlCommand command = new SqlCommand(sqlStmt, con))
                {
                    int newSongId = (int) command.ExecuteScalar();
                   
                    return newSongId;
                }
            }
        }

        public int UpdateSong(Song updSong)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open Connection
                con.Open();

                // Get SQL Statement
                string sqlStmt = @$"UPDATE [dbo].[Song] SET
                    
                    Name = '{updSong.Name}',
                    Genre = '{updSong.Genre}',
                    Instruments = '{updSong.Instruments}',
                    Directors = '{updSong.Directors}'
                    
                    Where SongId = {updSong.SongId}";

                Console.WriteLine(sqlStmt);

                // Execute Statement
                using (SqlCommand command = new SqlCommand(sqlStmt, con))
                {
                    int numOfRows = command.ExecuteNonQuery();
                    return numOfRows;
                }
            }
        }

        public int DeleteSong(int songId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open Connection
                con.Open();

                // Get SQL Statement
                string sqlStmt = $"DELETE FROM [dbo].[Song] WHERE SongId = {songId}";

                Console.WriteLine(sqlStmt);

                // Execute Statement
                using (SqlCommand command = new SqlCommand(sqlStmt, con))
                {
                    int numOfRows = command.ExecuteNonQuery();
                    return numOfRows;
                }
            }
        }
    }
}