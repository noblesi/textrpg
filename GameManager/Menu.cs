namespace MiniProject.GameManager
{
    public class Menu
    {
        const int width = 80;
        //public static string[] Menuitems = { "1. 게임시작", "2. 불러오기", "3. 게임종료" };

        public static void DisplayInitialMenu(string[] menuItems, int selectedIndex)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                int padding = (width - menuItems[i].Length) / 2;
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // 선택된 메뉴는 노란색으로 출력
                }
                Console.WriteLine(menuItems[i].PadLeft(padding + menuItems[i].Length));
                Console.WriteLine("\n\n");
                Console.ResetColor(); // 폰트 색상을 초기화
            }
        }

        public static void DisplayStatusMenu(string[] menuItems, int selectedIndex)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                int padding = (width - menuItems[i].Length) / 2;
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // 선택된 메뉴는 노란색으로 출력
                }
                Console.WriteLine(menuItems[i].PadLeft(padding + menuItems[i].Length));
                Console.WriteLine("\t\t");
                Console.ResetColor(); // 폰트 색상을 초기화
            }
        }

        public static void SelectInitialMenu(string[] menuItems)
        {
            Console.CursorVisible = false; // 커서를 숨김
            int selectedIndex = 0; // 선택된 메뉴 인덱스
                                   // 메뉴 항목들

            // 초기 메뉴 출력
            Menu.DisplayInitialMenu(menuItems, selectedIndex);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // 사용자 입력을 읽음

                // 방향키로 커서 이동
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear(); // 콘솔 화면을 지우고
                        HandleMenuSelection(menuItems[selectedIndex]);
                        //Console.WriteLine("선택된 메뉴: " + menuItems[selectedIndex]); // 선택된 메뉴 출력

                        
                        return; // 선택 완료, 프로그램 종료
                }
                Title.TitleAlignment();
                Menu.DisplayInitialMenu(menuItems, selectedIndex);
            }
        }

        public static void SelectStatusMenu(string[] menuItems)
        {
            Console.CursorVisible = false; // 커서를 숨김
            int selectedIndex = 0; // 선택된 메뉴 인덱스
                                   // 메뉴 항목들

            // 초기 메뉴 출력
            Menu.DisplayStatusMenu(menuItems, selectedIndex);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // 사용자 입력을 읽음

                // 방향키로 커서 이동
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear(); // 콘솔 화면을 지우고
                        HandleMenuSelection(menuItems[selectedIndex]);
                        //Console.WriteLine("선택된 메뉴: " + menuItems[selectedIndex]); // 선택된 메뉴 출력

                        return; // 선택 완료, 프로그램 종료
                }
                Menu.DisplayStatusMenu(menuItems, selectedIndex);
            }
        }

        public static void HandleMenuSelection(string selectMenu)
        {
            switch(selectMenu)
            {
                case "1. 게임시작":
                    GamePlay.StartGame();
                    break;
                case "2. 불러오기":
                    break;
                case "3. 게임종료":
                    Environment.Exit(1);
                    return;
            }
        }
    }
}
