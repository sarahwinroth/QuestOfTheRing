using QuestOfTheRing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class Troll : Creature
    {       
        public Troll()
        {
            this.Article = "a ";
            this.Name = "Troll";
            this.Hp = 35;
            this.Exp = 90;
            this.Gold = 40;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
        }    
    }
}
