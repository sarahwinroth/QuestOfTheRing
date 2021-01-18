using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class Wizard : Creature
    {
        public Wizard()
        {
            this.Article = "a ";
            this.Name = "Wizard";
            this.Hp = 35;
            this.Exp = 90;
            this.Gold = 50;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
        }
    }
}
