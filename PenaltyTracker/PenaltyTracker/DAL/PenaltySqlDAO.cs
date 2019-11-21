using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PenaltyTracker.Models;

namespace PenaltyTracker.DAL
{
    public class PenaltySqlDAO : IPenatlyDAO
    {
        private string connectionString;

        public PenaltySqlDAO(string connectionString)
        {
            this.connectionString = "Server =.\\SQLEXPRESS; Database = DerbyTracker; Trusted_Connection = True;";
        }

        public bool AddPenalty(int skaterNumber, string penaltyType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"INSERT INTO Penalty (PenaltyType, SkaterNumber) VALUES (@penaltyType, @skaterNumber)", connection);
                    command.Parameters.AddWithValue("@skaterNumber", skaterNumber);
                    command.Parameters.AddWithValue("@penaltyType", penaltyType);
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

        public IList<Penalty> ShowAllPenalties()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT penaltyId, penaltyType, skaterNumber FROM Penalty", connection);
                    command.ExecuteNonQuery();

                    SqlDataReader reader = command.ExecuteReader();
                    List<Penalty> penalties = new List<Penalty>();
                    while (reader.Read())
                    {
                        Penalty penalty = new Penalty();
                        penalty.PenaltyId = Convert.ToInt32(reader["PenaltyId"]);
                        penalty.PenaltyType = Convert.ToString(reader["PenaltyType"]);
                        penalty.SkaterNumber = Convert.ToInt32(reader["SkaterNumber"]);
                        penalties.Add(penalty);
                    }
                    return penalties;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public IList<Penalty> ShowPenalties(int skaterNumber)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"select * from Penalty WHERE SkaterNumber = @skaterNumber", connection);
                    command.Parameters.AddWithValue("@skaterNumber", skaterNumber);
                    command.ExecuteNonQuery();

                    SqlDataReader reader = command.ExecuteReader();
                    List<Penalty> penalties = new List<Penalty>();
                    while (reader.Read())
                    {
                        Penalty penalty = new Penalty();
                        penalty.PenaltyId = Convert.ToInt32(reader["PenaltyId"]);
                        penalty.PenaltyType = Convert.ToString(reader["PenaltyType"]);
                        penalty.SkaterNumber = Convert.ToInt32(reader["SkaterNumber"]);
                        penalties.Add(penalty);
                    }
                    return penalties;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public IList<Penalty> ShowTypePenalties(string penaltyType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM Penalty WHERE PenaltyType = @penaltyType", connection);
                    command.Parameters.AddWithValue("@penaltyType", penaltyType);
                    command.ExecuteNonQuery();

                    SqlDataReader reader = command.ExecuteReader();
                    List<Penalty> penalties = new List<Penalty>();
                    while (reader.Read())
                    {
                        Penalty penalty = new Penalty();
                        penalty.PenaltyId = Convert.ToInt32(reader["PenaltyId"]);
                        penalty.PenaltyType = Convert.ToString(reader["PenaltyType"]);
                        penalty.SkaterNumber = Convert.ToInt32(reader["SkaterNumber"]);
                        penalties.Add(penalty);
                    }
                    return penalties;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
