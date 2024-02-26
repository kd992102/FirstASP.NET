using System.Data.SqlClient;

namespace Test.Models
{
    public class DatabaseManager
    {
        private readonly string connectionString = "Server=DESKTOP-PVP9P76\\SQLEXPRESS;Database=Test1;Trusted_Connection=True;";

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

        public void NewData(Card card)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO First (Name,Age,Comment) VALUES (@Char_Name,@Num_Age,@Char_Comment)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@Char_Name", card.Char_Name));
            sqlCommand.Parameters.Add(new SqlParameter("@Num_Age", card.Num_Age));
            sqlCommand.Parameters.Add(new SqlParameter("@Char_Comment", card.Char_Comment));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
