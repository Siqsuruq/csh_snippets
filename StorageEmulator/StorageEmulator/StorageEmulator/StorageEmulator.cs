using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace StorageEmulator
{
    internal class StorageEmulator
    {
        private string filePath = "EmulatorData.json";
        private Dictionary<string, object> jsonData;

        public void JsonReadWrite(string filePath)
        {
            this.filePath = filePath;
            jsonData = ReadJsonData();
        }

        public void WriteToJson(string key, object value)
        {
            // Update or add the specified key-value pair
            jsonData[key] = value;

            // Serialize the updated JSON data
            string jsonString = JsonSerializer.Serialize(jsonData);

            // Write the JSON string back to the file
            File.WriteAllText(filePath, jsonString);
        }

        public object ReadFromJson(string key)
        {
            // Retrieve the value for the specified key
            if (jsonData.ContainsKey(key))
            {
                return jsonData[key];
            }

            // Key not found
            return null;
        }

        private Dictionary<string, object> ReadJsonData()
        {
            try
            {
                // Read the entire JSON file as a string
                string jsonString = File.ReadAllText(filePath);

                // Deserialize the JSON string into a dictionary
                return JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file could not be found.");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
            catch (JsonException e)
            {
                Console.WriteLine("An error occurred while parsing the JSON: " + e.Message);
            }

            return new Dictionary<string, object>();
        }
    }
}
