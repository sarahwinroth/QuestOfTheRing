using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    class GameLogic
    {
        public Player player;
        public static List<SpecificCreature> ListOfCreatures = new List<SpecificCreature>();
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("* * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* *                             * *");
            Console.WriteLine("* *         Welcome to          * *");
            Console.WriteLine("* *    The Quest of the Ring    * *");
            Console.WriteLine("* *                             * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * *");


            Console.Write("\nEnter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            Console.Clear();
            Console.WriteLine($"Oh fearless {playerName}!");
            Console.WriteLine("The Ring has been found once again in Hobbiton, Frodo has failed to destroy it in the fires of Mount Doom");
            Console.WriteLine($"The Quest to destroy the Ring once again has been assigned to you {playerName}");
            Console.WriteLine("Sauron has felt the Rings presence in Middle-Earth and darkness has fallen upon all creatures");
            Console.WriteLine("The Ring is now in your possession, you must finish the Quest, take the path to Mordor and destroy \nthe Ring in the fires of Mount Doom once and for all");
            player.HasRing = true;
            Console.WriteLine("Please hurry, you are our only hope!");
            Console.WriteLine();
            Console.WriteLine("[PLAY]");

            Console.ReadLine();
            //AddCreatures();
            Menu();
        }
        public void Menu()
        {
            try
            {
                bool keepPlaying = true;

                while (keepPlaying)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    var creature = GetCreature();
                    Console.WriteLine($"You are on level {player.Level} and you have reached {creature.Place}");
                    Console.WriteLine("**************************************************");
                    Console.WriteLine("\n[MENU]");
                    Console.WriteLine("1. Go on Quest");
                    Console.WriteLine("2. Player details");
                    Console.WriteLine("3. Go to Shop");
                    Console.WriteLine("4. Exit game");
                    Console.Write("> ");
                    int input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            GoOnQuest();
                            break;
                        case 2:
                            player.PlayerDetails();
                            Console.ReadLine();
                            break;
                        case 3:
                            Shop();
                            break;
                        case 4:
                            Console.WriteLine("Oh, Leaving so soon?");
                            Console.WriteLine("The Woods will miss you <3");
                            keepPlaying = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input, please try again!");
                            break;
                    }
                }
            }
            catch { Console.WriteLine("Wrong input, please try again!"); Console.ReadLine(); Menu(); }// Kan man göra så här??
        }

        public void GoOnQuest()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            var creature = GetCreature();

            Random random = new Random();
            int rand = random.Next(10);

            if (rand == 1)
            {
                Console.WriteLine("Be patient, you are walking on your path to Mordor..");
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();
                Menu();
            }
            else
            {              
                Console.WriteLine($"Oh no! Someone is coming at you, it's {creature.Article}{creature.Name}!");
                Console.ReadLine();
                FightCreature(creature);
            }
        }
        public void FightCreature(SpecificCreature creature)
        {
            bool fightMode = true;
            while (fightMode)
            {
                Console.Clear();
                var attackDamage = creature.Strength - player.Endurance;
                Console.Write($"The {creature.Name} attacked you, dealing {attackDamage} damage");            
                player.Hp -= creature.Strength;
                Console.ReadLine();
                Console.Write($"You attacked the {creature.Name}, dealing {player.Strength} damage");
                creature.Hp -= player.Strength;
                Console.ReadLine();

                if (player.Hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    player.HasRing = false;
                    Console.WriteLine("\nYou are defeated and failed to complete your Quest. \nThe Ring has returned in the hands of Sauron and the future of Middle-Earth is lost!");
                    Console.WriteLine("*************");
                    Console.WriteLine("* GAME OVER *");
                    Console.WriteLine("*************");                                 
                    Environment.Exit(0);
                }
                if (creature.Hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    if (player.Level == 10)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"You have defeated {creature.Name} and are now standing just above the fires of Mount Doom");
                        Console.WriteLine("The power to destroy the Ring is in your hands, will you throw the Ring in the fires of Mount Doom?");
                        Console.WriteLine("[Y/N]");
                        string input = Console.ReadLine();
                        if (input.ToLower().Replace(" ", "") == "y")
                        {
                            player.HasRing = false;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Oh {player.Name} our saviour, you have thrown the Ring in the fires of Mount Doom and saved Middle-Earth!");
                            Console.WriteLine("We are forever greatful and to show you our gratitude the elves has given you the Glamdring sword, \nwhich was forged in the First Age by the High Elves");
                            Console.WriteLine($"Farewell oh mighty {player.Name}, until we meet again");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("While you walked out of the gates of Mordor with the Ring still in your possession, \nGollum attacked you from behind and stabbed you with a knife");
                            player.HasRing = false;
                            Console.WriteLine("You are a traitor and failed to complete your Quest. \nThe Ring has returned in the hands of Sauron and the future of Middle-Earth is lost!");
                            Console.WriteLine("\n*************");
                            Console.WriteLine("* GAME OVER *");
                            Console.WriteLine("*************");
                            Environment.Exit(0);
                        }                       
                    }

                    Console.WriteLine($"You have defeated the {creature.Name}! You gained {creature.Exp} experience points and {creature.Gold} gold");
                    player.Exp += creature.Exp;
                    player.Gold += creature.Gold;
                    if(player.Exp >= 200)
                    {
                        player.Level += 1;
                        Console.WriteLine($"\nYou've reached level {player.Level}");
                        player.Exp = 0;
                        player.Hp += 200;
                    }
                    Console.WriteLine($"You have now {player.Exp} exp, {player.Hp} hp and {player.Gold} gold");             
                    Console.ReadLine();
                    Menu();
                }
                Console.WriteLine($"\n{player.Name}: {player.Hp} hp");
                Console.WriteLine($"{creature.Name}: {creature.Hp} hp");
                Console.ReadLine();
            }
        }      

        public SpecificCreature GetCreature()
        {
            if(player.Level == 1)
            { SpecificCreature creature = new SpecificCreature("a ", "Hobbit", 1, "Hobbiton", 50, 100, 10, 5); return creature; }
            else if (player.Level == 2)
            { SpecificCreature creature = new SpecificCreature("a ", "Dwarf", 2, "Mines of Moria", 60, 70, 20, 7); return creature; }
            else if (player.Level == 3)
            { SpecificCreature creature = new SpecificCreature("an ", "Ent", 3, "Fangorn Forest", 60, 70, 30, 7); return creature; }
            else if (player.Level == 4)
            { SpecificCreature creature = new SpecificCreature("a ", "Troll", 4, "Trollshaws", 80, 50, 40, 8); return creature; }
            else if (player.Level == 5)
            { SpecificCreature creature = new SpecificCreature("an ", "Elf", 5, "Rivendell", 100, 50, 40, 8); return creature; }
            else if (player.Level == 6)
            { SpecificCreature creature = new SpecificCreature("an ", "Ogre", 6, "Nan Amlug East", 100, 50, 50, 10); return creature; }
            else if (player.Level == 7)
            { SpecificCreature creature = new SpecificCreature("a ", "Wizard", 7, "Isengard", 120, 50, 50, 15); return creature; }
            else if (player.Level == 8)
            { SpecificCreature creature = new SpecificCreature("a ", "Nazgul", 8, "closer to Mordor", 120, 50, 50, 15); return creature; }
            else if (player.Level == 9)
            { SpecificCreature creature = new SpecificCreature("an ", "Orc", 9, "the gates of Mordor", 150, 50, 50, 15); return creature; }
            else if (player.Level == 10)
            { SpecificCreature creature = new SpecificCreature("", "Azog the Defiler", 10, "the heart of Mordor", 200, 0, 0, 20); return creature; }
            else
            { Console.WriteLine("The players level was not found"); }
            return null;
        }
        public void Shop()
        {
            bool keepShopping = true;
            try
            {
                while (keepShopping)
                {
                    Shop shop = new Shop();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("[SHOP]");
                    Console.WriteLine("What would you like to buy?");
                    Console.WriteLine($"You have {player.Gold} gold");
                    Console.WriteLine("********************************************");
                    Console.WriteLine("1. Strength Potion (+ 5 Strength) - 100 gold");
                    Console.WriteLine("2. Defense Potion (+ 2 toughness) - 100 gold");
                    Console.WriteLine("3. Healing Potion (+ 100 health) - 100 gold");
                    Console.WriteLine("4. Exit shop");
                    Console.Write("> ");
                    int input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            if (player.HasGold())
                            {
                                player.Strength += shop.StrengthPotion;
                                player.Pay();
                                Console.WriteLine($"You have now increased your strength with with {shop.StrengthPotion}");
                                Console.WriteLine($"Your total strength is now {player.Strength}");
                                Console.ReadLine();
                                Shop();
                            }
                            else
                            {
                                Console.WriteLine("You dont have enough gold to make a purchase");
                                Console.ReadLine();
                                Shop();
                            }
                            break;
                        case 2:
                            if (player.HasGold())
                            {
                                player.Endurance += shop.DefensePotion;
                                player.Pay();
                                Console.WriteLine($"You have now increased your endurance with {shop.DefensePotion}");
                                Console.WriteLine($"Your total endurance is now {player.Endurance}");
                                Console.ReadLine();
                                Shop();
                            }
                            else
                            {
                                Console.WriteLine("You dont have enough gold to make a purchase");
                                Console.ReadLine();
                                Shop();
                            }
                            break;
                        case 3:
                            if (player.HasGold())
                            {
                                player.Hp += shop.HealthPotion;
                                player.Pay();
                                Console.WriteLine($"You have now increased your hp with {shop.HealthPotion}");
                                Console.WriteLine($"Your total hp is now {player.Hp}");
                                Console.ReadLine();
                                Shop();
                            }
                            else
                            {
                                Console.WriteLine("You dont have enough gold to make a purchase");
                                Console.ReadLine();
                                Shop();
                            }
                            break;
                        case 4:
                            keepShopping = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input, please try again!");
                            break;
                    }
                }
            }
            catch { Console.WriteLine("Wrong input, please try again!"); Console.ReadLine(); Menu(); }
        }      
    }
}
