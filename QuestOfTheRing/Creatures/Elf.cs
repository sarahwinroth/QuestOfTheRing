namespace QuestOfTheRing.Creatures
{
    internal class Elf : Creature
    {
        public Elf()
        {
            this.Article = "an ";
            this.Name = "Elf";
            this.Hp = 30;
            this.Exp = 95;
            this.Gold = 50;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
            this.IsStrong = false;
        }
    }
}