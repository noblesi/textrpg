namespace MiniProject
{
    public class GameManager
    {
        private static GameManager instance;
        private GameState currentState;
        private Player player;
        private Item item;


        public static GameManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void StartGame()
        {
            Title.InitSetting();
            Title.TitleAlignment();

            Utility.WriteCenterPosition("[1] 게임시작");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[2] 불러오기");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[3] 게임종료");

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Thread.Sleep(500);
                    TextRPG.InitStatus();
                    TextRPG.InitSetting();
                    break;
                case 2:
                    Console.Clear();
                    Thread.Sleep(500);
                    Utility.LoadGameData();
                    break;
                case 3:
                    break;
            }
        }

        public void DisplayHome()
        {
            Utility.WriteCenterPosition("[1] 인벤토리");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[2] 스테이터스");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[3] 상점");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[4] 던전");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[5] 게임저장");
            Console.WriteLine("\n");
            Utility.WriteCenterPosition("[6] 게임종료");

            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Thread.Sleep(300);
                Console.Clear();
                TextRPG.DisplayUserInventory();
            }
            else if (input == 2)
            {
                Thread.Sleep(300);
                Console.Clear();
                TextRPG.DisplayUserStatus();
            }
            else if (input == 3)
            {
                Thread.Sleep(300);
                Console.Clear();
                Shop.DisplayShopItem();
            }
            else if(input == 4)
            {
                Utility.WriteCenterPosition("던전 입구");
                Thread.Sleep(300);
                //TextRPG.EnterDungeon();
            }
            else if (input == 5)
            {
                Thread.Sleep(300);
                Utility.SaveGameData();
            }
            else if(input == 6)
            {
                Thread.Sleep(300);
                Environment.Exit(0);
            }
        }

        

            

            

            

            

        public void EndGame()
        {
            
        }

        public GameState GetCurrentGameState()
        {
            return currentState;
        }
    }
}
