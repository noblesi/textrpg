
namespace MiniProject
{
    
    public class Battle
    {
        public static void Start(Player player, Monster monster)
        {
            bool playerAttackFirst = TextRPG.player.Spd > monster.M_spd;
            
            while (true)
            {
                Console.Clear();
                UI.DisplayGameUI();
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

                if (monster.M_curhp <= 0)
                {
                    Random rand = new Random();
                    int RandomGold = rand.Next(50, 101);
                    TextRPG.player.Gold += RandomGold;
                    TextRPG.GetExp(monster.type);

                    Console.SetCursorPosition(1, 24);
                    Console.WriteLine(new string(' ', Console.WindowWidth - 10));
                    Console.SetCursorPosition(1, 25);
                    Console.WriteLine(new string(' ', Console.WindowWidth - 10));

                    Console.SetCursorPosition(1, 24);
                    Utility.TextAlignment("전투에서 승리하였습니다.");
                    Console.SetCursorPosition(1, 30);
                    Utility.TextAlignment($"골드를 획득합니다! (+{RandomGold})");
                    Console.SetCursorPosition(1, 31);
                    Utility.TextAlignment($"경험치를 획득합니다. ({player.Exp} / {player.MaxExp})");

                    Thread.Sleep(3000);

                    Console.Clear();

                    GameManager.Instance.DisplayHome();
                    break;
                }

                if (TextRPG.player.CurrentHp <= 0)
                {
                    Console.SetCursorPosition(1, 30);
                    Utility.TextAlignment("전투에서 패배하였습니다.");
                    Console.SetCursorPosition(1, 31);
                    Console.WriteLine("소지금의 30%를 잃고 마을로 돌아갑니다.");

                    TextRPG.player.Gold = (int)(player.Gold * 0.7);

                    GameManager.Instance.DisplayHome();
                    break;
                }
            }
        }

        public static void PlayerTurn(Player player, Monster monster)
        {
            //Console.SetCursorPosition(3, 5);
            //Console.WriteLine($"{player.Name}의 정보");
            //Console.SetCursorPosition(3, 6);
            //Console.WriteLine($"HP : {((player.CurrentHp > 0) ? player.CurrentHp : 0)} / {player.Hp}");
            //Console.SetCursorPosition(3, 7);
            //Console.WriteLine($"ATK : {player.Atk}");
            //Console.SetCursorPosition(3, 8);
            //Console.WriteLine($"DEF : {player.Def}");
            //Console.SetCursorPosition(3, 9);
            //Console.WriteLine($"SPD : {player.Spd}");

            //Console.SetCursorPosition(50, 5);
            //Console.WriteLine($"{monster.name}의 정보");
            //Console.SetCursorPosition(50, 6);
            //Console.WriteLine($"HP : {((monster.M_curhp > 0) ? monster.M_curhp : 0)} / {monster.M_hp}");
            //Console.SetCursorPosition(50, 7);
            //Console.WriteLine($"ATK : {monster.M_atk}");
            //Console.SetCursorPosition(50, 8);
            //Console.WriteLine($"DEF : {monster.M_def}");
            //Console.SetCursorPosition(50, 9);
            //Console.WriteLine($"SPD : {monster.M_spd}");

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
                    TextRPG.ItemUseInBattle();
                    break;
            }
        }

        public static void MonsterTurn(Player player, Monster monster)
        {
            //Console.SetCursorPosition(3, 5);
            //Console.WriteLine($"{player.Name}의 정보");
            //Console.SetCursorPosition(3, 6);
            //Console.WriteLine($"HP : {((player.CurrentHp > 0) ? player.CurrentHp : 0)} / {player.Hp}");
            //Console.SetCursorPosition(3, 7);
            //Console.WriteLine($"ATK : {player.Atk}");
            //Console.SetCursorPosition(3, 8);
            //Console.WriteLine($"DEF : {player.Def}");
            //Console.SetCursorPosition(3, 9);
            //Console.WriteLine($"SPD : {player.Spd}");

            //Console.SetCursorPosition(50, 5);
            //Console.WriteLine($"{monster.name}의 정보");
            //Console.SetCursorPosition(50, 6);
            //Console.WriteLine($"HP : {((monster.M_hp > 0) ? monster.M_hp : 0)} / {monster.M_hp}");
            //Console.SetCursorPosition(50, 7);
            //Console.WriteLine($"ATK : {monster.M_atk}");
            //Console.SetCursorPosition(50, 8);
            //Console.WriteLine($"DEF : {monster.M_def}");
            //Console.SetCursorPosition(50, 9);
            //Console.WriteLine($"SPD : {monster.M_spd}");

            monster.Attack(player);
        }
    }
}
