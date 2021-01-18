using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Interfaces
{
    interface ICreature
    {
        void Attack(Player player) { }
        void GiveExp(Player player) { }
    }
}
