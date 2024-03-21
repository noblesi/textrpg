using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniProject
{
    public static class Utility
    {
        public static void WriteCenterPosition(string text)
        {
            int screenWidth = Console.WindowWidth;
            int centerX = (screenWidth - text.Length) / 2;

            Console.SetCursorPosition(centerX, Console.CursorTop);
            Console.WriteLine(text);
        }

        public static double GetRandomDoubleNumber()
        {
            RandomNumberGenerator.Create();
            var denominator = RandomNumberGenerator.GetInt32(2, int.MaxValue);
            double sDouble = (double)1 / denominator;
            return sDouble;
        }

        public static void LoadGameData()
        {
            string playerfileName = "PlayerData.json";
            string inventoryfileName = "InvenData.json";

            string userDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string playerfilePath = Path.Combine(userDocumentFolder, playerfileName);
            string inventoryfilePath = Path.Combine(userDocumentFolder, inventoryfileName);

            if (File.Exists(playerfilePath) && File.Exists(inventoryfilePath))
            {
                TextRPG.isCreate = true;

                string playerJson = File.ReadAllText(playerfilePath);
                string inventoryJson = File.ReadAllText(inventoryfilePath);

                playerJson = Regex.Unescape(playerJson);
                inventoryJson = Regex.Unescape(inventoryJson);

                Player loadedPlayer = JsonSerializer.Deserialize<Player>(playerJson);
                Dictionary<int, Item> loadedInventory = JsonSerializer.Deserialize<Dictionary<int, Item>>(inventoryJson);
                TextRPG.player = loadedPlayer;
                TextRPG.Inventory = loadedInventory;
            }
            else
            {
                Console.WriteLine("저장된 데이터가 없습니다.");
                Thread.Sleep(500);
                GameManager.Instance.StartGame();
            }
        }

        public static void SaveGameData()
        {
            string playerfileName = "PlayerData.json";
            string inventoryfileName = "InvenData.json";

            string userDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string playerfilePath = Path.Combine(userDocumentFolder, playerfileName);
            string inventoryfilePath = Path.Combine(userDocumentFolder, inventoryfileName);

            var options = new JsonSerializerOptions { WriteIndented = true };

            string playersData = JsonSerializer.Serialize(TextRPG.player, options);
            string invenData = JsonSerializer.Serialize(TextRPG.Inventory, options);

            playersData = Regex.Unescape(playersData);
            invenData = Regex.Unescape(invenData);

            File.WriteAllText(playerfilePath, playersData);
            File.WriteAllText(inventoryfilePath, invenData);
        }   

        public static void TextAlignment(string text)
        {
            int Width = 94;

            int padding = Width - text.Length;
            int padLeft = padding / 2;
            int padRight = padding- padLeft;

            string CenterText = text.PadLeft(text.Length + padLeft).PadRight(text.Length + padRight);
            Console.WriteLine(CenterText);
        }
    }
}
