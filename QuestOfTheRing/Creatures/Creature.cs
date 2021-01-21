using QuestOfTheRing.Interfaces;
using System;
using System.Collections.Generic;

namespace QuestOfTheRing.Creatures
{
    internal abstract class Creature : ICreature
    {
        private string article;
        private string name;
        private int hp;
        private int exp;
        private int gold;
        private int strength;
        private bool isStrong;

        public static List<ICreature> listOfCreatures = new List<ICreature>();

        public string Article { get => article; set => article = value; }
        public string Name { get => name; set => name = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Strength { get => strength; set => strength = value; }
        public bool IsStrong { get => isStrong; set => isStrong = value; }

        public static Creature GetRandomCreature(GameLevel gameLevel)
        {
            bool getCreature = true;
            while (getCreature)
            {
                int i = RandomHelper.GetRandomNum(listOfCreatures.Count);

                Creature creature = (Creature)listOfCreatures[i];
                if (gameLevel.Level <= 5 && !creature.IsStrong)
                {
                    return creature;
                }
                else if (gameLevel.Level >= 6 && creature.IsStrong)
                {
                    return creature;
                }
            }
            return null;
        }

        public void LevelUpgrade(GameLevel gameLevel)
        {
            switch (gameLevel.Level)
            {
                case 2:
                    Strength += 6;
                    Hp += 20;
                    Exp -= 10;
                    break;

                case 3:
                    Strength += 20;
                    Hp += 50;
                    Exp -= 20;
                    break;

                case 4:
                    Strength += 30;
                    Hp += 80;
                    Exp -= 30;
                    break;

                case 5:
                    Strength += 40;
                    Hp += 100;
                    Exp -= 40;
                    break;

                case 6:
                    Strength += 50;
                    Hp += 120;
                    Exp -= 50;
                    break;

                case 7:
                    Strength += 60;
                    Hp += 150;
                    Exp -= 60;
                    break;

                case 8:
                    Strength += 80;
                    Hp += 200;
                    Exp -= 60;
                    break;

                case 9:
                    Strength += 100;
                    Hp += 250;
                    Exp -= 60;
                    break;

                case 10:
                    Strength += 150;
                    break;

                default:
                    break;
            }
        }

        public void Attack(Player player)
        {
            var attackDamage = strength - player.Endurance;
            if (attackDamage <= 0)
            { attackDamage = 0; }
            Console.Write($"The {name} attacked you, dealing {attackDamage} damage");
            player.Hp -= attackDamage;
        }

        public bool IsDead(Creature creature)
        {
            if (creature.hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Item DropItem()
        {
            Item item = Item.GetRandomItem();
            return item;
        }

        public void IsDefeated(Creature creature)
        {
            Console.WriteLine($"You have defeated the {creature.Name}!");
            Console.WriteLine($"You've recieved {creature.Exp} exp and {creature.Gold} gold");
        }

        public void GiveExp(Player player)
        {
            player.Exp += exp;
        }

        public static void AddCreatures()
        {
            listOfCreatures.Clear();
            listOfCreatures.Add(new Hobbit());
            listOfCreatures.Add(new Dwarf());
            listOfCreatures.Add(new Elf());
            listOfCreatures.Add(new Ent());
            listOfCreatures.Add(new Troll());
            listOfCreatures.Add(new Ogre());
            listOfCreatures.Add(new Wizard());
            listOfCreatures.Add(new Nazgul());
            listOfCreatures.Add(new Orc());
        }
    }
}