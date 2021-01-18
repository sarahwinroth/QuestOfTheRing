using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class Ogre : Creature
    {
        public Ogre()
        {
            this.Article = "an ";
            this.Name = "Ogre";
            this.Hp = 30;
            this.Exp = 95;
            this.Gold = 50;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
        }
    }
}
