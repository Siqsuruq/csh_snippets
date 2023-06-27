using System;
using System.Data.SQLite;

namespace ConfigService
{

    public class PersistantDataStorageEmulator
    {

        private readonly string? connectionString;

        public PersistantDataStorageEmulator()
        {
            connectionString = "Data Source=:memory:;Version=3;New=True;";
        }

        public void CreateAndQueryTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create a table
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE Customers (Id INTEGER PRIMARY KEY, Name TEXT)", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insert data
                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Customers (Id, Name) VALUES (1, 'John Doe')", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Query data
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Customers", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string name = Convert.ToString(reader["Name"]);
                            Console.WriteLine($"Id: {id}, Name: {name}");
                        }
                    }
                }
            }
        }
    }
}
