using QuestOfTheRing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class Hobbit : Creature
    { 
        public Hobbit()
        {
            this.Article = "a ";
            this.Name = "Hobbit";
            this.Hp = 25;
            this.Exp = 100;
            this.Gold = 20;
            this.Strength = RandomHelper.GetRandomNum(2, 7);
        }
    }
}
