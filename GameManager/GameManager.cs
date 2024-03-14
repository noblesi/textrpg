namespace MiniProject.GameManager
{
    public class GameManager
    {
        private static GameManager instance;

        private GameManager() { }

        public static GameManager Instance()
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
        public static void StartGame()
        {
            Console.WriteLine("게임을 시작합니다.");

            InitPlayer();
        }
    }
}
