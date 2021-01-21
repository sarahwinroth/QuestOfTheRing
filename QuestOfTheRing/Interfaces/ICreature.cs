using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing.Interfaces
{
    interface ICreature
    {
        void GetRandomCreature() { }
        void Attack(Player player) { }
        void IsDead() { }
        void GiveExp(Player player) { }
        void DropItem() { }
        void LevelUpgrade() { }

    }
}
