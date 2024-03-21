
namespace MiniProject
{
    public class Battle
    {
        public static void Start(Player player, Monster monster)
        {
            bool playerAttackFirst = TextRPG.player.Spd > monster.M_spd;
            Console.Clear();
            UI.DisplayGameUI();
            while (true)
            {
                Console.SetCursorPosition(1, 2);
                Utility.TextAlignment($"{monster.name}와(과) 조우했다.");

                Console.SetCursorPosition(3, 5);
                Console.WriteLine($"{player.Name}의 정보");
                Console.SetCursorPosition(3, 6);
                
                
                Console.WriteLine($"HP : {((player.CurrentHp > 0) ? player.CurrentHp : 0)} / {player.Hp}");
                Console.SetCursorPosition(3, 7);
                Console.WriteLine($"ATK : {player.Atk}");
                Console.SetCursorPosition(3, 8);
                Console.WriteLine($"DEF : {player.Def}");
                Console.SetCursorPosition(3, 9);
                Console.WriteLine($"SPD : {player.Spd}");

                Console.SetCursorPosition(50, 5);
                Console.WriteLine($"{monster.name}의 정보");
                Console.SetCursorPosition(50, 6);
                Console.WriteLine($"HP : {((monster.M_curhp > 0) ? monster.M_curhp : 0)} / {monster.M_hp}");
                Console.SetCursorPosition(50, 7);
                Console.WriteLine($"ATK : {monster.M_atk}");
                Console.SetCursorPosition(50, 8);
                Console.WriteLine($"DEF : {monster.M_def}");
                Console.SetCursorPosition(50, 9);
                Console.WriteLine($"SPD : {monster.M_spd}");

                if (playerAttackFirst)
                {
                    PlayerTurn(player, monster);
                    playerAttackFirst = !playerAttackFirst;

                    Thread.Sleep(3000);
                }
                else
                {
                    MonsterTurn(player, monster);
                    playerAttackFirst = !playerAttackFirst;

                    Thread.Sleep(3000);
                }
            }
        }

        public static void PlayerTurn(Player player, Monster monster)
        {
            Console.SetCursorPosition(3, 5);
            Console.WriteLine($"{player.Name}의 정보");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine($"HP : {((player.CurrentHp > 0) ? player.CurrentHp : 0)} / {player.Hp}");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine($"ATK : {player.Atk}");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine($"DEF : {player.Def}");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine($"SPD : {player.Spd}");

            Console.SetCursorPosition(50, 5);
            Console.WriteLine($"{monster.name}의 정보");
            Console.SetCursorPosition(50, 6);
            Console.WriteLine($"HP : {((monster.M_curhp > 0) ? monster.M_curhp : 0)} / {monster.M_hp}");
            Console.SetCursorPosition(50, 7);
            Console.WriteLine($"ATK : {monster.M_atk}");
            Console.SetCursorPosition(50, 8);
            Console.WriteLine($"DEF : {monster.M_def}");
            Console.SetCursorPosition(50, 9);
            Console.WriteLine($"SPD : {monster.M_spd}");

            Console.SetCursorPosition(1, 24);
            Utility.TextAlignment("당신의 차례입니다.");
            Console.SetCursorPosition(1, 25);
            Utility.TextAlignment("[1] 공격 / [2] 아이템사용");

            Console.SetCursorPosition(50, 30);
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    player.Attack(monster);
                    break;
                case 2:
                    player.ItemUseInBattle();
                    break;
            }

            
        }

        public static void MonsterTurn(Player player, Monster monster)
        {
            Console.SetCursorPosition(3, 5);
            Console.WriteLine($"{player.Name}의 정보");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine($"HP : {((player.CurrentHp > 0) ? player.CurrentHp : 0)} / {player.Hp}");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine($"ATK : {player.Atk}");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine($"DEF : {player.Def}");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine($"SPD : {player.Spd}");

            Console.SetCursorPosition(50, 5);
            Console.WriteLine($"{monster.name}의 정보");
            Console.SetCursorPosition(50, 6);
            Console.WriteLine($"HP : {((monster.M_hp > 0) ? monster.M_hp : 0)} / {monster.M_hp}");
            Console.SetCursorPosition(50, 7);
            Console.WriteLine($"ATK : {monster.M_atk}");
            Console.SetCursorPosition(50, 8);
            Console.WriteLine($"DEF : {monster.M_def}");
            Console.SetCursorPosition(50, 9);
            Console.WriteLine($"SPD : {monster.M_spd}");

            monster.Attack(player);
        }
    }
}
