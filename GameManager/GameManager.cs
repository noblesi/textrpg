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

        public static void SetRandomStatus()
        {
            Random random = new Random();

            Player.P_maxhp = random.Next(50, 151);
            Player.P_curhp = Player.P_maxhp;
            Player.P_atk = random.Next(15, 26);
            Player.P_def = random.Next(5, 16);
            Player.P_spd = random.Next(3, 8);
        }

        public static void SetFixedStatus()
        {
            Player.P_curhp = 100;
            Player.P_maxhp = 100;
            Player.P_atk = 20;
            Player.P_def = 10;
            Player.P_spd = 5;
        }

        
    }

    
}
