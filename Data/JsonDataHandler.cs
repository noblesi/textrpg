using MiniProject.GameManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace MiniProject.Data
{
    public class JsonDataHandler
    {
        const string filepath = "C:\\Users\\KGA\\Desktop\\MiniProject\\Data\\";
        const string filename = "Inventory_data.json";

        public static void SaveInventoryData(Dictionary<string, Item> inventory, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(inventory, Formatting.Indented); ;
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Inventory saved to {filename}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error saving player data : {ex.Message}");
            }
        }

        public static Dictionary<string, Item> LoadInventoryData(string filePath)
        {
            try
            {
                Dictionary<string, Item> inventory = new Dictionary<string, Item>();
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    inventory = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
                    Console.WriteLine($"Inventory loaded from {filename}");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
                return inventory;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading player data : {ex.Message}");
                return null;
            }
        }

        public static string GetFilePath()
        {
            return filepath+filename;
        }
    }
}
