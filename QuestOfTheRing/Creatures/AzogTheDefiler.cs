using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Creatures
{
    class AzogTheDefiler : Creature
    {
        public AzogTheDefiler()
        {
            this.Article = "";
            this.Name = "Azog the Defiler";
            this.Hp = 200;
            this.Exp = 0;
            this.Gold = 0;
            this.Strength = RandomHelper.GetRandomNum(10, 21);
        }
    }
}
