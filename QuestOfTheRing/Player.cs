using System;

namespace QuestOfTheRing
{
    class Player : IAttack
    {
        private string name;
        private int level = 1;
        private int hp = 200;
        private int exp = 0;
        private int strength = 5;
        private int endurance = 0;
        private int gold = 0;
        private bool hasRing;

        public Player()
        { }

        public Player(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Endurance { get => endurance; set => endurance = value; }
        public int Gold { get => gold; set => gold = value; }
        public bool HasRing { get => hasRing; set => hasRing = value; }

        public void PlayerDetails()
        {
            Console.WriteLine("******************");
            Console.WriteLine($"* Name: {name}");
            Console.WriteLine($"* Level: {level}");
            Console.WriteLine($"* Hp: {hp}");
            Console.WriteLine($"* Exp: {exp}/200");
            Console.WriteLine($"* Gold: {gold}");
            Console.WriteLine($"* Strength: {strength}");
            Console.WriteLine($"* Endurance: {endurance}");
            Console.WriteLine("******************");
        }

        public void Attack(SpecificCreature creature)
        {
            creature.Hp -= Strength;
        }

        public void TakeGold(SpecificCreature creature)
        {
            Gold += creature.Gold;
        }

        public bool HasGold()
        {
            if (gold == 100 || gold > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Pay()
        {
            Gold -= 100;
        }
    }
}