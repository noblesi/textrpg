
namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] menuItems = { "1. 게임시작", "2. 불러오기", "3. 게임종료" };
            GameManager.Title.InitSetting();

            GameManager.Title.TitleAlignment();
 
            GameManager.Menu.SelectMenu(menuItems);
        }
    }
}

