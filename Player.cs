namespace MiniProject
{
    public class Player
    {
        public string StatusType {  get; set; }
        public string Name { get; set; }
        public int Hp {  get; set; }
        public int CurrentHp {  get; set; }
        public int Atk {  get; set; }
        public int Def {  get; set; }
        public int Spd {  get; set; }
        public int Gold { get; set; }
        public int Exp {  get; set; }
        public int MaxExp {  get; set; }
        public static Dictionary<int, Item> Inventory { get; set; }

        
        public Player()
        {

        }

        public Player(string name, string type, int hp, int atk, int def, int spd, int gold, int exp, int maxExp)
        {
            Name = name;
            StatusType = type;
            CurrentHp = hp;
            Hp = CurrentHp;
            Atk = atk;
            Def = def;
            Spd = spd;
            Gold = gold;
            Exp = exp;
            MaxExp = maxExp;
        }

        public void Attack(Monster monster)
        {
            int DamageToMonster;

            if(monster.M_def >= Atk)
            {
                DamageToMonster = 0;
                Console.SetCursorPosition(3, 11);
                Console.WriteLine($"데미지를 {DamageToMonster}만큼 입혔습니다.");
            }
            else
            {
                DamageToMonster = Atk - monster.M_def;
                monster.M_curhp -= DamageToMonster;
                Console.SetCursorPosition(3, 11);
                Console.WriteLine($"데미지를 {DamageToMonster}만큼 입혔습니다.");
            }
            Console.SetCursorPosition(50, 6);
            Console.WriteLine(new string(' ', Console.WindowWidth-60));
            Console.SetCursorPosition(50, 6);
            Console.WriteLine($"HP : {((monster.M_curhp > 0) ? monster.M_curhp : 0)} / {monster.M_hp}");
        }
    }
}
