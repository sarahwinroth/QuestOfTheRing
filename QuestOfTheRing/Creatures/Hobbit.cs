namespace QuestOfTheRing.Creatures
{
    internal class Hobbit : Creature
    {
        public Hobbit()
        {
            this.Article = "a ";
            this.Name = "Hobbit";
            this.Hp = 35;
            this.Exp = 100;
            this.Gold = 30;
            this.Strength = RandomHelper.GetRandomNum(2, 7);
            this.IsStrong = false;
        }
    }
}