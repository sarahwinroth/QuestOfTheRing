namespace QuestOfTheRing.Creatures
{
    internal class Ogre : Creature
    {
        public Ogre()
        {
            this.Article = "an ";
            this.Name = "Ogre";
            this.Hp = 30;
            this.Exp = 95;
            this.Gold = 60;
            this.Strength = RandomHelper.GetRandomNum(2, 9);
            this.IsStrong = false;
        }
    }
}