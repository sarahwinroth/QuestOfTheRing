namespace QuestOfTheRing.Creatures
{
    internal class Orc : Creature
    {
        public Orc()
        {
            this.Article = "an ";
            this.Name = "Orc";
            this.Hp = 50;
            this.Exp = 90;
            this.Gold = 80;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
            this.IsStrong = true;
        }
    }
}