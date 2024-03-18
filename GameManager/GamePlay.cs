using MiniProject.Data;
using MiniProject.ItemData;

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
            Console.WriteLine("1. 기본스탯\n\n2. 랜덤스탯");

            SelectStatusMenu();
        }

        public static void SelectPlay()
        {
            Console.WriteLine("다음 행동을 선택하세요.");

            Console.WriteLine("1. 던전 입장");
            Console.WriteLine("2. 인벤토리 열기");
            Console.WriteLine("3. 스테이터스 확인");
            Console.WriteLine("4. 상점 입장");

            SelectPlayMenu();
        }

        public static void DungeonSelect()
        {

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
            }
        }

        public static void SelectStatusMenu()
        {
            int StatusSelectionIdx = int.Parse(Console.ReadLine());

            switch (StatusSelectionIdx)
            {
                case 1:
                    Console.WriteLine("기본스탯을 선택하였습니다.");
                    GameManager.SetFixedStatus(User);

                    Thread.Sleep(2000);
                    Console.Clear();
                    SelectPlay();
                    break;
                case 2:
                    Console.WriteLine("랜덤스탯을 선택하였습니다.");
                    GameManager.SetRandomStatus(User);

                    Thread.Sleep(2000);
                    Console.Clear();
                    SelectPlay();
                    break;
            }
        }
    }
}
