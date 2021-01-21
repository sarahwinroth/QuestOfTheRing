namespace QuestOfTheRing.Creatures
{
    internal class Wizard : Creature
    {
        public Wizard()
        {
            this.Article = "a ";
            this.Name = "Wizard";
            this.Hp = 35;
            this.Exp = 90;
            this.Gold = 100;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
            this.IsStrong = true;
        }
    }
}