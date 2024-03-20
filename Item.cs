﻿using MiniProject.GameManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    // ID
    // 1-Sword, 2-Spear, 3-Axe, 4-Healing, 5-Buff, 6-Scroll

    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }        
        public int _type { get; set; }
        //protected static int exp {  get; set; }
        //protected static int maxExp {  get; set; }

        public List<string> Type = new List<string> { "Sword", "Spear", "Axe", "Healing", "Buff", "Scroll" };

        public Item(string name, int value, string description, int type, int id)
        {
            Name = name;
            Value = value;
            Description = description;
            Id = id;
            _type = type;
        }

        public Item(string name, int type, int id, string description)
        {
            Name = name;
            Id = id;
            Description = description;
            _type = type;
            //exp = 0;
            //maxExp = 100;
        }
    }

    public class Sword : Item
    {
        public int ATK {  get; set; }
        public int DEF {  get; set; }
        public int SPD {  get; set; }
        private int exp;
        private int maxExp = 100;

        public Sword(string name, int type, int id, string description, int atk, int def, int spd) : base(name, type, id, description)
        {
            ATK = atk;
            DEF = def;
            SPD = spd;
            exp = 0;
            Quantity = 1;
        }

        public void GetExp(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.Normal:
                    exp += 20;
                    break;
                case MonsterType.Elite:
                    exp += 35;
                    break;
                case MonsterType.Boss:
                    exp += 50;
                    break;
            }

            if (exp > maxExp)
            {
                ResetExp();
                UpdateWeaponLv();
            }
        }

        public void ResetExp()
        {
            exp = 0;
            maxExp += 20;
        }

        public void UpdateWeaponLv()
        {
            int abilitycnt = 5;
            int AtkIncrease = 0, DefIncrease = 0, SpdIncrease = 0;
            Console.WriteLine("무기 레벨이 상승했습니다.");
            Console.WriteLine("상승시킬 능력치를 고르세요.");
            Console.WriteLine("1. 공격력\t2. 방어력\t3. 속도");
            int AbilityCntUse = int.Parse(Console.ReadLine());
            while (abilitycnt > 0)
            {
                switch (AbilityCntUse)
                {
                    case 1:
                        Console.WriteLine("공격력 선택");
                        AtkIncrease++;
                        break;
                    case 2:
                        Console.WriteLine("방어력 선택");
                        DefIncrease++;
                        break;
                    case 3:
                        Console.WriteLine("속도 선택");
                        SpdIncrease++;
                        break;
                }
            }
            Console.WriteLine($"공격력이 {AtkIncrease}만큼 상승했습니다.");
            Console.WriteLine($"방어력이 {DefIncrease}만큼 상승했습니다.");
            Console.WriteLine($"속도가 {SpdIncrease}만큼 상승했습니다.");

            ATK += AtkIncrease;
            DEF += DefIncrease;
            SPD += SpdIncrease;
        }
    }

    public class Axe : Item
    {
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }
        private int exp;
        private int maxExp = 100;
        public Axe(string name, int type, int id, string description, int atk, int def, int spd) : base(name, type, id, description)
        {
            ATK = atk;
            DEF = def;
            SPD = spd;
            exp = 0;
            Quantity = 1;
        }
        public void GetExp(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.Normal:
                    exp += 20;
                    break;
                case MonsterType.Elite:
                    exp += 35;
                    break;
                case MonsterType.Boss:
                    exp += 50;
                    break;
            }

            if (exp > maxExp)
            {
                ResetExp();
                UpdateWeaponLv();
            }
        }

        public void ResetExp()
        {
            exp = 0;
            maxExp += 20;
        }

        public void UpdateWeaponLv()
        {
            int abilitycnt = 5;
            int AtkIncrease = 0, DefIncrease = 0, SpdIncrease = 0;
            Console.WriteLine("무기 레벨이 상승했습니다.");
            Console.WriteLine("상승시킬 능력치를 고르세요.");
            Console.WriteLine("1. 공격력\t2. 방어력\t3. 속도");
            int AbilityCntUse = int.Parse(Console.ReadLine());
            while (abilitycnt > 0)
            {
                switch (AbilityCntUse)
                {
                    case 1:
                        Console.WriteLine("공격력 선택");
                        AtkIncrease++;
                        break;
                    case 2:
                        Console.WriteLine("방어력 선택");
                        DefIncrease++;
                        break;
                    case 3:
                        Console.WriteLine("속도 선택");
                        SpdIncrease++;
                        break;
                }
            }
            Console.WriteLine($"공격력이 {AtkIncrease}만큼 상승했습니다.");
            Console.WriteLine($"방어력이 {DefIncrease}만큼 상승했습니다.");
            Console.WriteLine($"속도가 {SpdIncrease}만큼 상승했습니다.");

            ATK += AtkIncrease;
            DEF += DefIncrease;
            SPD += SpdIncrease;
        }
    }

    public class Spear : Item
    {
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }
        private int exp;
        private int maxExp = 100;
        public Spear(string name, int type, int id, string description, int atk, int def, int spd) : base(name, type, id, description)
        {
            ATK = atk;
            DEF = def;
            SPD = spd;
            exp = 0;
            Quantity = 1;
        }
        public void GetExp(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.Normal:
                    exp += 20;
                    break;
                case MonsterType.Elite:
                    exp += 35;
                    break;
                case MonsterType.Boss:
                    exp += 50;
                    break;
            }

            if (exp > maxExp)
            {
                ResetExp();
                UpdateWeaponLv();
            }
        }

        public void ResetExp()
        {
            exp = 0;
            maxExp += 20;
        }

        public void UpdateWeaponLv()
        {
            int abilitycnt = 5;
            int AtkIncrease = 0, DefIncrease = 0, SpdIncrease = 0;
            Console.WriteLine("무기 레벨이 상승했습니다.");
            Console.WriteLine("상승시킬 능력치를 고르세요.");
            Console.WriteLine("1. 공격력\t2. 방어력\t3. 속도");
            int AbilityCntUse = int.Parse(Console.ReadLine());
            while (abilitycnt > 0)
            {
                switch (AbilityCntUse)
                {
                    case 1:
                        Console.WriteLine("공격력 선택");
                        AtkIncrease++;
                        break;
                    case 2:
                        Console.WriteLine("방어력 선택");
                        DefIncrease++;
                        break;
                    case 3:
                        Console.WriteLine("속도 선택");
                        SpdIncrease++;
                        break;
                }
            }
            Console.WriteLine($"공격력이 {AtkIncrease}만큼 상승했습니다.");
            Console.WriteLine($"방어력이 {DefIncrease}만큼 상승했습니다.");
            Console.WriteLine($"속도가 {SpdIncrease}만큼 상승했습니다.");

            ATK += AtkIncrease;
            DEF += DefIncrease;
            SPD += SpdIncrease;
        }
    }

    public class Potion : Item
    {
        public Potion(string name, int value, string description, int type, int id) : base(name, value, description, type, id)
        {

        }

        public static void Healing(int idx)
        {
            Item healingpotion = Player.Inventory[idx];

            switch (healingpotion.Id)
            {
                case 3:
                    Player.P_curhp = Math.Min(Player.P_curhp + 20, Player.P_maxhp);
                    break;
                case 4:
                    Player.P_curhp = Math.Min(Player.P_curhp + 40, Player.P_maxhp);
                    break;
                case 5:
                    Player.P_curhp = Math.Min(Player.P_curhp + 80, Player.P_maxhp);
                    break;
            }
        }

        public static void Buff(int idx)
        {
            Item buffpotion = Player.Inventory[idx];
            int CurAtk = Player.P_totalatk;
            Player.isBuffed = true;

            switch (buffpotion.Id)
            {
                case 6:
                    Player.P_baseatk = CurAtk + 10;
                    break;
                case 7:
                    Player.P_baseatk = CurAtk + 15;
                    break;
            }
        }
    }

    public class Scroll : Item
    {
        public Scroll(string name, int value, string description, int type, int id) : base(name, value, description, type, id)
        {

        }

        public static void Escape(int idx)
        {
            Console.WriteLine("강제로 전투에서 탈출하여 마을로 돌아갑니다.");

            GamePlay.SelectPlay();
        }
    }
}
