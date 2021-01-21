namespace QuestOfTheRing.Creatures
{
    internal class AzogTheDefiler : Creature
    {
        public AzogTheDefiler()
        {
            this.Article = "";
            this.Name = "Azog the Defiler";
            this.Hp = 800;
            this.Exp = 0;
            this.Gold = 0;
            this.Strength = RandomHelper.GetRandomNum(40, 50);
        }
    }
}