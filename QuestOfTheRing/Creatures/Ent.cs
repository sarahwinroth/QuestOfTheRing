using QuestOfTheRing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class Ent : Creature
    {      
        public Ent()
        {
            this.Article = "an ";
            this.Name = "Ent";
            this.Hp = 25;
            this.Exp = 100;
            this.Gold = 30;
            this.Strength = RandomHelper.GetRandomNum(2, 7);
        }
    }
}
