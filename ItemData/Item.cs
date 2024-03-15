using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.ItemData
{
    public class Item
    {
        public string Name { get; set; }
        public int AddAtk {  get; set; }
        public int AddDef {  get; set; }
        public int AddSpd {  get; set; }
        public int Value {  get; set; }
        public int Quantity {  get; set; }
        public int Id {  get; set; }
        

        public Item(string name, int addAtk, int addDef, int addSpd, int value, int id, int quantity = 1)
        {
            Name = name;
            AddAtk = addAtk;
            AddDef = addDef;
            AddSpd = addSpd;
            Value = value;
            Quantity = quantity;
            Id = id;    
        }   
    }
}
