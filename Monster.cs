using System.Numerics;

namespace MiniProject
{
    public enum MonsterType
    {
        Normal,
        Elite,
        Boss
    }
    public class Monster
    {
        public string name { get; protected set; }
        public int M_curhp {  get;  set; }
        public int M_hp { get; protected set; }
        public int M_atk { get; protected set; }
        public int M_def { get; protected set; }
        public int M_spd { get; protected set; }
        public double hitrate { get; protected set; }
        public MonsterType type { get; protected set; }

        public Monster(MonsterType type)
        {
            
        }

        public virtual void Attack(Player player)
        {
            int DamageToPlayer;
            if(TextRPG.player.Def >= M_atk)
            {
                DamageToPlayer = 0;
                Console.SetCursorPosition(50, 11);
                Console.WriteLine($"데미지를 {DamageToPlayer}만큼 입혔습니다.");
            }
            else
            {
                DamageToPlayer = M_atk - TextRPG.player.Def;
                Console.SetCursorPosition(50, 11);
                TextRPG.player.CurrentHp -= DamageToPlayer;
                Console.WriteLine($"데미지를 {DamageToPlayer}만큼 입혔습니다.");
            }

            Console.SetCursorPosition(3, 6);
            Console.WriteLine(new string(' ', Console.WindowWidth-60));
            Console.SetCursorPosition(3, 6);
            Console.WriteLine($"HP : {((player.CurrentHp > 0) ? player.CurrentHp : 0)} / {player.Hp}");

            
        }

        public virtual void CriticalAttack(Player player)
        {
            int DamageToPlayer;
            if (player.Def >= M_atk)
            {
                DamageToPlayer = 0;
            }
            else
            {
                DamageToPlayer = M_atk - player.Def;
            }

            player.CurrentHp -= DamageToPlayer * 2;

        }
    }

    public class Slime : Monster
    {
        public Slime(MonsterType type) : base(type)
        {
            switch(type)
            {
                case MonsterType.Normal:
                    name = "초록슬라임";
                    M_hp = 15;
                    M_curhp = M_hp;
                    M_atk = 3;
                    M_def = -5;
                    M_spd = -10;
                    hitrate = 0.3;
                    break;
                case MonsterType.Elite:
                    name = "파란슬라임";
                    M_hp = 25;
                    M_curhp = M_hp;
                    M_atk = 5;
                    M_def = -2;
                    M_spd = -5;
                    hitrate = 0.4;
                    break;
                case MonsterType.Boss:
                    name = "붉은슬라임";
                    M_hp = 35;
                    M_curhp = M_hp;
                    M_atk = 8;
                    M_def = 3;
                    M_spd = 0;
                    hitrate = 0.6;
                    break;
            }
        }

        public override void Attack(Player player)
        {
            double RandomHitRate = Utility.GetRandomDoubleNumber();

            if (RandomHitRate > hitrate)
            {
                base.Attack(player);
            }
            else
            {
                Console.SetCursorPosition(50, 11);
                Console.WriteLine("공격에 실패하였습니다.");
            }
        }
    }

    public class Goblin : Monster
    {
        public Goblin(MonsterType type) : base(type)
        {
            switch (type)
            {
                case MonsterType.Normal:
                    name = "고블린전사";
                    M_hp = 40;
                    M_curhp = M_hp;
                    M_atk = 5;
                    M_def = 3;
                    M_spd = 3;
                    hitrate = 0.4;
                    break;
                case MonsterType.Elite:
                    name = "고블린투척병";
                    M_hp = 60;
                    M_curhp = M_hp;
                    M_atk = 8;
                    M_def = 5;
                    M_spd = 6;
                    hitrate = 0.5;
                    break;
                case MonsterType.Boss:
                    name = "고블린족장";
                    M_hp = 90;
                    M_curhp = M_hp;
                    M_atk = 12;
                    M_def = 7;
                    M_spd = 9;
                    hitrate = 0.7;
                    break;
            }
        }

        public override void Attack(Player player)
        {
            double RandomHitRate = Utility.GetRandomDoubleNumber();
            double RandomCritRate = Utility.GetRandomDoubleNumber();
            double CritRate = 0.05;

            if(RandomHitRate <= hitrate)
            {
                if(RandomCritRate <= CritRate)
                {
                    base.CriticalAttack(player);
                }
                else
                {
                    base.Attack(player);
                }
                
            }
            else
            {
                Console.SetCursorPosition(50, 11);
                Console.WriteLine("공격에 실패하였습니다.");
            }
        }
    }

    public class Orc : Monster
    {
        public Orc(MonsterType type) : base(type)
        {
            switch (type)
            {
                case MonsterType.Normal:
                    name = "오크전사";
                    M_hp = 100;
                    M_curhp = M_hp;
                    M_atk = 25;
                    M_def = -10;
                    M_spd = -5;
                    hitrate = 0.4;
                    break;
                case MonsterType.Elite:
                    name = "오크부족장";
                    M_hp = 150;
                    M_curhp = M_hp;
                    M_atk = 35;
                    M_def = -3;
                    M_spd = 0;
                    hitrate = 0.5;
                    break;
                case MonsterType.Boss:
                    name = "오크족장";
                    M_hp = 180;
                    M_curhp = M_hp;
                    M_atk = 40;
                    M_def = 3;
                    M_spd = 5;
                    hitrate = 0.7;
                    break;
            }
        }

        public override void Attack(Player player)
        {
            double RandomHitRate = Utility.GetRandomDoubleNumber();
            double RandomCritRate = Utility.GetRandomDoubleNumber();
            double CritRate = 0.25;

            if (RandomHitRate <= hitrate)
            {
                if (RandomCritRate <= CritRate)
                {
                    base.CriticalAttack(player);
                }
                else
                {
                    base.Attack(player);
                }

            }
            else
            {
                Console.SetCursorPosition(50, 11);
                Console.WriteLine("공격에 실패하였습니다.");
            }
        }
    }

    public class FallenKnight : Monster
    {
        public FallenKnight(MonsterType type) : base(type)
        {
            switch (type)
            {
                case MonsterType.Normal:
                    name = "타락한보병견습";
                    M_hp = 200;
                    M_curhp = M_hp;
                    M_atk = 30;
                    M_def = 5;
                    M_spd = 0;
                    hitrate = 0.5;
                    break;
                case MonsterType.Elite:
                    name = "타락한보병";
                    M_hp = 250;
                    M_curhp = M_hp;
                    M_atk = 40;
                    M_def = 10;
                    M_spd = 5;
                    hitrate = 0.6;
                    break;
                case MonsterType.Boss:
                    name = "타락한기사단장";
                    M_hp = 300;
                    M_curhp = M_hp;
                    M_atk = 55;
                    M_def = 15;
                    M_spd = 10;
                    hitrate = 0.8;
                    break;
            }
        }

        public override void Attack(Player player)
        {
            double RandomHitRate = Utility.GetRandomDoubleNumber();
            double RandomCritRate = Utility.GetRandomDoubleNumber();
            double CritRate = 0.35;

            if (RandomHitRate <= hitrate)
            {
                if (RandomCritRate <= CritRate)
                {
                    base.CriticalAttack(player);
                }
                else
                {
                    base.Attack(player);
                }

            }
            else
            {
                Console.SetCursorPosition(50, 11);
                Console.WriteLine("공격에 실패하였습니다.");
            }
        }
    }
}
