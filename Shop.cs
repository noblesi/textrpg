using System.Numerics;

namespace MiniProject
{
    public class Shop
    {
        public static Dictionary<int, Item> ShopItemList = new Dictionary<int, Item>();
        public static void InitializeShop()
        {
            Item HealingPotion_S = new Potion("소형 체력물약", 50, "사용 시 체력 20을 회복합니다.", 3, 3);
            Item HealingPotion_M = new Potion("중형 체력물약", 100, "사용 시 체력 40을 회복합니다.", 3, 4);
            Item HealingPotion_L = new Potion("대형 체력물약", 200, "사용 시 체력 80을 회복합니다.", 3, 5);
            Item Scroll_EXIT = new Scroll("강제 탈출 스크롤", 150, "반드시 전투에서 도망칠 수 있습니다.", 4, 6);

            ShopItemList.Add(3, HealingPotion_S);
            ShopItemList.Add(4, HealingPotion_M);
            ShopItemList.Add(5, HealingPotion_L);
            ShopItemList.Add(6, Scroll_EXIT);
        }
        public static void DisplayShopItem()
        {
            InitializeShop();

            Utility.WriteCenterPosition($"현재 소지금 : {TextRPG.player.Gold}");

            Utility.WriteCenterPosition("\n");

            Utility.WriteCenterPosition("===상점 아이템 목록===");

            foreach (var item in ShopItemList)
            {
                Utility.WriteCenterPosition($"{item.Value.Id}. {item.Value.Name}");
                Utility.WriteCenterPosition($"구매가격 : {item.Value.Value}");
                Utility.WriteCenterPosition($"설명 : {item.Value.Description}");
                Utility.WriteCenterPosition("===================");
            }
            Console.WriteLine("\n");

            Utility.WriteCenterPosition("[1] 아이템 구매");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[2] 아이템 판매");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[3] 뒤로가기");

            int input = int.Parse(Console.ReadLine());

            if(input == 1)
            {
                Console.Clear();
                BuyItem();
            }
        }

        public static void BuyItem()
        {
            Utility.WriteCenterPosition($"현재 소지금 : {TextRPG.player.Gold}");

            Utility.WriteCenterPosition("\n");

            Utility.WriteCenterPosition("===상점 아이템 목록===");

            foreach (var item in ShopItemList)
            {
                Utility.WriteCenterPosition($"{item.Value.Id}. {item.Value.Name}");
                Utility.WriteCenterPosition($"구매가격 : {item.Value.Value}");
                Utility.WriteCenterPosition($"설명 : {item.Value.Description}");
                Utility.WriteCenterPosition("===================");
            }
            Console.WriteLine("\n");

            Console.Write("어떤 상품을 구매하시겠습니까?(-1 : 취소) ");
            int SelectedItem = int.Parse(Console.ReadLine());
            if (SelectedItem == -1)
            {
                return;
            }

            Console.WriteLine("\n");

            Console.Write("몇 개 구매하시겠습니까? ");
            int ItemCnt = int.Parse(Console.ReadLine());

            int PaidGold = ItemCnt * ShopItemList[SelectedItem].Value;

            if (PaidGold > TextRPG.player.Gold)
            {
                Console.WriteLine("\n현재 소지금이 부족합니다.");

                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine($"\n{ShopItemList[SelectedItem].Name} {ItemCnt}개 구매하였습니다.");

                Thread.Sleep(2000);
                TextRPG.player.Gold -= PaidGold;
                Player.AddItem(ShopItemList[SelectedItem], ItemCnt);
            }

            Thread.Sleep(300);

            Console.Clear();

            GameManager.Instance.DisplayHome();
        }

        public static void SellItem()
        {
            Console.Clear();

            Console.WriteLine($"현재 소지금 : {TextRPG.player.Gold}\n");

            Console.WriteLine($"===인벤토리===");

            foreach (var item in Player.Inventory)
            {
                Console.WriteLine($"{item.Value.Id}. {item.Value.Name} || 판매가격 : {item.Value.Value * 0.8} || 보유개수 : {item.Value.Quantity}");
            }

            Console.Write("어떤 상품을 파시겠습니까? ");
            int SelectedItem = int.Parse(Console.ReadLine());

            if (SelectedItem == -1)
            {
                return;
            }

            if (SelectedItem == 0 || SelectedItem == 1 || SelectedItem == 2)
            {
                Console.WriteLine("무기는 판매 불가능합니다.");

                Thread.Sleep(2000);

                return;
            }

            Console.WriteLine("\n");

            Console.Write("몇 개 판매하시겠습니까? ");
            int ItemCnt = int.Parse(Console.ReadLine());

            if (ItemCnt > Player.Inventory[SelectedItem].Quantity)
            {
                Console.WriteLine("\n판매수량이 보유수량보다 많습니다.");

                Thread.Sleep(2000);
            }
            else if (ItemCnt < Player.Inventory[SelectedItem].Quantity)
            {
                Console.WriteLine($"\n{Player.Inventory[SelectedItem].Name} {ItemCnt}개 판매하였습니다.");

                Player.Inventory[SelectedItem].Quantity -= ItemCnt;
                TextRPG.player.Gold += (int)(Player.Inventory[SelectedItem].Value * 0.8) * ItemCnt;

                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine($"\n{Player.Inventory[SelectedItem].Name} {ItemCnt}개 판매하였습니다.");
                Player.Inventory.Remove(SelectedItem);
                TextRPG.player.Gold += (int)(Player.Inventory[SelectedItem].Value * 0.8) * ItemCnt;

                Thread.Sleep(2000);
            }

            Console.Clear();

            GameManager.Instance.DisplayHome();
        }

        //    public static void SelectShopMenu()
        //    {
        //        Thread.Sleep(1000);

        //        Console.WriteLine("1. 아이템 구매\t2. 아이템 판매\t3. 상점 나가기");
        //        int ShopSelectIdx = int.Parse(Console.ReadLine());

        //        switch (ShopSelectIdx)
        //        {
        //            case 1:
        //                BuyItem(player);
        //                Console.Clear();
        //                DisplayShopItem();
        //                break;
        //            case 2:
        //                SellItem(player);
        //                Console.Clear();
        //                DisplayShopItem();
        //                break;
        //            case 3:
        //                Console.Clear();
        //                GamePlay.SelectPlay();
        //                break;
        //        }
        //    }
        //}
    }
}
