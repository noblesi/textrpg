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

        public static void TextAlignment(string text)
        {
            int Width = 94;

            int padding = Width - text.Length;
            int padLeft = padding / 2;
            int padRight = padding- padLeft;

            string CenterText = text.PadLeft(text.Length + padLeft).PadRight(text.Length + padRight);
            Console.WriteLine(CenterText);
        }

        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    bool parseSuccess = int.TryParse(input, out var ret);
                    if (!parseSuccess)
                    {
                        Console.SetCursorPosition(3, 30);
                        Console.WriteLine("숫자를 입력해주세요:                           ");
                        Console.SetCursorPosition(24, 30);
                        continue;
                    }
                    return ret;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
