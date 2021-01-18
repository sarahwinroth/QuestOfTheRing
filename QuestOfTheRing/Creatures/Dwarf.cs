using QuestOfTheRing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class Dwarf : Creature
    {
        public Dwarf()
        {
            this.Article = "a ";
            this.Name = "Dwarf";
            this.Hp = 25;
            this.Exp = 100;
            this.Gold = 30;
            this.Strength = RandomHelper.GetRandomNum(2, 7);
        }
    }
}
