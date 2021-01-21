namespace QuestOfTheRing.Creatures
{
    internal class Dwarf : Creature
    {
        public Dwarf()
        {
            this.Article = "a ";
            this.Name = "Dwarf";
            this.Hp = 25;
            this.Exp = 100;
            this.Gold = 50;
            this.Strength = RandomHelper.GetRandomNum(2, 7);
            this.IsStrong = false;
        }
    }
}