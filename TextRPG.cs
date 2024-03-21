using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class TextRPG
    {
        public static Player player;
        public static Monster monster;
        public static Item item;
        public static Shop shop;
        public static Dictionary<int, Item> Inventory;
        public static Item EquippedItem;
        public static Item BoughtItem;
        public static List<Monster> monsters;
        public static Dictionary<string, Player> StatusDic = new Dictionary<string, Player>();
        public static List<Item> ShopItemList;

        public static Slime Slime;
        public static Goblin Goblin;
        public static Orc Orc;
        public static FallenKnight FallenKnight;

        static string getName = "";
        public static bool isCreate = false;

        public static void Main(string[] args)
        {
            GameManager.Instance.StartGame();
        }
        #region 초기화면 세팅
        public static void InitStatus()
        {
            Random rand = new Random();
            int RandomHp = rand.Next(75, 126);
            int RandomAtk = rand.Next(15, 26);
            int RandomDef = rand.Next(5, 16);
            int RandomSpd = rand.Next(0, 11);

            StatusDic.Add("Normal", new Player("User", "Normal", 100, 20, 10, 5, 1000, 0, 100));
            StatusDic.Add("Random", new Player("User", "Random", RandomHp, RandomAtk, RandomDef, RandomSpd, 1000, 0, 100));
        }
        public static void InitSetting()
        {
            UI.DisplayGameUI();
            bool check = true;
            do
            {
                if (getName == null || getName == "")
                {
                    Console.SetCursorPosition(1, 24);
                    Utility.TextAlignment("당신의 이름은 무엇인가요?");
                    Console.SetCursorPosition(9, 30);
                    getName = Console.ReadLine();
                }
                else
                {
                    check = false;
                }
            }
            while (check);

            Console.SetCursorPosition(1, 30);
            Utility.TextAlignment($"당신의 이름은 {getName}이군요.");

            Thread.Sleep(2000);

            Console.Clear();
            SelectStatus();
        }
        public static void SelectStatus()
        {
            UI.DisplayGameUI();
            Console.SetCursorPosition(1, 24);
            Utility.TextAlignment("당신의 스탯 유형을 골라주세요.");
            Console.SetCursorPosition(1, 25);
            Utility.TextAlignment("[1] 기본스탯\t[2] 랜덤스탯");

            Console.SetCursorPosition(50, 30);

            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                player = new Player(StatusDic["Normal"].Name, StatusDic["Normal"].StatusType, StatusDic["Normal"].CurrentHp, StatusDic["Normal"].Atk, StatusDic["Normal"].Def, StatusDic["Normal"].Spd, StatusDic["Normal"].Gold, StatusDic["Normal"].Exp, StatusDic["Normal"].MaxExp);
                InitInventory();
            }
            else if (input == 2)
            {
                player = new Player(StatusDic["Random"].Name, StatusDic["Random"].StatusType, StatusDic["Random"].CurrentHp, StatusDic["Random"].Atk, StatusDic["Random"].Def, StatusDic["Random"].Spd, StatusDic["Random"].Gold, StatusDic["Random"].Exp, StatusDic["Random"].MaxExp);
                InitInventory();
            }
            else
            {
                SelectStatus();
            }

            player.Name = getName;
            isCreate = true;
            Console.Clear();

            GameManager.Instance.DisplayHome();
        }
        #endregion

        #region 정보표현
        public static void DisplayUserStatus()
        {
            UI.DisplayGameUI();

            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"{player.Name}의 스탯");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine($"HP : {player.CurrentHp}/{player.Hp}");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine($"ATK : {player.Atk}");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine($"DEf : {player.Def}");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine($"SPD : {player.Spd}");

            Thread.Sleep(500);

            Console.SetCursorPosition(3, 24);
            Console.WriteLine("아무키나 눌러 뒤로가기");

            Console.SetCursorPosition(3, 30);
            Console.ReadLine();

            Console.Clear();

            GameManager.Instance.DisplayHome();
        }
        public static void DisplayUserInventory()
        {
            UI.DisplayGameUI();

            Console.SetCursorPosition(3, 1);
            Console.WriteLine($"{player.Name}의 인벤토리");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"소지금 : {player.Gold}");

            int idx = 5;
            foreach (var item in Inventory)
            {
                Console.SetCursorPosition(3, idx);
                Console.WriteLine($"{item.Value.Name} ({item.Value.Quantity})");
                Console.SetCursorPosition(3, idx + 1);
                Console.WriteLine($"{item.Value.Description}");
                Console.SetCursorPosition(3, idx + 2);
                Console.WriteLine("--------------------------");
                idx += 3;
            }
            Console.WriteLine("\n");

            Thread.Sleep(500);

            Console.SetCursorPosition(3, 24);
            Console.WriteLine("[1] 장비장착 / [2] 뒤로가기");

            Console.SetCursorPosition(3, 30);
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                
                EquipWeapon();
            }
            else if (input == 2)
            {
                Console.Clear();
                GameManager.Instance.DisplayHome();
            }
        }
        #endregion

        #region 인벤토리
        public static void InitInventory()
        {
            Inventory = new Dictionary<int, Item>();

            Item AncientSword = new Sword("고대의 검", 0, 0, "유저와 함께 성장하는 성장형 검입니다.", 10, 0, 3);
            Item AncientSpear = new Spear("고대의 창", 1, 1, "유저와 함께 성장하는 성장형 창입니다.", 15, 0, 0);
            Item AncientAxe = new Axe("고대의 도끼", 2, 2, "유저와 함께 성장하는 성장형 도끼입니다.", 20, 0, -3);

            Inventory.Add(0, AncientSword);
            Inventory.Add(1, AncientSpear);
            Inventory.Add(2, AncientAxe);
        }
        public static void EquipWeapon()
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("장착할 무기를 선택하세요.");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("[1] 고대의 검 / [2] 고대의 창 / [3] 고대의 도끼");

            Console.SetCursorPosition(3, 8);
            int SelectedWeapon = int.Parse(Console.ReadLine());

            if (EquippedItem != null)
            {
                Console.SetCursorPosition(50, 5);
                Console.WriteLine($"{Inventory[SelectedWeapon - 1].Name} 장착실패");
                Thread.Sleep(1000);
                Console.SetCursorPosition(50, 6);
                Console.WriteLine("이미 무기를 장착하고있습니다.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("무기를 교체하시겠습니까?");
                Thread.Sleep(1000);
                Console.SetCursorPosition(50, 8);
                Console.WriteLine("[1] 예 / [2] 아니오");

                Console.SetCursorPosition(50, 9);
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(50, 9);
                    Console.WriteLine("무기를 교체합니다.");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(50, 10);
                    Console.WriteLine($"{Inventory[SelectedWeapon - 1].Name} 교체 성공");
                    EquippedItem = Inventory[SelectedWeapon - 1];
                    
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(50, 9);
                    Console.WriteLine("무기 교체를 취소합니다.");

                    EquipWeapon();
                }
            }
            else
            {
                Thread.Sleep(1000);
                Console.SetCursorPosition(50, 5);
                Console.WriteLine($"{Inventory[SelectedWeapon - 1].Name} 장착성공!");
            }

            EquippedItem = Inventory[SelectedWeapon - 1];

            

            if (EquippedItem is Sword sword)
            {
                player.Atk += sword.ATK;
                player.Def += sword.DEF;
                player.Spd += sword.SPD;
            }
            else if (EquippedItem is Spear spear)
            {
                player.Atk += spear.ATK;
                player.Def += spear.DEF;
                player.Spd += spear.SPD;
            }
            else if (EquippedItem is Axe axe)
            {
                player.Atk += axe.ATK;
                player.Def += axe.DEF;
                player.Spd += axe.SPD;
            }

            Thread.Sleep(1000);

            Console.Clear();

            GameManager.Instance.DisplayHome();
        }
        #endregion

        #region 상점
        public static void InitializeShop()
        {
            ShopItemList = new List<Item>
            {
                new Potion("소형 체력물약", 50, "사용 시 체력 20을 회복합니다.", 3, 3),
                new Potion("중형 체력물약", 100, "사용 시 체력 40을 회복합니다.", 3, 4),
                new Potion("대형 체력물약", 200, "사용 시 체력 80을 회복합니다.", 3, 5),
                new Scroll("강제 탈출 스크롤", 150, "반드시 전투에서 도망칠 수 있습니다.", 4, 6)
            };
        }
        public static void DisplayShopItem()
        {
            InitializeShop();
            UI.DisplayGameUI();

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("   상점 아이템 목록   ");

            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"현재 소지금 : {TextRPG.player.Gold}");

            int idx = 5;
            foreach (var item in ShopItemList)
            {
                Console.SetCursorPosition(3, idx);
                Console.WriteLine($"{item.Id}. {item.Name}");
                Console.SetCursorPosition(3, idx + 1);
                Console.WriteLine($"구매가격 : {item.Value}");
                Console.SetCursorPosition(3, idx + 2);
                Console.WriteLine($"설명 : {item.Description}");
                Console.SetCursorPosition(3, idx + 3);
                Console.WriteLine("--------------------");
                idx += 4;
            }
            Console.WriteLine("\n");

            Console.SetCursorPosition(3, 24);
            Console.WriteLine("[1] 아이템 구매 / [2] 아이템 판매 / [3] 뒤로가기");

            Console.SetCursorPosition(50, 30);
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Console.Clear();
                BuyItem();
            }
            else if (input == 2)
            {
                Console.Clear();
                SellItem();
            }
            else if (input == 3)
            {
                Console.Clear();
                GameManager.Instance.DisplayHome();
            }
        }
        public static void BuyItem()
        {
            UI.DisplayGameUI();

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("   상점 아이템 목록   ");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"현재 소지금 : {TextRPG.player.Gold}");

            int idx = 5;
            foreach (var item in ShopItemList)
            {
                Console.SetCursorPosition(3, idx);
                Console.WriteLine($"{item.Id} .  {item.Name}");
                Console.SetCursorPosition(3, idx + 1);
                Console.WriteLine($"구매가격 : {item.Value}");
                Console.SetCursorPosition(3, idx + 2);
                Console.WriteLine($"설명 : {item.Description}");
                Console.SetCursorPosition(3, idx + 3);
                Console.WriteLine("---------------------");
                idx += 4;
            }

            Console.SetCursorPosition(50, 5);
            Console.Write("어떤 상품을 구매하시겠습니까?(-1 : 취소) ");

            int SelectedItem = int.Parse(Console.ReadLine());
            if (SelectedItem == -1)
            {
                DisplayShopItem();
            }


            Console.SetCursorPosition(50, 6);
            Console.Write("몇 개 구매하시겠습니까? ");
            int ItemCnt = int.Parse(Console.ReadLine());

            int PaidGold = ItemCnt * ShopItemList[SelectedItem-3].Value;

            if (PaidGold > TextRPG.player.Gold)
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("현재 소지금이 부족합니다.");

                Thread.Sleep(2000);

                DisplayShopItem();
            }
            else
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine($"{ShopItemList[SelectedItem - 3].Name} {ItemCnt}개 구매하였습니다.");

                Thread.Sleep(2000);
                player.Gold -= PaidGold;
                TextRPG.AddItem(ShopItemList, SelectedItem-3, ItemCnt);
            }

            Thread.Sleep(300);

            Console.Clear();

            DisplayShopItem();
        }
        public static void AddItem(List<Item> list, int idx, int quantity)
        {
            Item item = list[idx];
            int id = item.Id;
            if (!Inventory.ContainsKey(id))
            {
                Inventory.Add(id, item);
                item.Quantity = quantity;
            }
            else
            {
                Inventory[id].Quantity += quantity;
            }
        }
        public static void SellItem()
        {
            Console.Clear();

            UI.DisplayGameUI();

            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"   인벤토리   ");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"현재 소지금 : {TextRPG.player.Gold}");

            int idx = 5;
            foreach (var item in Inventory)
            {
                Console.SetCursorPosition(3, idx);
                Console.WriteLine($"{item.Value.Id}. {item.Value.Name} ({item.Value.Quantity})");
                Console.SetCursorPosition(3, idx + 1);
                Console.WriteLine($"판매가격 : {(int)item.Value.Value * 0.8}");
                Console.SetCursorPosition(3, idx + 2);
                Console.WriteLine("-------------------------------");
                idx += 3;
            }

            Console.SetCursorPosition(50, 5);
            Console.Write("어떤 상품을 파시겠습니까? (-1 : 취소)");
            int SelectedItem = int.Parse(Console.ReadLine());

            if (SelectedItem == -1)
            {
                DisplayShopItem();
            }

            if (SelectedItem == 0 || SelectedItem == 1 || SelectedItem == 2)
            {
                Console.SetCursorPosition(50, 6);
                Console.WriteLine("무기는 판매 불가능합니다.");

                Thread.Sleep(2000);

                SellItem();
            }

            Console.SetCursorPosition(50, 7);
            Console.Write("몇 개 판매하시겠습니까? ");
            int ItemCnt = int.Parse(Console.ReadLine());

            if (ItemCnt > Player.Inventory[SelectedItem].Quantity)
            {
                Console.SetCursorPosition(50, 8);
                Console.WriteLine("\n판매수량이 보유수량보다 많습니다.");

                Thread.Sleep(2000);

                SellItem();
            }
            else if (ItemCnt < Player.Inventory[SelectedItem].Quantity)
            {
                Console.SetCursorPosition(50, 8);
                Console.WriteLine($"\n{Player.Inventory[SelectedItem].Name} {ItemCnt}개 판매하였습니다.");

                Player.Inventory[SelectedItem].Quantity -= ItemCnt;
                TextRPG.player.Gold += (int)(Player.Inventory[SelectedItem].Value * 0.8) * ItemCnt;

                Thread.Sleep(2000);
            }
            else
            {
                Console.SetCursorPosition(50, 8);
                Console.WriteLine($"\n{Player.Inventory[SelectedItem].Name} {ItemCnt}개 판매하였습니다.");
                Player.Inventory.Remove(SelectedItem);
                TextRPG.player.Gold += (int)(Player.Inventory[SelectedItem].Value * 0.8) * ItemCnt;

                Thread.Sleep(2000);
            }

            Console.Clear();

            GameManager.Instance.DisplayHome();
        }
        #endregion

        #region 던전
        public static void EnterDungeon()
        {
            Console.Clear();
            UI.DisplayGameUI();

            Console.SetCursorPosition(1, 2);
            Utility.TextAlignment("던전 입구에 들어섰습니다.");

            Console.SetCursorPosition(1, 24);
            Utility.TextAlignment("[1] 늪지대 [2] 깊은숲 [3] 동굴 [4] 고성 [0] 돌아가기");

            Console.SetCursorPosition(50, 30);
            int input = int.Parse(Console.ReadLine());
            if(input == 0)
            {
                GameManager.Instance.DisplayHome();
            }
            else if (input == 1)
            {
                Swamp swamp = new Swamp();
                swamp.Start(player);
            }
            else if (input == 2)
            {
                Forest forest = new Forest();
                forest.Start(player);
            }
            else if (input == 3)
            {
                Cave cave = new Cave();
                cave.Start(player);
            }
            else if (input == 4)
            {
                FallenCastle fallenCastle = new FallenCastle();
                fallenCastle.Start(player);
            }
        }
        #endregion

        #region 전투 중 아이템 사용
        public static void ItemUseInBattle()
        {
            Console.Clear();
            UI.DisplayGameUI();

            Console.SetCursorPosition(3, 2);
            Console.WriteLine("   사용 가능한 아이템 목록   ");

            int idx = 5;
            foreach (var item in Inventory)
            {
                if (item.Key >= 3)
                {
                    Console.SetCursorPosition(3, idx);
                    Console.WriteLine($"{item.Key}. {item.Value.Name} ({item.Value.Quantity})");
                    Console.SetCursorPosition(3, idx + 1);
                    Console.WriteLine($"{item.Value.Description}");
                    Console.SetCursorPosition(3, idx + 2);
                    Console.WriteLine("-----------------------");
                    idx += 3;
                }
            }

            Console.SetCursorPosition(50, 5);
            Console.Write("아이템 선택 : (취소 : -1)");

            int UsedItemIdx = int.Parse(Console.ReadLine());
            if (UsedItemIdx == -1)
            {
                Battle.Start(player, monster);
            }

            Console.SetCursorPosition(50, 6);
            Console.WriteLine($"{Inventory[UsedItemIdx].Name}을(를) 사용합니다.");

            switch (Inventory[UsedItemIdx]._type)
            {
                case 3:
                    Potion.Healing(UsedItemIdx);
                    Inventory[UsedItemIdx].Quantity--;
                    break;
                case 4:
                    Scroll.Escape(UsedItemIdx);
                    Inventory[UsedItemIdx].Quantity--;
                    break;
            }
        }
        #endregion

        public static void GetExp(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.Normal:
                    player.Exp += 20;
                    break;
                case MonsterType.Elite:
                    player.Exp += 35;
                    break;
                case MonsterType.Boss:
                    player.Exp += 50;
                    break;
            }

            if (player.Exp >= player.MaxExp)
            {
                ResetExp();
                UpdateLv();
            }
        }

        public static void ResetExp()
        {
            player.Exp = 0;
            player.MaxExp += 20;
        }

        public static void UpdateLv()
        {
            Console.Clear();
            UI.DisplayGameUI();

            Thread.Sleep(2000);
            int abilitycnt = 5;

            Console.SetCursorPosition(3, 5);
            Console.WriteLine("레벨이 상승했습니다.");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("상승시킬 능력치를 고르세요.");
            Console.SetCursorPosition(3, 7);
            Console.Write("[1] 공격력 : ");
            int UseAtkcnt = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 8);
            Console.Write("[2] 방어력 : ");
            int UseDefcnt = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 9);
            Console.Write("[3] 속도 : ");
            int UseSpdcnt = int.Parse(Console.ReadLine());

            int UsedAbilityCnt = UseAtkcnt + UseDefcnt + UseSpdcnt;

            if(UsedAbilityCnt == abilitycnt)
            {
                Console.SetCursorPosition(3, 10);
                Console.WriteLine($"공격력이 {UseAtkcnt}만큼 상승했습니다.");
                Console.SetCursorPosition(3, 11);
                Console.WriteLine($"방어력이 {UseDefcnt}만큼 상승했습니다.");
                Console.SetCursorPosition(3, 12);
                Console.WriteLine($"속도가 {UseSpdcnt}만큼 상승했습니다.");

                player.Atk += UseAtkcnt;
                player.Def += UseDefcnt;
                player.Spd += UseSpdcnt;
            }
            else if(UsedAbilityCnt < abilitycnt)
            {
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("스탯포인트를 모두 사용해주세요");

                Thread.Sleep(3000);

                UpdateLv();
            }
            else if(UsedAbilityCnt > abilitycnt)
            {
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("스탯포인트를 초과해서 사용했습니다.");

                Thread.Sleep(3000);

                UpdateLv();
            }

        }
    }
}
