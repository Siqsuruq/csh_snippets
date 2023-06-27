using Npgsql;
using NLog;
using Newtonsoft.Json;


namespace PGConfigLib
{
    public class PGConfig
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string connectionString = "Host=192.168.1.67;Port=5432;Database=flowsterconfig;Username=postgres;Password=123";

        public string LoadConfig(string srvc_name)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    //configData configData = new configData();
                    List<configData> configDataList = new List<configData>();

                    connection.Open();
                    string query = "SELECT * FROM " + srvc_name;
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                configData configData = new configData
                                {
                                    id = reader.GetInt64(0),
                                    uuid = reader.GetGuid(1),
                                    var = reader.GetString(2),
                                    val = reader.GetString(3)
                                };
                                configDataList.Add(configData);
                            }
                        }
                    }
                    connection.Close();
                    return JsonConvert.SerializeObject(configDataList, Formatting.Indented); ;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error occurred while loading config: " + ex.Message);
            }
            return null; // Or return an appropriate default value if desired
        }

        public void SaveConfig(string srvc_name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                // Extract the configuration data from your configuration object
                // Perform the necessary database query to save the configuration data back to the table
            }
        }

        private bool TableExists(string srvc_name)
        {
            NpgsqlConnection connection = null;

            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string query = "SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'public' AND table_name = @TableName)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", srvc_name);
                    bool exists = (bool)command.ExecuteScalar();
                    return exists;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error occurred while trying to check if config table exists: " + ex.Message);
                return false;
            }
            finally
            {
                connection?.Close();
            }
        }
    }
}