using MiniProject.GameManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MiniProject.ItemData
{
    public static class Shop
    {
        public static Dictionary<int, Item> ShopItemList = new Dictionary<int, Item>();
        public static void InitializeShop()
        {
            Item HealingPotion_S = new Potion("소형 체력물약", 50, "사용 시 체력 20을 회복합니다.", 3, 3);
            Item HealingPotion_M = new Potion("중형 체력물약", 100, "사용 시 체력 40을 회복합니다.", 3, 4);
            Item HealingPotion_L = new Potion("대형 체력물약", 200, "사용 시 체력 80을 회복합니다.", 3, 5);
            Item BuffPotion_ATK = new Potion("공격력 증가물약", 300, "사용 시 2턴 동안 공격력이 10 증가합니다.", 4, 6);
            Item BuffPotion_DEF = new Potion("방어력 증가물약", 300, "사용 시 2턴 동안 방어력이 5 증가합니다.", 4, 7);
            Item Scroll_EXIT = new Potion("강제 탈출 스크롤", 150, "반드시 전투에서 도망칠 수 있습니다.", 5, 8);

            ShopItemList.Add(3, HealingPotion_S);
            ShopItemList.Add(4, HealingPotion_M);
            ShopItemList.Add(5, HealingPotion_L);
            ShopItemList.Add(6, BuffPotion_ATK);
            ShopItemList.Add(7, BuffPotion_DEF);
            ShopItemList.Add(8, Scroll_EXIT);
        }

        public static void DisplayShopItem()
        {
            Console.WriteLine("===상점 아이템 목록===");

            foreach(var item in ShopItemList)
            {
                Console.WriteLine($"{item.Value.Name} || 가격 : {item.Value.Value} || {item.Value.Description}");
            }
            Console.WriteLine("\n");

            SelectShopMenu();
        }
        public static void BuyItem()
        {

        }

        public static void SellItem()
        {

        }

        public static void SelectShopMenu()
        {
            Thread.Sleep(1000);

            Console.WriteLine("1. 아이템 구매\t2. 아이템 판매\t3. 상점 나가기");
            int ShopSelectIdx = int.Parse(Console.ReadLine());

            switch(ShopSelectIdx)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Console.Clear();
                    GamePlay.SelectPlay();
                    break;
            }
        }
    }
}
