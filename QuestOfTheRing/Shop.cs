﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    class Shop
    {
        private int strengthPotion = 5;
        private int defensePotion = 2;
        private int healingPotion = 100;
        public Shop()
        { }
        public int StrengthPotion { get => strengthPotion; set => strengthPotion = value; }
        public int DefensePotion { get => defensePotion; set => defensePotion = value; }
        public int HealingPotion { get => healingPotion; set => healingPotion = value; }

        public void BuyStrengthPotion(Player player)
        {
            if (player.HasGold())
            {
                player.Strength += StrengthPotion;
                player.Pay();
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
            if (player.HasGold())
            {
                player.Endurance += DefensePotion;
                player.Pay();
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
            if (player.HasGold())
            {
                player.Hp += HealingPotion;
                player.Pay();
                Console.WriteLine($"You have now increased your hp with {HealingPotion}");
                Console.WriteLine($"Your total hp is now {player.Hp}");
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
