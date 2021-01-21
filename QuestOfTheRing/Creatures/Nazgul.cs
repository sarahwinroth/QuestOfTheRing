namespace QuestOfTheRing.Creatures
{
    internal class Nazgul : Creature
    {
        public Nazgul()
        {
            this.Article = "a ";
            this.Name = "Nazgul";
            this.Hp = 35;
            this.Exp = 90;
            this.Gold = 100;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
            this.IsStrong = true;
        }
    }
}