using System.Security.Cryptography;

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
        public int hp { get; protected set; }
        public int atk { get; protected set; }
        public int def { get; protected set; }
        public int spd { get; protected set; }
        public double hitrate { get; protected set; }
        public MonsterType type { get; protected set; }

        public Monster(MonsterType type)
        {
            
        }

        public virtual void Attack(Player player)
        {
            int DamageToPlayer;
            if(player.def >= atk)
            {
                DamageToPlayer = 0;
            }
            else
            {
                DamageToPlayer = atk - player.def;
            }

            player.hp -= DamageToPlayer;
        }

        public virtual void CriticalAttack(Player player)
        {
            int DamageToPlayer;
            if (player.def >= atk)
            {
                DamageToPlayer = 0;
            }
            else
            {
                DamageToPlayer = atk - player.def;
            }

            player.hp -= DamageToPlayer * 2;

        }
    }

    public class Slime : Monster
    {
        public Slime(MonsterType type) : base(type)
        {
            switch(type)
            {
                case MonsterType.Normal:
                    hp = 15;
                    atk = 3;
                    def = -5;
                    spd = -10;
                    hitrate = 0.3;
                    break;
                case MonsterType.Elite:
                    hp = 25;
                    atk = 5;
                    def = -2;
                    spd = -5;
                    hitrate = 0.4;
                    break;
                case MonsterType.Boss:
                    hp = 35;
                    atk = 8;
                    def = 3;
                    spd = 0;
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
                    hp = 40;
                    atk = 5;
                    def = 3;
                    spd = 3;
                    hitrate = 0.4;
                    break;
                case MonsterType.Elite:
                    hp = 60;
                    atk = 8;
                    def = 5;
                    spd = 6;
                    hitrate = 0.5;
                    break;
                case MonsterType.Boss:
                    hp = 90;
                    atk = 12;
                    def = 7;
                    spd = 9;
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
                    hp = 100;
                    atk = 25;
                    def = -10;
                    spd = -5;
                    hitrate = 0.4;
                    break;
                case MonsterType.Elite:
                    hp = 150;
                    atk = 35;
                    def = -3;
                    spd = 0;
                    hitrate = 0.5;
                    break;
                case MonsterType.Boss:
                    hp = 180;
                    atk = 40;
                    def = 3;
                    spd = 5;
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
                    hp = 200;
                    atk = 30;
                    def = 5;
                    spd = 0;
                    hitrate = 0.5;
                    break;
                case MonsterType.Elite:
                    hp = 250;
                    atk = 40;
                    def = 10;
                    spd = 5;
                    hitrate = 0.6;
                    break;
                case MonsterType.Boss:
                    hp = 300;
                    atk = 55;
                    def = 15;
                    spd = 10;
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
                Console.WriteLine("공격에 실패하였습니다.");
            }
        }
    }
}
