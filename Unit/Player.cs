using MiniProject.ItemData;
using System.Collections.Generic;

namespace MiniProject.Unit
{
    public class Player : Unit
    {
        public int SwordMastery {  get; set; }
        public int SpearMastery { get; set; }
        public int AxeMastery { get; set; }
        public Dictionary<string, Item> Inventory {  get; set; }
        public List<string> Type = new List<string> { "SWORD", "SPEAR", "AXE", "POTION" };
        public Player(string name, int hp, int atk, int def, int speed) : base(name, hp, atk, def, speed)
        {
            SwordMastery = 0;
            SpearMastery = 0;
            AxeMastery = 0;
            Inventory = new Dictionary<string, Item>();
        }

        public override void Attack(Unit target)
        {
            base.Attack(target);
            Console.WriteLine("**");
        }

        public void AddItem(Item item)
        {
            Inventory.Add(Type[item.Id-1], item);
        }


        public void RemoveItem(Item item)
        {
            

        }
    }
}
