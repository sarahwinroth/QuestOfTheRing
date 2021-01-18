using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class Orc : Creature
    { 
        public Orc()
        {
            this.Article = "an ";
            this.Name = "Orc";
            this.Hp = 25;
            this.Exp = 100;
            this.Gold = 30;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
        }
    }
}
