namespace QuestOfTheRing.Creatures
{
    internal class Troll : Creature
    {
        public Troll()
        {
            this.Article = "a ";
            this.Name = "Troll";
            this.Hp = 35;
            this.Exp = 90;
            this.Gold = 80;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
            this.IsStrong = true;
        }
    }
}