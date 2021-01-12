using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    class SpecificCreature : Creature
    {
        private int level;
        private string place;
        private int hp;
        private int exp;
        private int gold;
        private int strength;
        private string article;

        public SpecificCreature(string article, string name, int level, string place, int hp, int exp, int gold, int strength)
        {
            this.article = article;
            this.Name = name;
            this.level = level;
            this.place = place;
            this.hp = hp;
            this.exp = exp;
            this.gold = gold;
            this.strength = strength;
        }

        public int Level { get => level; set => level = value; }
        public string Place { get => place; set => place = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Strength { get => strength; set => strength = value; }
        public string Article { get => article; set => article = value; }
    }
}
