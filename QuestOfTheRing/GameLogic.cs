using QuestOfTheRing.Interfaces;
using QuestOfTheRing.Creatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    class GameLogic
    {
        public Player player;
        public GameLevel gameLevel;
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* *                             * *");
            Console.WriteLine("* *    The Quest of the Ring    * *");
            Console.WriteLine("* *                             * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * *");


            Console.Write("\nEnter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            Console.Clear();
            Console.WriteLine($"Oh fearless {player.Name}!");
            Console.WriteLine("The Ring has been found once again in Hobbiton, Frodo has failed to destroy it in the fires of Mount Doom.");
            Console.WriteLine($"The Quest to destroy the Ring once again has been assigned to you {player.Name}.");
            Console.WriteLine("Sauron has felt the Rings presence in Middle-Earth and darkness has fallen upon all creatures.");
            Console.WriteLine("The Ring is now in your possession, you must finish the Quest, take the path to Mordor and destroy \nthe Ring in the fires of Mount Doom once and for all.");
            player.HasRing = true;
            Console.WriteLine($"\nBe careful {player.Name}, one does not simply walk into Mordor.");
            Console.WriteLine();
            Console.WriteLine("[PLAY]");

            Console.ReadLine();
            gameLevel = new GameLevel();
            Menu();
        }
        public void Menu()
        {          
            try
            {
                bool keepPlaying = true;

                while (keepPlaying)
                {
                    gameLevel.AddLevelData();
                    gameLevel.GetLevelInfo();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine($"You are on level: {gameLevel.Level}");
                    Console.WriteLine($"You have reached: {gameLevel.Place}");
                    Console.WriteLine("********************************************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Note: " + gameLevel.LevelNote);
                    Console.ForegroundColor = ConsoleColor.Yellow;
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
                            player.Details(gameLevel);
                            Console.ReadLine();
                            break;
                        case 3:
                            Shop();
                            break;
                        case 5:
                            Console.WriteLine("Oh, Leaving so soon?");
                            Console.WriteLine("You are leaving Middle-Earth in great danger..");
                            keepPlaying = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input, please try again!");
                            break;
                    }
                }
            }
            catch { Console.WriteLine("Wrong input, please try again!"); Console.ReadLine(); Menu(); }
        }

        public void GoOnQuest()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            AddCreatures();
            Creature creature = (Creature)Creature.GetRandomCreature();
            creature.LevelUpgrade(gameLevel);

            int randomNum = RandomHelper.GetRandomNum(10);

            if (randomNum == 1)
            {
                Console.WriteLine("Be patient, you are walking on your path to Mordor..");
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
        
        public void FightCreature(Creature creature)
        {
            bool fightMode = true;
            while (fightMode)
            {
                Console.Clear();
                if(gameLevel.IfLastLevel())
                {
                    AzogTheDefiler lastCreature = new AzogTheDefiler();
                    creature = lastCreature;
                }

                player.Attack(creature);              
                Console.ReadLine();               

               if (creature.IsDead(creature))
               {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    
                    if (gameLevel.IfLastLevel())
                    {
                        EndOfGame(creature);
                    }

                    creature.IsDefeated(creature);
                    creature.GiveExp(player);
                    player.TakeGold(creature);
                    player.LevelUp(gameLevel);
                    player.ShowCurrentDetails();
                    Console.ReadLine();
                    Menu();
               }                
                creature.Attack(player);
                Console.ReadLine();

                if (player.IsDead())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou are defeated and failed to complete your Quest. \nThe Ring has returned in the hands of Sauron and the future of Middle-Earth is lost!");
                    GameOver();
                }

                Console.WriteLine($"\n{player.Name}: {player.Hp} hp");
                Console.WriteLine($"{creature.Name}: {creature.Hp} hp");
                Console.ReadLine();
            }
        }    
        public void EndOfGame(Creature creature)
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
                Console.WriteLine("You are a traitor and failed to complete your Quest. \nThe Ring has returned in the hands of Sauron and the future of Middle-Earth is lost!");
                GameOver();
            }
        }
        public void Shop()
        {
            bool keepShopping = true;
            try
            {
                while (keepShopping)
                {                  
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("[SHOP]");
                    Console.WriteLine("What would you like to buy?");
                    Console.WriteLine($"You have {player.Gold} gold");
                    Console.WriteLine("********************************************");
                    Console.WriteLine("1. Strength Potion (+ 5 Strength) - 100 gold");
                    Console.WriteLine("2. Defense Potion (+ 2 toughness) - 100 gold");
                    Console.WriteLine("3. Healing Potion (+ 100 health) - 50 gold");
                    Console.WriteLine("4. Exit shop");
                    Console.Write("> ");
                    int input = Convert.ToInt32(Console.ReadLine());
                    Shop shop = new Shop();
                    switch (input)
                    {
                        case 1:
                            shop.BuyStrengthPotion(player);                            
                            break;
                        case 2:
                            shop.BuyDefensePotion(player);
                            break;
                        case 3:
                            shop.BuyHealingPotion(player);
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
        public void GameOver()
        {
            player.HasRing = false;
            Console.WriteLine("\n*************");
            Console.WriteLine("* GAME OVER *");
            Console.WriteLine("*************");
            Environment.Exit(0);
        }
        public void AddCreatures()
        {
            Creature.listOfCreatures.Clear();
            Creature.listOfCreatures.Add(new Hobbit());
            Creature.listOfCreatures.Add(new Dwarf());
            Creature.listOfCreatures.Add(new Elf());
            Creature.listOfCreatures.Add(new Ent());
            Creature.listOfCreatures.Add(new Troll());
            Creature.listOfCreatures.Add(new Ogre());
            Creature.listOfCreatures.Add(new Wizard());
            Creature.listOfCreatures.Add(new Nazgul());
            Creature.listOfCreatures.Add(new Orc());
        }
    }
}
