namespace QuestOfTheRing.Creatures
{
    internal class Ent : Creature
    {
        public Ent()
        {
            this.Article = "an ";
            this.Name = "Ent";
            this.Hp = 25;
            this.Exp = 100;
            this.Gold = 40;
            this.Strength = RandomHelper.GetRandomNum(2, 7);
            this.IsStrong = false;
        }
    }
}