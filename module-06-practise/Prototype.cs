using System;
using System.Collections.Generic;

namespace FlightBookingSystem
{

    public interface IDeepCloneable<T>
    {
        T DeepClone();
    }

    public class Weapon : IDeepCloneable<Weapon>
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Weapon(string Name, int Damage)
        {
            this.Name = Name;
            this.Damage = Damage;
        }

        public Weapon DeepClone()
        {
            return new Weapon(this.Name, this.Damage);
        }
    }

    public class Armor : IDeepCloneable<Armor>
    {
        public string Name { get; set; }
        public int Defense { get; set; }

        public Armor(string Name, int Defense)
        {
            this.Name = Name;
            this.Defense = Defense;
        }

        public Armor DeepClone()
        {
            return new Armor(this.Name, this.Defense);
        }
    }

    public class Skill : IDeepCloneable<Skill>
    {
        public string Name { get; set; }
        public string SkillType { get; set; }

        public Skill(string Name, string SkillType)
        {
            this.Name = Name;
            this.SkillType = SkillType;
        }

        public Skill DeepClone()
        {
            return new Skill(this.Name, this.SkillType);
        }
    }

    public class Character : IDeepCloneable<Character>
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Agility { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public List<Skill> Skills { get; set; }

        public Character(string Name, int Damage, int Health, int Agility)
        {
            this.Name = Name;
            this.Damage = Damage;
            this.Health = Health;
            this.Agility = Agility;
            this.Skills = new List<Skill>();
        }

        public Character DeepClone()
        {
            Character clone = 
                new Character(this.Name, this.Damage, this.Health, this.Agility);
            clone.Weapon = this.Weapon;
            clone.Armor = this.Armor;
            foreach (var skill in this.Skills)
            {
                clone.Skills.Add(skill.DeepClone());
            }
            return clone;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {           

            Character warrior = new Character("first", 100, 100, 100);

            Character warriorClone = warrior.DeepClone();

        }

    }
}
