using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace MiniProject.Data
{
    public class JsonDataHandler
    {
        const string filepath = "C:\\Users\\KGA\\Desktop\\";
        const string InventoryData = "Inventory_data.json";
        const string PlayerData = "Player_data.json";

        public static void SavePlayerData(Player player, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(player, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"PlayerData saved to {PlayerData}");
            }
            catch(Exception ex )
            {
                Console.WriteLine($"Error saving player data : {ex.Message}");
            }
        }

        public static Player LoadPlayerData(string filePath)
        {
            Player player = null;
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    player = JsonConvert.DeserializeObject<Player>(json);
                    Console.WriteLine($"Player loaded from {PlayerData}");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
                return player;
            }
            catch( Exception ex )
            {
                Console.WriteLine($"Error loading player data : {ex.Message}");
                return null;
            }
            
        }

        public static void SaveInventoryData(Dictionary<int, Item> inventory, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(inventory, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Inventory saved to {InventoryData}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error saving inventory data : {ex.Message}");
            }
        }

        public static Dictionary<int, Item> LoadInventoryData(string filePath)
        {
            try
            {
                Dictionary<int, Item> inventory = new Dictionary<int, Item>();
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    inventory = JsonConvert.DeserializeObject<Dictionary<int, Item>>(json);
                    Console.WriteLine($"Inventory loaded from {InventoryData}");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
                return inventory;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading inventory data : {ex.Message}");
                return null;
            }
        }

        public static string GetPlayerDataPath()
        {
            return filepath + PlayerData;
        }

        public static string GetInventoryDataPath()
        {
            return filepath + InventoryData;
        }
    }
}
