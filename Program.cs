using MiniProject.Data;
using MiniProject.GameManager;

namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonDataHandler.SavePlayerData(GamePlay.User, JsonDataHandler.GetPlayerDataPath());

            JsonDataHandler.LoadPlayerData(JsonDataHandler.GetPlayerDataPath());
            

            #region
            /*Title.InitSetting();

            Title.TitleAlignment();

            Utility.WriteCenterPosition("1. 게임시작");
            Console.WriteLine("\n\n");
            Utility.WriteCenterPosition("2. 불러오기");
            Console.WriteLine("\n\n");
            Utility.WriteCenterPosition("3. 게임종료");

            int MenuSelectIdx = int.Parse(Console.ReadLine());

            switch (MenuSelectIdx)
            {
                case 1:
                    Console.WriteLine("게임이 시작되었습니다.");
                    Console.Clear();
                    GamePlay.StartGame();
                    break;
                case 2:
                    Console.WriteLine("저장된 게임을 불러옵니다.");
                    //Console.Clear();
                    //JsonDataHandler.LoadPlayerData(JsonDataHandler.GetPlayerDataPath());
                    //JsonDataHandler.LoadInventoryData(JsonDataHandler.GetInventoryDataPath());
                    //GamePlay.SelectPlay();
                    break;
                case 3:
                    Console.WriteLine("게임을 종료합니다.");
                    break;
            }*/
            #endregion
        }
    }
}

