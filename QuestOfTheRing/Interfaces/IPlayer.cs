namespace QuestOfTheRing
{
    internal interface IPlayer
    {
        string Name { get; }
        int Hp { get; set; }
        int Exp { get; set; }
        int Gold { get; set; }
        int Strength { get; set; }

        void Details() { }

        void Attack() { }

        void IsDead() { }

        void TakeGold() { }

        void LevelUp() { }

        void ShowCurrentDetails() { }

        void CollectItem() { }
    }
}