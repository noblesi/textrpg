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

        public static void SetRandomStatus(Player player)
        {
            Random random = new Random();

            player.hp = random.Next(50, 151);
            player.atk = random.Next(15, 26);
            player.def = random.Next(5, 16);
            player.spd = random.Next(3, 8);
        }

        public static void SetFixedStatus(Player player)
        {
            player.hp = 100;
            player.atk = 20;
            player.def = 10;
            player.spd = 5;
        }
    }

    
}
