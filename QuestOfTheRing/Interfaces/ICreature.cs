namespace QuestOfTheRing.Interfaces
{
    internal interface ICreature
    {
        void GetRandomCreature() { }

        void Attack() { }

        void IsDead() { }

        void GiveExp() { }

        void DropItem() { }

        void LevelUpgrade() { }
    }
}