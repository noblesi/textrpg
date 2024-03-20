using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class TextRPG
    {
        GameManager gameManager = GameManager.Instance;
        public static Player player;
        public static Monster monster;
        public static Item item;
        public static Shop shop;
        public static Dictionary<int, Item> Inventory;
        public static Item EquippedItem;
        public static List<Monster> monsters;
        public static Dictionary<string, Player> StatusDic = new Dictionary<string, Player>();
        public static Dictionary<int, Item> ShopItemList;

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

        public static void InitStatus()
        {
            Random rand = new Random();
            int RandomHp = rand.Next(75, 126);
            int RandomAtk = rand.Next(15, 26);
            int RandomDef = rand.Next(5, 16);
            int RandomSpd = rand.Next(0, 11);

            StatusDic.Add("Normal", new Player("User", "Normal", 100, 20, 10, 5, 1000)); ;
            StatusDic.Add("Random", new Player("User", "Random", RandomHp, RandomAtk, RandomDef, RandomSpd, 1000));
        }

        public static void InitSetting()
        {
            bool check = true;
            do
            {
                if (getName == null || getName == "")
                {
                    Utility.WriteCenterPosition("당신의 이름은 무엇인가요?");
                    Console.WriteLine("\n");
                    getName = Console.ReadLine();
                }
                else
                {
                    check = false;
                }
            }
            while (check);

            Console.Clear();
            Utility.WriteCenterPosition($"당신의 이름은 {getName}이군요.");

            SelectStatus();
        }

        public static void SelectStatus()
        {
            Utility.WriteCenterPosition("당신의 스탯 유형을 골라주세요.");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[1] 기본스탯");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[2] 랜덤스탯");

            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                player = new Player(StatusDic["Normal"].Name, StatusDic["Normal"].StatusType, StatusDic["Normal"].CurrentHp, StatusDic["Normal"].Atk, StatusDic["Normal"].Def, StatusDic["Normal"].Spd, StatusDic["Normal"].Gold);
                InitInventory();
            }
            else if (input == 2)
            {
                player = new Player(StatusDic["Random"].Name, StatusDic["Random"].StatusType, StatusDic["Random"].CurrentHp, StatusDic["Random"].Atk, StatusDic["Random"].Def, StatusDic["Random"].Spd, StatusDic["Random"].Gold);
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

        public static void DisplayUserStatus()
        {
            Utility.WriteCenterPosition($"==={player.Name}의 스탯===");
            Utility.WriteCenterPosition($"HP : {player.CurrentHp}/{player.Hp}");
            Utility.WriteCenterPosition($"ATK : {player.Atk}");
            Utility.WriteCenterPosition($"DEf : {player.Def}");
            Utility.WriteCenterPosition($"SPD : {player.Spd}");

            Thread.Sleep(500);

            Utility.WriteCenterPosition("아무키나 눌러 뒤로가기");

            Console.ReadLine();

            Console.Clear();

            GameManager.Instance.DisplayHome();
        }

        public static void DisplayUserInventory()
        {
            Utility.WriteCenterPosition($"==={player.Name}의 인벤토리===");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition($"현재 소지금 : {player.Gold}");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("===================");

            foreach (var item in Inventory)
            {
                Utility.WriteCenterPosition($"{item.Value.Name}");
                Utility.WriteCenterPosition($"{item.Value.Description}");
                Utility.WriteCenterPosition("===================");
            }
            Console.WriteLine("\n");

            Thread.Sleep(500);

            Utility.WriteCenterPosition("[1] 장비장착");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[2] 뒤로가기");

            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Console.Clear();
                EquipWeapon();
            }
            else if (input == 2)
            {
                Console.Clear();
                GameManager.Instance.DisplayHome();
            }
        }
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
            Utility.WriteCenterPosition("장착할 무기를 선택하세요.");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[1] 고대의 검");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[2] 고대의 창");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[3] 고대의 도끼");

            int SelectedWeapon = int.Parse(Console.ReadLine());

            if (EquippedItem != null)
            {
                Utility.WriteCenterPosition($"{Inventory[SelectedWeapon-1].Name} 장착실패");
                Utility.WriteCenterPosition("이미 무기를 장착하고있습니다.");
                Utility.WriteCenterPosition("무기를 교체하시겠습니까?");
                Utility.WriteCenterPosition("1. 예 / 2. 아니오");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Utility.WriteCenterPosition("무기를 교체합니다.");
                    EquippedItem = Inventory[SelectedWeapon-1];
                }
                else
                {
                    Utility.WriteCenterPosition("무기 교체를 취소합니다.");
                    return;
                }
            }
            else
            {
                Utility.WriteCenterPosition($"{Inventory[SelectedWeapon-1].Name} 장착성공!");
            }

            EquippedItem = Inventory[SelectedWeapon-1];

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

            Thread.Sleep(300);

            Console.Clear();

            GameManager.Instance.DisplayHome();
        }
    }
}
