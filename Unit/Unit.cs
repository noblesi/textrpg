namespace MiniProject.Unit
{
    class Unit
    {
        string name {  get; set; }
        int hp {  get; set; }
        int atk {  get; set; }
        int def {  get; set; }
        int speed {  get; set; }

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

        }
    }
}
