using MiniProject.Data;
using MiniProject.ItemData;
using MiniProject.Unit;

namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuItems = { "1. 게임시작", "2. 불러오기", "3. 게임종료" };

            GameManager.Title.InitSetting();

            GameManager.Title.TitleAlignment();

            GameManager.Menu.SelectInitialMenu(menuData.InitialMenu);

            //Player player = new Player("John", 100, 20, 10, 5);
            //player.AddItem(new Item("낡은 검", 10, 0, 3, 100, 1));
            //player.AddItem(new Item("낡은 창", 15, 0, 0, 100, 2));
            //player.AddItem(new Item("낡은 도끼", 20, 0, -3, 100, 3));


            //string filepath = JsonDataHandler.GetFilePath();

            //JsonDataHandler.SaveInventoryData(player.Inventory, filepath);

            //Dictionary<string, Item> loadedPlayer = JsonDataHandler.LoadInventoryData(filepath);
            //if (loadedPlayer != null)
            //{
            //    Console.WriteLine("인벤토리");
            //    foreach (var item in loadedPlayer)
            //    {
            //        Console.WriteLine($"{item.Key} | {item.Value.Name}");
            //    }
            //}
        }
    }
}

