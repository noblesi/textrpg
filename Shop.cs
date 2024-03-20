using System.Numerics;

namespace MiniProject
{
    public class Shop
    {
        public static List<Item> ShopItemList;
        //public static void InitializeShop()
        //{
        //    ShopItemList = new List<Item>
        //    {
        //        new Potion("소형 체력물약", 50, "사용 시 체력 20을 회복합니다.", 3, 3),
        //        new Potion("중형 체력물약", 100, "사용 시 체력 40을 회복합니다.", 3, 4),
        //        new Potion("대형 체력물약", 200, "사용 시 체력 80을 회복합니다.", 3, 5),
        //        new Scroll("강제 탈출 스크롤", 150, "반드시 전투에서 도망칠 수 있습니다.", 4, 6)
        //    };
        //}
        //public static void DisplayShopItem()
        //{
        //    InitializeShop();
        //    UI.DisplayGameUI();

        //    Console.SetCursorPosition(1, 1);
        //    Console.WriteLine("   상점 아이템 목록   ");

        //    Console.SetCursorPosition(3, 2);
        //    Console.WriteLine($"현재 소지금 : {TextRPG.player.Gold}");

        //    int idx = 5;
        //    foreach (var item in ShopItemList)
        //    {
        //        Console.SetCursorPosition(3, idx);
        //        Console.WriteLine($"{item.Id}. {item.Name}");
        //        Console.SetCursorPosition(3, idx+1);
        //        Console.WriteLine($"구매가격 : {item.Value}");
        //        Console.SetCursorPosition(3, idx+2);
        //        Console.WriteLine($"설명 : {item.Description}");
        //        Console.SetCursorPosition(3, idx+3);
        //        Console.WriteLine("--------------------");
        //        idx += 4;
        //    }
        //    Console.WriteLine("\n");

        //    Console.SetCursorPosition(3, 24);
        //    Console.WriteLine("[1] 아이템 구매 / [2] 아이템 판매 / [3] 뒤로가기");

        //    Console.SetCursorPosition(50, 30);
        //    int input = int.Parse(Console.ReadLine());

        //    if(input == 1)
        //    {
        //        Console.Clear();
        //        BuyItem();
        //    }
        //    else if(input == 2)
        //    {
        //        Console.Clear();
        //        SellItem();
        //    }
        //    else if(input == 3)
        //    {
        //        Console.Clear();
        //        GameManager.Instance.DisplayHome();
        //    }
        //}

        //public static void BuyItem()
        //{
        //    UI.DisplayGameUI();

        //    Console.SetCursorPosition(1, 1);
        //    Console.WriteLine("   상점 아이템 목록   ");
        //    Console.SetCursorPosition(3, 2);
        //    Console.WriteLine($"현재 소지금 : {TextRPG.player.Gold}");

        //    int idx = 5;
        //    foreach (var item in ShopItemList)
        //    {
        //        Console.SetCursorPosition(3, idx);
        //        Console.WriteLine($"{item.Id} .  {item.Name}");
        //        Console.SetCursorPosition(3, idx + 1);
        //        Console.WriteLine($"구매가격 : {item.Value}");
        //        Console.SetCursorPosition(3, idx + 2);
        //        Console.WriteLine($"설명 : {item.Description}");
        //        Console.SetCursorPosition(3, idx + 3);
        //        Console.WriteLine("---------------------");
        //        idx += 4;
        //    }

        //    Console.SetCursorPosition(50, 5);
        //    Console.Write("어떤 상품을 구매하시겠습니까?(-1 : 취소) ");

        //    int SelectedItem = int.Parse(Console.ReadLine());
        //    if (SelectedItem == -1)
        //    {
        //        DisplayShopItem();
        //    }


        //    Console.SetCursorPosition(50, 6);
        //    Console.Write("몇 개 구매하시겠습니까? ");
        //    int ItemCnt = int.Parse(Console.ReadLine());

        //    int PaidGold = ItemCnt * ShopItemList[SelectedItem].Value;

        //    if (PaidGold > TextRPG.player.Gold)
        //    {
        //        Console.SetCursorPosition(50, 7);
        //        Console.WriteLine("현재 소지금이 부족합니다.");

        //        Thread.Sleep(2000);

        //        DisplayShopItem();
        //    }
        //    else
        //    {
        //        Console.SetCursorPosition(50, 7);
        //        Console.WriteLine($"{ShopItemList[SelectedItem - 3].Name} {ItemCnt}개 구매하였습니다.");
        //        Item BoughtItem = ShopItemList[SelectedItem - 3];
                
        //        Thread.Sleep(2000);
        //        TextRPG.player.Gold -= PaidGold;
        //        TextRPG.AddItem(BoughtItem, ItemCnt);
        //    }

        //    Thread.Sleep(300);

        //    Console.Clear();

        //    GameManager.Instance.DisplayHome();
        //}

        //public static void SellItem()
        //{
        //    Console.Clear();

        //    UI.DisplayGameUI();

        //    Console.SetCursorPosition(1, 1);
        //    Console.WriteLine($"   인벤토리   ");
        //    Console.SetCursorPosition(1, 2);
        //    Console.WriteLine($"현재 소지금 : {TextRPG.player.Gold}");

        //    int idx = 5;
        //    foreach (var item in Player.Inventory)
        //    {
        //        Console.SetCursorPosition(1, idx);
        //        Console.WriteLine($"{item.Value.Id}. {item.Value.Name} || 판매가격 : {item.Value.Value * 0.8} || 보유개수 : {item.Value.Quantity}");
        //        Console.WriteLine("-------------------------------");
        //        idx += 2;
        //    }

        //    Console.SetCursorPosition(50, 5);
        //    Console.Write("어떤 상품을 파시겠습니까? ");
        //    int SelectedItem = int.Parse(Console.ReadLine());

        //    if (SelectedItem == -1)
        //    {
        //        return;
        //    }

        //    if (SelectedItem == 0 || SelectedItem == 1 || SelectedItem == 2)
        //    {
        //        Console.SetCursorPosition(50, 6);
        //        Console.WriteLine("무기는 판매 불가능합니다.");

        //        Thread.Sleep(2000);

        //        return;
        //    }


        //    Console.SetCursorPosition(50, 7);
        //    Console.Write("몇 개 판매하시겠습니까? ");
        //    int ItemCnt = int.Parse(Console.ReadLine());

        //    if (ItemCnt > Player.Inventory[SelectedItem].Quantity)
        //    {
        //        Console.SetCursorPosition(50, 8);
        //        Console.WriteLine("\n판매수량이 보유수량보다 많습니다.");

        //        Thread.Sleep(2000);

        //        return;
        //    }
        //    else if (ItemCnt < Player.Inventory[SelectedItem].Quantity)
        //    {
        //        Console.SetCursorPosition(50, 8);
        //        Console.WriteLine($"\n{Player.Inventory[SelectedItem].Name} {ItemCnt}개 판매하였습니다.");

        //        Player.Inventory[SelectedItem].Quantity -= ItemCnt;
        //        TextRPG.player.Gold += (int)(Player.Inventory[SelectedItem].Value * 0.8) * ItemCnt;

        //        Thread.Sleep(2000);
        //    }
        //    else
        //    {
        //        Console.SetCursorPosition(50, 8);
        //        Console.WriteLine($"\n{Player.Inventory[SelectedItem].Name} {ItemCnt}개 판매하였습니다.");
        //        Player.Inventory.Remove(SelectedItem);
        //        TextRPG.player.Gold += (int)(Player.Inventory[SelectedItem].Value * 0.8) * ItemCnt;

        //        Thread.Sleep(2000);
        //    }

        //    Console.Clear();

        //    GameManager.Instance.DisplayHome();
        //}

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
