using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PenaltyTracker.Models;

namespace PenaltyTracker.DAL
{
    class SkaterSqlDAO : ISkaterDAO
    {
        private string connectionString;

        public SkaterSqlDAO(string connectionString)
        {
            this.connectionString = "Server =.\\SQLEXPRESS; Database = DerbyTracker; Trusted_Connection = True;";
        }

        public int AddSkater(Skater newSkater)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"INSERT INTO skater(SkaterNumber, SkaterName) VALUES (@newSkaterNumber, @newSkaterName)", connection);
                    command.Parameters.AddWithValue("@newSkaterNumber", newSkater.Number);
                    command.Parameters.AddWithValue("@newSkaterName", newSkater.Name);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"SELECT SkaterNumber FROM skater WHERE SkaterNumber = {newSkater.Number}", connection);
                    Skater skater = new Skater();

                    int newSkaterAdded = Convert.ToInt32(command.ExecuteScalar());

                    return newSkaterAdded;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public bool RemoveSkater(int skaterNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM skater WHERE SkaterNumber = @skaterNumber", connection);
                    command.Parameters.AddWithValue("@skaterNumber", skaterNumber);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public IList<Skater> Search(int skaterNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM skater WHERE skaterNumber = {skaterNumber}", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Skater> skaters = new List<Skater>();
                    while (reader.Read())
                    {
                        Skater skater = new Skater();
                        skater.Number = Convert.ToInt32(reader["SkaterNumber"]);
                        skater.Name = Convert.ToString(reader["SkaterName"]);
                        skaters.Add(skater);
                    }
                    return skaters;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public IList<Skater> ShowSkaters()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM skater", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Skater> skaters = new List<Skater>();
                    while(reader.Read())
                    {
                        Skater skater = new Skater();
                        skater.Number = Convert.ToInt32(reader["SkaterNumber"]);
                        skater.Name = Convert.ToString(reader["SkaterName"]);
                        skaters.Add(skater);
                    }
                    return skaters;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

        }

        public bool UpdateSkater(Skater updatedSkater)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"UPDATE Skater SET SkaterName = @updatedSkaterName WHERE SkaterNumber = @skaterNumber", connection);
                    command.Parameters.AddWithValue("@updatedSkaterName", updatedSkater.Name);
                    command.Parameters.AddWithValue("@skaterNumber", updatedSkater.Number);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
