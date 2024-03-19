using MiniProject.GameManager;
using MiniProject.ItemData;
using System.Collections.Generic;
using System.Numerics;

namespace MiniProject
{
    public class Player
    {
        public string name { get; set; }
        public static int P_maxhp { get; set; }
        public static int P_curhp {  get; set; }
        public static int P_atk { get; set; }
        public static int P_curatk {  get; set; }
        public static int P_def { get; set; }
        public static int P_spd { get; set; }
        public static bool isBuffed { get; set; }
        public static int gold {  get; set; }

        public static Dictionary<int, Item> Inventory { get; set; } // 
        
        public Player(string name)
        {
            this.name = name;
            Inventory = new Dictionary<int, Item>();
            

            Item AncientSword = new Sword("고대의 검", 10, 0, 3, 0, 0, "유저와 함께 성장하는 성장형 검입니다.");
            Item AncientSpear = new Spear("고대의 창", 15, 0, 0, 1, 1, "유저와 함께 성장하는 성장형 창입니다.");
            Item AncientAxe = new Axe("고대의 도끼", 20, 0, -3, 2, 2, "유저와 함께 성장하는 성장형 도끼입니다.");

            Inventory.Add(0, AncientSword);
            Inventory.Add(1, AncientSpear);
            Inventory.Add(2, AncientAxe);

            gold = 1000;
        }

        public void Attack(Monster monster)
        {
            int DamageToMonster;

            if(monster.M_def >= Player.P_atk)
            {
                DamageToMonster = 0;
                Console.WriteLine($"데미지를 {DamageToMonster}만큼 입혔습니다.");
            }
            else
            {
                DamageToMonster = Player.P_atk - monster.M_def;
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

        //public static void DisplayItemDetails(Player player)
        //{
        //    foreach (var item in Inventory)
        //    {
        //        Console.WriteLine($"{item.Value.Id}. {item.Value.Name}");
        //    }
        //    Console.WriteLine("아이템을 선택하세요.");
        //    int SelectIdx = int.Parse(Console.ReadLine());
        //    Item SelectedItem = Inventory[SelectIdx-1];

        //    Console.WriteLine($"{SelectedItem.Name}의 상세정보");
        //    Console.WriteLine($"공격력 증가량 : {SelectedItem.AddAtk}");
        //    Console.WriteLine($"방어력 증가량 : {SelectedItem.AddDef}");
        //    Console.WriteLine($"속도 증가량 : {SelectedItem.AddSpd}");

        //    Console.ReadLine();
        //    Console.Clear();
        //    DisplayUserInventory(player);
        //}

        public void GetStatus()
        {
            P_maxhp = 100;
            P_atk = 20;
            P_def = 10;
            P_spd = 5;
        }

        public static void DisplayUserStatus(Player player)
        {
            Console.WriteLine($"==={player.name}의 스탯===");
            Console.WriteLine($"HP : {P_curhp}/{P_maxhp}");
            Console.WriteLine($"ATK : {P_atk}");
            Console.WriteLine($"DEf : {P_def}");
            Console.WriteLine($"SPD : {P_spd}");

            Thread.Sleep(1000);

            SelectStatusMenu(player);
        }

        public static void DisplayUserInventory(Player player)
        {
            Console.WriteLine($"==={player.name}의 인벤토리===");

            Console.WriteLine($"현재 소지금 : {gold}");

            foreach(var item in Inventory)
            {
                Console.WriteLine($"이름 : {item.Value.Name} " +
                    $"\n= 설명 : {item.Value.Description}");
                Console.WriteLine("\n");
            }

            Thread.Sleep(1000);

            SelectInventoryMenu(player);
        }

        public static void EquipWeapon()
        {
            Console.WriteLine("장착할 무기를 선택하세요.(0 : 고대의 검 1 : 고대의 창 2. 고대의 도끼)");
            int SelectedWeapon = int.Parse(Console.ReadLine());

            Inventory[SelectedWeapon].isEquipped = true;

            Console.WriteLine($"{Inventory[SelectedWeapon].Name} 장착성공!");

            switch (SelectedWeapon)
            {
                case 0:
                    AddSwordStat();
                    break;
                case 1:
                    AddSpearStat();
                    break;
                case 2:
                    AddAxeStat();
                    break;
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
                    EquipWeapon();
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

        public static void AddSwordStat(Sword sword)
        {
            P_atk += 
            P_def += Sword.AddDef;
            P_spd += Sword.AddSpd;
        }
        public static void AddSpearStat()
        {
            P_atk += Spear.AddAtk;
            P_def += Spear.AddDef;
            P_spd += Spear.AddSpd;
        }
        public static void AddAxeStat()
        {
            P_atk += Axe.AddAtk;
            P_def += Axe.AddDef;
            P_spd += Axe.AddSpd;
        }

        public static int AddAtk()
        {
            
        }
    }
}
