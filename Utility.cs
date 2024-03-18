using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MiniProject.ItemData;

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
    }
}
