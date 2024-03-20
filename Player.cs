using MiniProject.GameManager;
using System.Collections.Generic;
using System.Numerics;

namespace MiniProject
{
    public class Player
    {
        public string name { get; set; }
        public static int P_maxhp { get; private set; }
        public static int P_curhp {  get; set; }
        public static int P_totalatk { get; private set; }
        public static int P_baseatk {  get; set; }
        public static int P_totaldef {  get; private set; }
        public static int P_basedef { get; set; }
        public static int P_totalspd {  get; private set; }
        public static int P_basespd { get; set; }
        public static bool isBuffed { get; set; }
        public static int gold {  get; set; }
        public static Item EquippedItem { get; set; }
        public static Dictionary<int, Item> Inventory { get; set; } // 
        
        public Player(string name)
        {
            this.name = name;
            Inventory = new Dictionary<int, Item>();
            
            Item AncientSword = new Sword("고대의 검", 0, 0, "유저와 함께 성장하는 성장형 검입니다.", 10, 0, 3);
            Item AncientSpear = new Spear("고대의 창", 1, 1, "유저와 함께 성장하는 성장형 창입니다.", 15, 0, 0);
            Item AncientAxe = new Axe("고대의 도끼", 2, 2, "유저와 함께 성장하는 성장형 도끼입니다.", 20, 0, -3);

            Inventory.Add(0, AncientSword);
            Inventory.Add(1, AncientSpear);
            Inventory.Add(2, AncientAxe);

            gold = 1000;
        }

        public static void SetRandomStatus()
        {
            Random random = new Random();

            P_maxhp = random.Next(50, 151);
            P_curhp = P_maxhp;
            P_baseatk = random.Next(15, 26);
            P_totalatk = P_baseatk;
            P_basedef = random.Next(5, 16);
            P_totaldef = P_basedef;
            P_basespd = random.Next(3, 8);
            P_totalspd = P_basespd;
        }

        public static void SetFixedStatus()
        {
            P_curhp = 100;
            P_maxhp = P_curhp;
            P_baseatk = 20;
            P_totalatk = P_baseatk;
            P_basedef = 10;
            P_totaldef = P_basedef;
            P_basespd = 5;
            P_totalspd = P_basespd;
        }

        public void Attack(Monster monster)
        {
            int DamageToMonster;

            if(monster.M_def >= P_totalatk)
            {
                DamageToMonster = 0;
                Console.WriteLine($"데미지를 {DamageToMonster}만큼 입혔습니다.");
            }
            else
            {
                DamageToMonster = P_baseatk - monster.M_def;
                monster.M_hp -= DamageToMonster;
                Console.WriteLine($"데미지를 {DamageToMonster}만큼 입혔습니다.");
            }
        }

        public static void AddItem(Item item, int idx)
        {
            int id = item.Id;
            if (!Inventory.ContainsKey(id))
            {
                Inventory.Add(id, item);
                item.Quantity = idx;
            }
            else
            {
                Inventory[id].Quantity += idx;
            }
        }

        public void GetStatus()
        {
            P_curhp = 100;
            P_maxhp = P_curhp;
            P_baseatk = 20;
            P_totalatk = P_baseatk;
            P_basedef = 10;
            P_totaldef = P_basedef;
            P_basespd = 5;
            P_totalspd = P_basespd;
        }

        public static void DisplayUserStatus(Player player)
        {
            Console.WriteLine($"==={player.name}의 스탯===");
            Console.WriteLine($"HP : {P_curhp}/{P_maxhp}");
            Console.WriteLine($"ATK : {P_totalatk}");
            Console.WriteLine($"DEf : {P_totaldef}");
            Console.WriteLine($"SPD : {P_totalspd}");

            Thread.Sleep(1000);

            SelectStatusMenu(player);
        }

        public static void DisplayUserInventory(Player player)
        {
            Console.WriteLine($"==={player.name}의 인벤토리===");

            Console.WriteLine($"현재 소지금 : {gold}");

            Console.WriteLine("===================");

            foreach(var item in Inventory)
            {
                Console.WriteLine($"이름 : {item.Value.Name} " +
                    $"\n= 설명 : {item.Value.Description}");
                Console.WriteLine("\n");
            }

            Thread.Sleep(1000);

            SelectInventoryMenu(player);
        }

        public static void EquipWeapon(Player player)
        {
            Console.WriteLine("장착할 무기를 선택하세요.(0 : 고대의 검 1 : 고대의 창 2. 고대의 도끼)");
            int SelectedWeapon = int.Parse(Console.ReadLine());

            if (EquippedItem != null)
            {
                Console.WriteLine($"{Inventory[SelectedWeapon].Name} 장착실패");
                Console.WriteLine("이미 무기를 장착하고있습니다.");
                Console.WriteLine("무기를 교체하시겠습니까?");
                Console.WriteLine("1. 예 / 2. 아니오");
                int choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    Console.WriteLine("무기를 교체합니다.");
                    EquippedItem = Inventory[SelectedWeapon];
                }
                else
                {
                    Console.WriteLine("무기 교체를 취소합니다.");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"{Inventory[SelectedWeapon].Name} 장착성공!");
            }

            EquippedItem = Inventory[SelectedWeapon];

            if(EquippedItem is Sword sword)
            {
                P_totalatk = P_baseatk + sword.ATK;
                P_totaldef = P_basedef + sword.DEF;
                P_totalspd = P_basedef + sword.SPD;
            }
            else if(EquippedItem is Spear spear)
            {
                P_totalatk = P_baseatk + spear.ATK;
                P_totaldef = P_basedef + spear.DEF;
                P_totalspd = P_basespd + spear.SPD;
            }
            else if(EquippedItem is Axe axe)
            {
                P_totalatk = P_baseatk + axe.ATK;
                P_totaldef = P_basedef + axe.DEF;
                P_totalspd = P_basespd + axe.SPD;
            }
            

            Thread.Sleep(2000);

            Console.Clear();

            GamePlay.SelectPlay();
        }

        public void ItemUseInBattle()
        {
            Console.WriteLine("===사용 가능한 아이템 목록===");

            foreach(var item in Inventory)
            {
                if(item.Key >= 3 && item.Key <= 10)
                {
                    Console.WriteLine($"{item.Key}. {item.Value.Name} || {item.Value.Quantity} || {item.Value.Description}");
                }
            }

            Console.WriteLine("아이템 선택 : (취소 : -1)");
            int UsedItemIdx = int.Parse(Console.ReadLine());

            if(UsedItemIdx == -1)
            {
                return;
            }

            Console.WriteLine($"{Inventory[UsedItemIdx].Name}을(를) 사용합니다.");

            switch(Inventory[UsedItemIdx]._type)
            {
                case 3:
                    Potion.Healing(UsedItemIdx);
                    Inventory[UsedItemIdx].Quantity--;
                    break;
                case 4:
                    Potion.Buff(UsedItemIdx);
                    Inventory[UsedItemIdx].Quantity--;
                    break;
                case 5:
                    Scroll.Escape(UsedItemIdx);
                    Inventory[UsedItemIdx].Quantity--;
                    break;
            }
        }

        public static void SelectInventoryMenu(Player player)
        {
            Console.WriteLine("1. 장비착용\t2. 스테이터스 확인\t3. 뒤로가기");

            int MenuSelectIdx = int.Parse(Console.ReadLine());

            switch (MenuSelectIdx)
            {
                case 1:
                    Console.Clear();
                    EquipWeapon(player);
                    //DisplayItemDetails(player);
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
