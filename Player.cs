using MiniProject.GameManager;
using MiniProject.ItemData;
using System.Collections.Generic;
using System.Numerics;

namespace MiniProject
{
    public class Player
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int spd { get; set; }
        public int gold {  get; set; }
        
        public Dictionary<int, Item> Inventory { get; set; } // 
        
        public Player(string name)
        {
            this.name = name;
            Inventory = new Dictionary<int, Item>();
            

            Item AncientSword = new Sword("고대의 검", 10, 0, 3, 0, 0);
            Item AncientSpear = new Spear("고대의 창", 15, 0, 0, 1, 1);
            Item AncientAxe = new Axe("고대의 도끼", 20, 0, -3, 2, 2);

            Inventory.Add(0, AncientSword);
            Inventory.Add(1, AncientSpear);
            Inventory.Add(2, AncientAxe);

            gold = 1000;
        }

        public void AddItem(Item item, int idx)
        {
            int id = item.Id;
            if (!Inventory.ContainsKey(id))
            {
                Inventory.Add(id, item);
            }
            else
            {
                Inventory[id].Quantity += idx;
            }
        }


        public void RemoveItem(Item item)
        {

        }
        public static void DisplayItemDetails(Player player)
        {
            int idx = 1;
            foreach (var item in player.Inventory)
            {
                Console.WriteLine($"{idx}. {item.Value.Name}");
                idx++;
            }
            Console.WriteLine("아이템을 선택하세요.");
            int SelectIdx = int.Parse(Console.ReadLine());
            Item SelectedItem = player.Inventory[SelectIdx-1];

            Console.WriteLine($"{SelectedItem.Name}의 상세정보");
            Console.WriteLine($"공격력 증가량 : {SelectedItem.AddAtk}");
            Console.WriteLine($"방어력 증가량 : {SelectedItem.AddDef}");
            Console.WriteLine($"속도 증가량 : {SelectedItem.AddSpd}");

            Console.ReadLine();
            Console.Clear();
            DisplayUserInventory(player);
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

            Thread.Sleep(1000);

            SelectStatusMenu(player);
        }

        public static void DisplayUserInventory(Player player)
        {
            Console.WriteLine($"==={player.name}의 인벤토리===");

            Console.WriteLine($"현재 소지금 : {player.gold}");

            foreach(var item in player.Inventory)
            {
                Console.WriteLine($"이름 : {item.Value.Name} " +
                    $"\n= 갯수 : {item.Value.Quantity}");
                Console.WriteLine("\n");
            }

            Thread.Sleep(1000);

            SelectInventoryMenu(player);
        }

        public static void SelectInventoryMenu(Player player)
        {
            Console.WriteLine("1. 상세정보 확인\t2. 스테이터스 확인\t3. 뒤로가기");

            int MenuSelectIdx = int.Parse(Console.ReadLine());

            switch (MenuSelectIdx)
            {
                case 1:
                    Console.Clear();
                    DisplayItemDetails(player);
                    break;
                case 2:
                    Console.Clear();
                    DisplayUserStatus(player);
                    break;
                case 3:
                    Console.Clear();
                    GamePlay.SelectPlay();
                    break;
            }
        }

        public static void SelectStatusMenu(Player player)
        {
            Console.WriteLine($"1. 인벤토리 열기\t2. 뒤로가기");

            int MenuSelectIdx = int.Parse (Console.ReadLine());

            switch (MenuSelectIdx)
            {
                case 1:
                    Console.Clear();
                    DisplayUserInventory(player);
                    break;
                case 2:
                    Console.Clear();
                    GamePlay.SelectPlay();
                    break;
            }
        }
    }
}
