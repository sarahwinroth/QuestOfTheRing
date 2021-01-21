using QuestOfTheRing.Creatures;
using System;
using System.Collections.Generic;

namespace QuestOfTheRing
{
    internal class Player : IPlayer
    {
        private readonly string name;
        private int hp = 200;
        private int exp = 0;
        private int maxExp = 200;
        private int strength = RandomHelper.GetRandomNum(4, 10);
        private int endurance = 0;
        private int gold = 0;
        private bool hasRing = false;

        public List<Item> collectedItems = new List<Item>();

        public string Name => name;
        public int Hp { get => hp; set => hp = value; }
        public int Exp { get => exp; set => exp = value; }
        public int MaxExp { get => maxExp; set => maxExp = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Endurance { get => endurance; set => endurance = value; }
        public int Gold { get => gold; set => gold = value; }
        public bool HasRing { get => hasRing; set => hasRing = value; }

        public Player(string name)
        {
            this.name = name;
        }

        public void Details(GameLevel gameLevel)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n══PLAYER DETAILS══");
            Console.WriteLine($" Name: {Name}");
            Console.WriteLine($" Level: {gameLevel.Level}");
            Console.WriteLine($" Hp: {Hp}");
            Console.WriteLine($" Exp: {Exp}/{MaxExp}");
            Console.WriteLine($" Gold: {Gold}");
            Console.WriteLine($" Strength: {Strength}");
            Console.WriteLine($" Endurance: {Endurance}");
            Console.WriteLine("\n[ENTER]");
            Console.ReadLine();
        }

        public void Attack(Creature creature)
        {
            Console.Write($"You attacked the {creature.Name}, dealing {Strength} damage");
            creature.Hp -= Strength;
        }

        public bool IsDead()
        {
            if (Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeGold(Creature creature)
        {
            Gold += creature.Gold;
        }

        public void LevelUp(GameLevel gameLevel)
        {
            if (Exp >= maxExp)
            {
                gameLevel.Level += 1;
                Console.WriteLine($"\nYou've reached level {gameLevel.Level}");
                Exp = 0;
                Hp += 200;
            }
        }

        public void ShowCurrentDetails()
        {
            Console.WriteLine($"\n══ CURRENT STATUS ══");
            Console.WriteLine($" Exp: {Exp}");
            Console.WriteLine($" Hp: {Hp}");
            Console.WriteLine($" Gold: {Gold}");
            Console.WriteLine("\n[ENTER]");
            Console.ReadLine();
        }

        public void CollectItem(Item item)
        {
            collectedItems.Add(item);
            Console.WriteLine($"\nAn item is dropped, {item.Name} is now in your possession");
            item.RemoveItemFromList(item);
        }

        public bool HasGold(bool isHealing)
        {
            if (Gold == 100 || Gold > 100)
            {
                return true;
            }
            else if (Gold == 50 || Gold > 50 && isHealing)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Pay(bool isHealing)
        {
            if (isHealing) { Gold -= 50; }
            else { Gold -= 100; }
        }

        public void SellCollectedItem(Item item)
        {
            collectedItems.Remove(item);
        }

        public void IfRobin()
        {
            if (Name == "Robin" || Name == "robin")
            {
                Hp = 10000;
                Gold = 1000;
                Strength = 30;
                Endurance = 10;
            }
        }
    }
}