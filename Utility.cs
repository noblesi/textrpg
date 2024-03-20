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
            string fileName = "PlayerData.json";
            string userDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            string filePath = Path.Combine(userDocumentFolder, fileName);

            if(File.Exists(filePath))
            {
                TextRPG.isCreate = true;
                string playerJson = File.ReadAllText(filePath);
                playerJson = Regex.Unescape(playerJson);
                Player loadedPlayer = JsonSerializer.Deserialize<Player>(playerJson);
                TextRPG.player = loadedPlayer;
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

        }
    }
}
