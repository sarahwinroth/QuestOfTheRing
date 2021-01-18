using QuestOfTheRing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    abstract class Creature : ICreature
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

        public static ICreature GetRandomCreature()
        {
            int i = RandomHelper.GetRandomNum(listOfCreatures.Count);
            return listOfCreatures[i];
        }
        public void LevelUpgrade(GameLevel gameLevel)
        {   
            switch(gameLevel.Level)
            {
                case 2:
                    Strength += 4;
                    Hp += 10;
                    Exp -= 10;
                    break;
                case 3:
                    Strength += 8;
                    Hp += 30;
                    Exp -= 20;
                    break;
                case 4:
                    Strength += 10;
                    Hp += 40;
                    Exp -= 30;
                    break;
                case 5:
                    Strength += 12;
                    Hp += 50;
                    Exp -= 40;
                    break;
                case 6:
                    Strength += 15;
                    Hp += 60;
                    Exp -= 50;
                    break;
                case 7:
                    Strength += 20;
                    Hp += 70;
                    Exp -= 60;
                    break;
                case 8:
                    Strength += 25;
                    Hp += 80;
                    Exp -= 65;
                    break;
                case 9:
                    Strength += 30;
                    Hp += 90;
                    Exp -= 70;
                    break;
                case 10:
                    Strength += 40;
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
        public void TakeDamage() // Hur behöver jag detta?
        { }
        public bool IsDead(Creature creature)
        {
            if(creature.hp <= 0)
            { 
                return true; 
            }
            else
            {
                return false;
            }
        }
        public void IsDefeated(Creature creature)
        {
            Console.WriteLine($"You have defeated the {creature.Name}! You gained {creature.Exp} experience points and {creature.Gold} gold");
        }
        public void GiveExp(Player player)
        {
            player.Exp += exp;
        }
    }
}
