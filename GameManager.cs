namespace MiniProject
{
    public class GameManager
    {
        private static GameManager instance;
        //private GameState currentState;
        //private Player player;
        //private Item item;


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
            UI.DisplayGameUI();
            UI.DisplayGameTitle();

            Console.SetCursorPosition(9, 24);
            Console.WriteLine("[1] 게임시작");
            Console.SetCursorPosition(42, 24);
            Console.WriteLine("[2] 불러오기");
            Console.SetCursorPosition(75, 24); //75
            Console.WriteLine("[3] 게임종료");

            Console.SetCursorPosition(9, 30);
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
                    DisplayHome();
                    break;
                case 3:
                    break;
            }
        }

        public void DisplayHome()
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(3, 24);
            Console.WriteLine("[1] 인벤토리\t[2] 스테이터스\t[3] 상점\t[4] 던전\t[5] 게임저장\t[6] 게임종료");

            Console.SetCursorPosition(50, 30);
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
                TextRPG.DisplayShopItem();
            }
            else if(input == 4)
            {
                Thread.Sleep(300);
                TextRPG.EnterDungeon();
            }
            else if (input == 5)
            {
                Thread.Sleep(300);
                Utility.SaveGameData();
                DisplayHome();
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

        
    }
}
