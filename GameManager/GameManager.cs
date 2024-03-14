using MiniProject.Unit;

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
    }
}
