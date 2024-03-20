using MiniProject.GameManager;

namespace MiniProject
{
    public class Battle
    {
        public static void Start(Player player, Monster monster)
        {
            Console.WriteLine($"{monster.name}와(과) 조우했다.");

            bool playerAttackFirst = Player.P_totalspd > monster.M_spd;

            Console.WriteLine("전투가 시작됩니다.");

            Console.WriteLine("=================");
            Console.WriteLine("=================");

            while (true)
            {
                if (playerAttackFirst)
                {
                    PlayerTurn(player, monster);
                    playerAttackFirst = !playerAttackFirst;
                }
                else
                {
                    MonsterTurn(player, monster);
                    playerAttackFirst = !playerAttackFirst;
                }
                

                if (Player.P_curhp <= 0)
                {
                    Console.WriteLine("=================");
                    Console.WriteLine("전투에서 패배하였습니다.");
                    Console.WriteLine("소지금의 30%를 잃고 마을로 돌아갑니다.");
                    Console.WriteLine("=================");

                    Player.gold = (int)(Player.gold * 0.7);

                    GamePlay.SelectPlay();
                }

                else if (monster.M_hp <= 0)
                {
                    Console.WriteLine("=================");
                    Console.WriteLine("전투에서 승리하였습니다.");
                    Console.WriteLine("골드를 획득합니다!");


                    Player.gold += 100;

                    Console.WriteLine("무기 경험치를 획득합니다.");
                    Console.WriteLine("=================");

                    //GetExp(monster.type);

                    Console.WriteLine("=================");
                    Console.Write("1. 마을로 귀환\t2. 던전입구로 귀환");
                    Console.WriteLine("=================");

                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Clear();
                            GamePlay.SelectPlay();
                            break;
                        case 2:
                            Console.Clear();
                            GamePlay.DungeonSelect();
                            break;
                    }
                }
            }
        }

        public static void PlayerTurn(Player player, Monster monster)
        {

            Console.WriteLine("당신의 차례입니다.");
            Console.WriteLine("1. 공격\t2. 아이템사용");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (Player.isBuffed)
                    {
                        Player.P_baseatk = Player.P_totalatk;
                        Player.isBuffed = !Player.isBuffed;
                    }
                    player.Attack(monster);
                    
                    break;
                case 2:
                    player.ItemUseInBattle();
                    break;
            }

            Console.WriteLine($"{player.name}의 현재체력 : {((Player.P_curhp > 0) ? Player.P_curhp : 0)}");
            Console.WriteLine($"{monster.name}의 현재체력 : {((monster.M_hp > 0) ? monster.M_hp : 0)}");
        }

        public static void MonsterTurn(Player player, Monster monster)
        {
            Console.WriteLine($"{monster.name}의 차례입니다.");
            monster.Attack();

            Console.WriteLine($"{player.name}의 현재체력 : {((Player.P_curhp > 0) ? Player.P_curhp : 0)}");
            Console.WriteLine($"{monster.name}의 현재체력 : {((monster.M_hp > 0) ? monster.M_hp : 0)}");
        }
    }
}
