using MiniProject.Data;
using MiniProject.GameManager;

namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
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
            #endregion
            //string[] menuItems = { "1. 게임시작", "2. 불러오기", "3. 게임종료" };

            GameManager.Title.InitSetting();

            GameManager.Title.TitleAlignment();



            Utility.WriteCenterPosition("1. 게임시작");
            Console.WriteLine("\n\n");
            Utility.WriteCenterPosition("2. 불러오기");
            Console.WriteLine("\n\n");
            Utility.WriteCenterPosition("3. 게임종료");

            int MenuSelectIdx = int.Parse(Console.ReadLine());

            switch(MenuSelectIdx)
            {
                case 1:
                    Console.WriteLine("게임이 시작되었습니다.");
                    Console.Clear();
                    GamePlay.StartGame();
                    break;
                case 2:
                    Console.WriteLine("저장된 게임을 불러옵니다.");
                    break;
                case 3:
                    Console.WriteLine("게임을 종료합니다.");
                    break;
            }
        }
    }
}

