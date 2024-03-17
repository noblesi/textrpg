using MiniProject.ItemData;
using System.Collections.Generic;

namespace MiniProject
{
    public class Player
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int spd { get; set; }
        public int SwordMastery { get; set; }
        public int SpearMastery { get; set; }
        public int AxeMastery { get; set; }
        public Dictionary<string, Item> Inventory { get; set; }
        public List<string> Type = new List<string> { "SWORD", "SPEAR", "AXE", "POTION" };
        public Player(string name)
        {
            this.name = name;
            SwordMastery = 0;
            SpearMastery = 0;
            AxeMastery = 0;
            Inventory = new Dictionary<string, Item>();
        }



        public void AddItem(Item item)
        {
            Inventory.Add(Type[item.Id - 1], item);
        }


        public void RemoveItem(Item item)
        {


        }


        public void GetStatus()
        {
            hp = 100;
            atk = 20;
            def = 10;
            spd = 5;
        }

        public static void DisplayUserStatus(Player player)
        {
            Console.WriteLine($"==={player.name}의 스탯===");
            Console.WriteLine($"HP : {player.hp}");
            Console.WriteLine($"ATK : {player.atk}");
            Console.WriteLine($"DEf : {player.def}");
            Console.WriteLine($"SPD : {player.spd}");
        }
    }
}
