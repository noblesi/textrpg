using MiniProject.Data;

namespace MiniProject.GameManager
{
    internal class GamePlay
    {
        public static void StartGame()
        {
            Console.WriteLine("게임을 시작합니다.");

            Thread.Sleep(1000);

            Console.Write("당신의 이름은 ? ");

            string playerName = Console.ReadLine();

            Thread.Sleep(1000);

            Console.WriteLine("기본스탯으로 진행하시겠습니까 아니면 랜덤스탯으로 진행하겠습니까?");
            Menu.SelectStatusMenu(menuData.StatusMenu);
        }
    }
}
