using MiniProject.Data;

namespace MiniProject.GameManager
{

    public class GamePlay
    {


        public static Player User;
        public static void StartGame()
        {
            Console.WriteLine("게임을 시작합니다.");

            Thread.Sleep(1000);

            Console.Write("당신의 이름은 ? ");

            string playerName = Console.ReadLine();

            User = new Player(playerName);

            Shop.InitializeShop();

            Console.WriteLine($"유저가 생성되었습니다. 이름 : {playerName}");

            Thread.Sleep(1000);

            Console.Clear();
            
            Console.WriteLine("스탯의 유형을 지정하세요.");
            Console.WriteLine("=================");
            Console.WriteLine("1. 기본스탯\n\n");
            Console.WriteLine("2. 랜덤스탯");
            Console.WriteLine("=================");
            SelectStatusMenu();
        }

        public static void SelectPlay()
        {
            Console.WriteLine("다음 행동을 선택하세요.");

            Console.WriteLine("=================");
            Console.WriteLine("1. 던전 입장\n");
            Console.WriteLine("2. 인벤토리 열기\n");
            Console.WriteLine("3. 스테이터스 확인\n");
            Console.WriteLine("4. 상점 입장");
            //Console.WriteLine("5. 저장하기");
            Console.WriteLine("=================");

            SelectPlayMenu();
        }

        public static void DungeonSelect()
        {
            Console.WriteLine("어느 던전에 들어가시겠습니까? (-1 : 마을로 돌아가기)");

            Console.WriteLine("=================");
            Console.WriteLine("1. 늪지대\n");
            Console.WriteLine("2. 숲\n");
            Console.WriteLine("3. 동굴\n");
            Console.WriteLine("4. 고성");
            Console.WriteLine("=================");

            SelectDungeonMenu();
        }

        public static void SelectDungeonMenu()
        {
            int DungeonSelectIdx = int.Parse(Console.ReadLine());

            switch(DungeonSelectIdx)
            {
                case -1:
                    Console.Clear();
                    SelectPlay();
                    break;
                case 1:
                    Console.Clear();
                    Swamp swamp = new Swamp();
                    swamp.Start(User);
                    break;
                case 2:
                    Console.Clear();
                    Forest forest = new Forest();
                    forest.Start(User);
                    break;
                case 3:
                    Console.Clear();
                    Cave cave = new Cave();
                    cave.Start(User);
                    break;
                case 4:
                    Console.Clear();
                    FallenCastle fallenCastle = new FallenCastle();
                    fallenCastle.Start(User);
                    break;
            }
        }

        public static void SelectPlayMenu()
        {
            int PlaySelectIdx = int.Parse(Console.ReadLine());

            switch (PlaySelectIdx)
            {
                case 1:
                    Console.Clear();
                    DungeonSelect();
                    break;
                case 2:
                    Console.Clear();
                    Player.DisplayUserInventory(User);
                    break;
                case 3:
                    Console.Clear();
                    Player.DisplayUserStatus(User);
                    break;
                case 4:
                    Console.Clear();
                    Shop.DisplayShopItem();
                    break;
                //case 5:
                //    Console.Clear();
                //    JsonDataHandler.SavePlayerData(User, JsonDataHandler.GetPlayerDataPath());
                //    JsonDataHandler.SaveInventoryData(Player.Inventory, JsonDataHandler.GetInventoryDataPath());
                //    break;
            }
        }

        public static void SelectStatusMenu()
        {
            int StatusSelectionIdx = int.Parse(Console.ReadLine());

            switch (StatusSelectionIdx)
            {
                case 1:
                    Console.WriteLine("기본스탯을 선택하였습니다.");
                    Player.SetFixedStatus();

                    Thread.Sleep(1000);
                    Console.Clear();
                    SelectPlay();
                    break;
                case 2:
                    Console.WriteLine("랜덤스탯을 선택하였습니다.");
                    Player.SetRandomStatus();

                    Thread.Sleep(1000);
                    Console.Clear();
                    SelectPlay();
                    break;
            }
        }
    }
}
