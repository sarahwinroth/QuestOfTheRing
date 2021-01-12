using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    class Shop
    {
        private int strengthPotion = 5;
        private int defensePotion = 2;
        private int healthPotion = 100;
        public Shop()
        { }
        public int StrengthPotion { get => strengthPotion; set => strengthPotion = value; }
        public int DefensePotion { get => defensePotion; set => defensePotion = value; }
        public int HealthPotion { get => healthPotion; set => healthPotion = value; }

    }
}
