using QuestOfTheRing.Creatures;
using System;

namespace QuestOfTheRing
{
    internal class GameLogic
    {
        public Player player;
        public GameLevel gameLevel;
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║ * * * * * * * * * * * * * * * * ║");
            Console.WriteLine("║ *                             * ║");
            Console.WriteLine("║ *    The Quest of the Ring    * ║");
            Console.WriteLine("║ *                             * ║");
            Console.WriteLine("║ * * * * * * * * * * * * * * * * ║");
            Console.WriteLine("╚═════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nEnter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            player.IfRobin();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Oh fearless {player.Name}!");
            Console.WriteLine("The Ring has been found once again in Hobbiton, Frodo has failed to destroy it in the fires of Mount Doom.");
            Console.WriteLine($"The Quest to destroy the Ring once again has been assigned to you {player.Name}.");
            Console.WriteLine("Sauron has felt the Rings presence in Middle-Earth and darkness has fallen upon all creatures.");
            Console.WriteLine("The Ring is now in your possession, you must finish the Quest, take the path to Mordor and destroy \nthe Ring in the fires of Mount Doom once and for all.");
            player.HasRing = true;
            Console.WriteLine($"\nBe careful {player.Name}, one does not simply walk into Mordor.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n[PLAY]");

            Console.ReadLine();
            gameLevel = new GameLevel();
            Item.AddItems();
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
                    Console.WriteLine("══════════════════════════════════════");
                    Console.Write("\nNote: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(gameLevel.LevelNote);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n════ MENU ════");
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
                            break;
                        case 3:
                            Shop shop = new Shop();
                            shop.Menu(player);
                            break;
                        case 4:
                            Console.WriteLine("Oh, Leaving so soon?");
                            Console.WriteLine("You are leaving Middle-Earth in great danger..");
                            keepPlaying = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input in main menu, please try again!");
                            break;
                    }
                }
            }
            catch { Console.WriteLine("Wrong input in main menu, please try again!"); Console.ReadLine(); Menu(); }
        }

        public void GoOnQuest()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Creature.AddCreatures();

            var creature = Creature.GetRandomCreature(gameLevel);
            if (gameLevel.IfLastLevel())
            {
                AzogTheDefiler lastCreature = new AzogTheDefiler();
                creature = lastCreature;
            }
            creature.LevelUpgrade(gameLevel);
            if (RandomHelper.GetRandomNum(10) == 1)
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
                player.Attack(creature);
                Console.ReadLine();

                if (creature.IsDead(creature))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    if (gameLevel.IfLastLevel())
                    {
                        EndOfGame(creature);
                    }

                    creature.IsDefeated(creature);
                    creature.GiveExp(player);
                    var item = creature.DropItem();
                    if (item != null)
                    {
                        player.CollectItem(item);
                    }
                    player.TakeGold(creature);
                    player.LevelUp(gameLevel);
                    player.ShowCurrentDetails();
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

        public void EndOfGame(Creature creature)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"You have defeated {creature.Name} and are now standing just above the fires of Mount Doom");
            Console.WriteLine("The power to destroy the Ring is in your hands, will you throw the Ring in the fires of Mount Doom?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n[Y/N]");
            string input = Console.ReadLine();
            if (input.ToLower().Replace(" ", "") == "y")
            {
                player.HasRing = false;
                Console.Clear();
                Console.WriteLine($"Oh {player.Name} our saviour, you have thrown the Ring in the fires of Mount Doom and saved Middle-Earth!");
                Console.WriteLine("We are forever greatful and to show you our gratitude the elves has given you the Glamdring sword, \nwhich was forged in the First Age by the High Elves");
                Console.WriteLine($"\nFarewell oh mighty {player.Name}, until we meet again..");
                Console.WriteLine("\n╔═════════════╗");
                Console.WriteLine("║             ║");
                Console.WriteLine("║   THE END   ║");
                Console.WriteLine("║             ║");
                Console.WriteLine("╚═════════════╝");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("While you walked out of the gates of Mordor with the Ring still in your possession, \nGollum attacked you from behind and stabbed you with a knife!");
                Console.WriteLine("You are a traitor and failed to complete your Quest. \nThe Ring has returned in the hands of Sauron and the future of Middle-Earth is lost!");
                GameOver();
            }
        }

        public void GameOver()
        {
            player.HasRing = false;
            Console.WriteLine("\n╔═══════════════╗");
            Console.WriteLine("║               ║");
            Console.WriteLine("║   GAME OVER   ║");
            Console.WriteLine("║               ║");
            Console.WriteLine("╚═══════════════╝");
            Environment.Exit(0);
        }
    }
}