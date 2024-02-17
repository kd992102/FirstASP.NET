using System.Data.SqlClient;
using Test.Models;

namespace Test.Views
{
    public class DatabaseManager
    {
        private readonly string connectionString = "Server=WIN-HH6UT86MSMP;Database=Test1;Trusted_Connection=True;";

        public List<Card> GetData()
        {
            List<Card> cards = new List<Card>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM First");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Card card = new Card
                    {
                        Char_Name = reader.GetString(reader.GetOrdinal("Name")),
                        Num_Age = reader.GetInt32(reader.GetOrdinal("Age")),
                        Char_Comment = reader.GetString(reader.GetOrdinal("Comment")),
                    };
                    cards.Add(card);
                }
            }
            else
            {
                Console.Write("Database Empty!");
            }
            sqlConnection.Close();
            return cards;
        }
    }
}
