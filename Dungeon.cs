namespace MiniProject
{
    public class Dungeon
    {
        protected List<Monster> monsters;
        protected Random random;

        public Dungeon()
        {
            monsters = new List<Monster>();
            random = new Random();
        }

        public void InitMonster(Monster monster)
        {
            monsters.Add(monster);
        }

        public MonsterType GetRandomMonsterType()
        {
            double probability = random.NextDouble();
            if (probability < 0.6) return MonsterType.Normal;
            else if (probability < 0.9) return MonsterType.Elite;
            else return MonsterType.Boss;
        }

        public virtual void Start(Player player)
        {
            Console.WriteLine("=================");
            Console.WriteLine("던전에 진입하였습니다.");
            Console.WriteLine("=================");

            foreach (var monster in monsters)
            {
                Battle.Start(player, monster);
            }
        }
    }
    public class Swamp : Dungeon
    {
        public Swamp()
        {
            InitMonster(new Slime(GetRandomMonsterType()));
            InitMonster(new Slime(GetRandomMonsterType()));
            InitMonster(new Slime(GetRandomMonsterType()));
        }

        public override void Start(Player player)
        {
            base.Start(player);
        }
    }

    public class Forest : Dungeon
    {
        public Forest()
        {
            InitMonster(new Goblin(GetRandomMonsterType()));
            InitMonster(new Goblin(GetRandomMonsterType()));
            InitMonster(new Goblin(GetRandomMonsterType()));
        }

        public override void Start(Player player)
        {
            base.Start(player);
        }
    }

    public class Cave : Dungeon
    {
        public Cave()
        {
            InitMonster(new Orc(GetRandomMonsterType()));
            InitMonster(new Orc(GetRandomMonsterType()));
            InitMonster(new Orc(GetRandomMonsterType()));
        }

        public override void Start(Player player)
        {
            base.Start(player);
        }
    }

    public class FallenCastle : Dungeon
    {
        public FallenCastle()
        {
            InitMonster(new FallenKnight(GetRandomMonsterType()));
            InitMonster(new FallenKnight(GetRandomMonsterType()));
            InitMonster(new FallenKnight(GetRandomMonsterType()));
        }

        public override void Start(Player player)
        {
            base.Start(player);
        }
    }
}
