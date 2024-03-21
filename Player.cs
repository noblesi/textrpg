namespace MiniProject
{
    public class Player
    {
        public string StatusType {  get; set; }
        public string Name { get; set; }
        public int Hp {  get; set; }
        public int CurrentHp {  get; set; }
        public int Atk {  get; set; }
        public int Def {  get; set; }
        public int Spd {  get; set; }
        public int Gold { get; set; }
        public static bool isBuffed { get; set; }
        public static Dictionary<int, Item> Inventory { get; set; }

        public static Sword equippedSword;
        public static Spear equippedSpear;
        public static Axe equippedAxe;
        
        public Player()
        {

        }

        public Player(string name, string type, int hp, int atk, int def, int spd, int gold)
        {
            Name = name;
            StatusType = type;
            CurrentHp = hp;
            Hp = CurrentHp;
            Atk = atk;
            Def = def;
            Spd = spd;
            Gold = gold;
        }

        public Player(Sword sword)
        {
            equippedSword = sword;
        }

        public Player(Spear spear)
        {
            equippedSpear = spear;
        }

        public Player(Axe axe)
        {
            equippedAxe = axe;
        }

        //public void InitInventory()
        //{
        //    Inventory = new Dictionary<int, Item>();

        //    Item AncientSword = new Sword("고대의 검", 0, 0, "유저와 함께 성장하는 성장형 검입니다.", 10, 0, 3);
        //    Item AncientSpear = new Spear("고대의 창", 1, 1, "유저와 함께 성장하는 성장형 창입니다.", 15, 0, 0);
        //    Item AncientAxe = new Axe("고대의 도끼", 2, 2, "유저와 함께 성장하는 성장형 도끼입니다.", 20, 0, -3);

        //    Inventory.Add(0, AncientSword);
        //    Inventory.Add(1, AncientSpear);
        //    Inventory.Add(2, AncientAxe);
        //}

        public void Attack(Monster monster)
        {
            int DamageToMonster;

            if(monster.M_def >= Atk)
            {
                DamageToMonster = 0;
                Console.SetCursorPosition(3, 11);
                Console.WriteLine($"데미지를 {DamageToMonster}만큼 입혔습니다.");
            }
            else
            {
                DamageToMonster = Atk - monster.M_def;
                monster.M_curhp -= DamageToMonster;
                Console.SetCursorPosition(3, 11);
                Console.WriteLine($"데미지를 {DamageToMonster}만큼 입혔습니다.");
            }
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("                                                ");
            Console.SetCursorPosition(50, 6);
            Console.WriteLine($"HP : {((monster.M_curhp > 0) ? monster.M_curhp : 0)} / {monster.M_hp}");

            if (monster.M_hp <= 0)
            {
                Random rand = new Random();
                int RandomGold = rand.Next(50, 101);
                Console.SetCursorPosition(1, 24);
                Utility.TextAlignment("전투에서 승리하였습니다.");
                Console.SetCursorPosition(1, 30);
                Utility.TextAlignment($"골드를 획득합니다! (+{RandomGold})");

                TextRPG.player.Gold += RandomGold;

                Console.WriteLine("무기 경험치를 획득합니다.");
                Console.WriteLine("=================");

                

                Console.Clear();

                Thread.Sleep(500);

                GameManager.Instance.DisplayHome();
            }
        }

        

        //public static void AddItem(Item item, int idx)
        //{
        //    int id = item.Id;
        //    if (!Inventory.ContainsKey(id))
        //    {
        //        Inventory.Add(id, item);
        //        item.Quantity = idx;
        //    }
        //    else
        //    {
        //        Inventory[id].Quantity += idx;
        //    }
        //}


        public void ItemUseInBattle()
        {
            Console.Clear();
            UI.DisplayGameUI();

            Console.SetCursorPosition(3, 2);
            Console.WriteLine("   사용 가능한 아이템 목록   ");

            int idx = 5;
            foreach(var item in Inventory)
            {
                if(item.Key >= 3)
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
            if(UsedItemIdx == -1)
            {
                ItemUseInBattle();
            }

            Console.SetCursorPosition(50, 6);
            Console.WriteLine($"{Inventory[UsedItemIdx].Name}을(를) 사용합니다.");

            switch(Inventory[UsedItemIdx]._type)
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
    }
}
