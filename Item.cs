using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }        
        public int _type { get; set; }

        public List<string> Type = new List<string> { "Sword", "Spear", "Axe", "Healing", "Scroll" };

        public Item()
        {

        }

        public Item(string name, int value, string description, int type, int id)
        {
            Name = name;
            Value = value;
            Description = description;
            Id = id;
            _type = type;
        }

        public Item(string name, int type, int id, string description)
        {
            Name = name;
            Id = id;
            Description = description;
            _type = type;
        }
    }

    public class Sword : Item
    {
        public int ATK {  get; set; }
        public int DEF {  get; set; }
        public int SPD {  get; set; }

        public Sword(string name, int type, int id, string description, int atk, int def, int spd) : base(name, type, id, description)
        {
            ATK = atk;
            DEF = def;
            SPD = spd;
            Quantity = 1;
        }
    }

    public class Axe : Item
    {
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }

        public Axe(string name, int type, int id, string description, int atk, int def, int spd) : base(name, type, id, description)
        {
            ATK = atk;
            DEF = def;
            SPD = spd;
            Quantity = 1;
        }
    }

    public class Spear : Item
    {
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }

        public Spear(string name, int type, int id, string description, int atk, int def, int spd) : base(name, type, id, description)
        {
            ATK = atk;
            DEF = def;
            SPD = spd;
            Quantity = 1;
        }
    }

    public class Potion : Item
    {
        public Potion(string name, int value, string description, int type, int id) : base(name, value, description, type, id)
        {

        }

        public static void Healing(int idx)
        {
            Item healingpotion = Player.Inventory[idx];

            switch (healingpotion.Id)
            {
                case 3:
                    TextRPG.player.CurrentHp = Math.Min(TextRPG.player.CurrentHp + 20, TextRPG.player.Hp);
                    Console.SetCursorPosition(50, 7);
                    Console.WriteLine("체력 20회복");
                    break;
                case 4:
                    TextRPG.player.CurrentHp = Math.Min(TextRPG.player.CurrentHp + 40, TextRPG.player.Hp);
                    Console.SetCursorPosition(50, 7);
                    Console.WriteLine("체력 40회복");
                    break;
                case 5:
                    TextRPG.player.CurrentHp = Math.Min(TextRPG.player.CurrentHp + 80, TextRPG.player.Hp);
                    Console.SetCursorPosition(50, 7);
                    Console.WriteLine("체력 80회복");
                    break;
            }
        }
    }

    public class Scroll : Item
    {
        public Scroll(string name, int value, string description, int type, int id) : base(name, value, description, type, id)
        {

        }

        public static void Escape(int idx)
        {
            Console.SetCursorPosition(1, 30);
            Utility.TextAlignment("강제로 전투에서 탈출하여 마을로 돌아갑니다.");

            Thread.Sleep(3000);

            GameManager.Instance.DisplayHome();
        }
    }
}
