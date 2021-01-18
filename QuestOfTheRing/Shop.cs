using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    class Shop
    {
        private int strengthPotion = 5;
        private int defensePotion = 2;
        private int healingPotion = 100;
        private bool isHealing = false;
        public Shop()
        { }
        public int StrengthPotion { get => strengthPotion; set => strengthPotion = value; }
        public int DefensePotion { get => defensePotion; set => defensePotion = value; }
        public int HealingPotion { get => healingPotion; set => healingPotion = value; }
        public bool IsHealing { get => isHealing; set => isHealing = value; }

        public void BuyStrengthPotion(Player player)
        {
            if (player.HasGold(isHealing))
            {
                player.Strength += StrengthPotion;
                player.Pay(isHealing);
                Console.WriteLine($"You have now increased your strength with with {StrengthPotion}");
                Console.WriteLine($"Your total strength is now {player.Strength}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You dont have enough gold to make a purchase");
                Console.ReadLine();
            }
        }
        public void BuyDefensePotion(Player player)
        {
            if (player.HasGold(isHealing))
            {
                player.Endurance += DefensePotion;
                player.Pay(isHealing);
                Console.WriteLine($"You have now increased your endurance with {DefensePotion}");
                Console.WriteLine($"Your total endurance is now {player.Endurance}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You dont have enough gold to make a purchase");
                Console.ReadLine();
            }
        }
        public void BuyHealingPotion(Player player)
        {
            isHealing = true;

            if (player.HasGold(isHealing))
            {
                player.Hp += HealingPotion;
                player.Pay(isHealing);
                Console.WriteLine($"You have increased your hp with {HealingPotion}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You dont have enough gold to make a purchase");
                Console.ReadLine();
            }
        }
    }
}
