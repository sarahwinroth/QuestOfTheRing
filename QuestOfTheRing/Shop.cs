using System;

namespace QuestOfTheRing
{
    internal class Shop
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

        public void Menu(Player player)
        {
            bool keepShopping = true;
            try
            {
                while (keepShopping)
                {
                    Console.Clear();
                    Console.WriteLine("══ SHOP ══");
                    Console.WriteLine("What would you like to buy?");
                    Console.WriteLine($"You have {player.Gold} gold");
                    Console.WriteLine("════════════════════════════════════════════");
                    Console.WriteLine("1. Strength Potion (+ 5 Strength) - 100 gold");
                    Console.WriteLine("2. Defense Potion (+ 2 toughness) - 100 gold");
                    Console.WriteLine("3. Healing Potion (+ 100 health) - 50 gold");
                    Console.WriteLine("4. Sell your items");
                    Console.WriteLine("5. Exit shop");
                    Console.Write("> ");
                    int input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            BuyStrengthPotion(player);
                            break;

                        case 2:
                            BuyDefensePotion(player);
                            break;

                        case 3:
                            BuyHealingPotion(player);
                            break;

                        case 4:
                            SellItem(player);
                            break;

                        case 5:
                            keepShopping = false;
                            break;

                        default:
                            Console.WriteLine("Wrong input, please try again!");
                            break;
                    }
                }
            }
            catch { Console.WriteLine("Wrong input, please try again!"); Console.ReadLine(); Menu(player); }
        }

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

        public void SellItem(Player player)
        {
            int count = 1;
            bool keepSelling = true;
            try
            {
                while (keepSelling)
                {
                    Console.Clear();
                    Console.WriteLine("\nWhich of the items would you like to sell?");
                    Console.WriteLine("═══════════════════════════════════════════");

                    if (player.collectedItems.Count != 0)
                    {
                        foreach (var element in player.collectedItems)
                        {
                            if (element != null)
                            {
                                Console.WriteLine($"{count}. {element.Name}, worth: {element.Value} gold");
                                count++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You dont have any items in your possession, come back when you have");
                        Console.WriteLine("[ENTER]");
                        Console.ReadLine();
                        keepSelling = false;
                        break;
                    }
                    Console.Write("> ");
                    int input = Convert.ToInt32(Console.ReadLine());
                    var item = player.collectedItems[input - 1];
                    Console.WriteLine($"You sold {item.Name} for: {item.Value}");
                    player.Gold += item.Value;
                    player.SellCollectedItem(item);
                    Console.WriteLine("Continue selling items?");
                    Console.WriteLine("[Y/N]");
                    string choice = Console.ReadLine();
                    if (choice.ToLower().Replace(" ", "") == "y")
                    {
                        SellItem(player);
                    }
                    else
                    {
                        keepSelling = false;
                    }
                }
            }
            catch { Console.WriteLine("Wrong input, please try again!"); Console.ReadLine(); SellItem(player); }
        }
    }
}