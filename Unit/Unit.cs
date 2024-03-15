namespace MiniProject.Unit
{
    public class Unit
    {
        protected string name {  get; set; }
        protected int hp {  get; set; }
        protected int atk {  get; set; }
        protected int def {  get; set; }
        protected int speed {  get; set; }

        public Unit(string name, int hp, int atk, int def, int speed)
        {
            this.name = name;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.speed = speed;
        }

        public virtual void Attack(Unit target)
        {
            int damage = atk - target.def;
            target.hp -= damage;
            Console.WriteLine($"{name}이(가) {target.name}을(를) 공격하여 {damage}의 피해를 입혔습니다.");
        }

        public virtual void DisplayStatus()
        {
            Console.WriteLine($"이름 : {name} | HP : {hp}");
        }
    }
}
