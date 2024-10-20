using System;
using System.Collections.Generic;

public class Character : ICloneable
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }
    public List<Skill> Skills { get; set; }

    public Character(string name, int health, int strength, int agility, int intelligence)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Agility = agility;
        Intelligence = intelligence;
        Skills = new List<Skill>();
    }

    public object Clone()
    {
        Character clone = (Character)this.MemberwiseClone();
        clone.EquippedWeapon = (Weapon)this.EquippedWeapon.Clone();
        clone.EquippedArmor = (Armor)this.EquippedArmor.Clone();
        clone.Skills = new List<Skill>();
        foreach (var skill in this.Skills)
        {
            clone.Skills.Add((Skill)skill.Clone());
        }
        return clone;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Health: {Health}, Strength: {Strength}, Agility: {Agility}, Intelligence: {Intelligence}");
        Console.WriteLine($"Weapon: {EquippedWeapon.Name}, Damage: {EquippedWeapon.Damage}");
        Console.WriteLine($"Armor: {EquippedArmor.Name}, Defense: {EquippedArmor.Defense}");
        Console.WriteLine("Skills: ");
        foreach (var skill in Skills)
        {
            Console.WriteLine($"{skill.Name} (Type: {skill.Type})");
        }
    }
}

public class Weapon : ICloneable
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class Armor : ICloneable
{
    public string Name { get; set; }
    public int Defense { get; set; }

    public Armor(string name, int defense)
    {
        Name = name;
        Defense = defense;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class Skill : ICloneable
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Skill(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Character warrior = new Character("Warrior", 100, 80, 60, 40);
        warrior.EquippedWeapon = new Weapon("Sword", 50);
        warrior.EquippedArmor = new Armor("Steel Armor", 30);
        warrior.Skills.Add(new Skill("Slash", "Physical"));
        warrior.Skills.Add(new Skill("Shield Block", "Defense"));

        Character clonedWarrior = (Character)warrior.Clone();
        clonedWarrior.Name = "Cloned Warrior";
        clonedWarrior.EquippedWeapon.Name = "Axe";
        clonedWarrior.EquippedWeapon.Damage = 70;

        warrior.DisplayInfo();
        Console.WriteLine("\nCloned Character:\n");
        clonedWarrior.DisplayInfo();
    }
}
