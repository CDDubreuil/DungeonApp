using DungeonApp.DungeonLibrary;
using DungeonLibrary;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            //TODO Intro
            Console.WriteLine("DUNGEON DEFENDER");
            #endregion

            #region Player Creation
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + ", please choose a race: ");
            foreach (Race value in Enum.GetValues(typeof(Race)))
            {
                Console.WriteLine(value);
            }


            string userRace = Console.ReadLine();

            //Player Creation, after we've learned how to create custom Datatypes.
            //Reference the notes in the TestHarness for some ideas of how to expand player creation.

            //Potential expansion - Let the user choose from a list of pre-made weapons.
            Weapon sword = new("Lightsaber", 1, 8, 10, true, WeaponType.Sword);

            //Potential Expansion - Let the user choose their name and Race
            Player player = new(name, 75, 50, 120, Race.Lich, sword);

            player.Score = 0;
            #endregion

            //Outer Loop
            bool quit = false;
            do
            {
                #region Monster and room generation
                //We need to generate a new monster and a new room for each encounter.                
                //TODONE Generate a room - random string description
                Console.WriteLine(GetRoom());
                //Generate a Monster (custom datatype) 
                Monster monster = Monster.GetMonster();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIn this room is a " + monster.Name);
                Console.ResetColor();
                #endregion

                #region Encounter Loop                
                //This menu repeats until either the monster dies or the player quits, dies, or runs away.
                bool reload = false;//set to true to "reload" the monster & the room
                do
                {
                    #region Menu
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "1) Attack\n" +
                        "2) Run away\n" +
                        "3) Player Info\n" +
                        "4) Monster Info\n" +
                        "5) Exit\n");

                    char action = Console.ReadKey(true).KeyChar;
                    Console.Clear();
                    switch (action)
                    {
                        case '1':
                            Console.WriteLine("Attack!");
                           Combat.DoBattle( player,  monster);
                            break;
                        case '2':
                            Console.WriteLine("Run Away!");
                            //TODO Give the monster a free attack chance
                            Combat.DoAttack(monster, player);
                            //Leave the inner loop (reload the room) and get a new room & monster.
                            reload = true;
                            break;
                        case '3':
                            Console.WriteLine("Player info: ");
                            //print player details to the screen
                            Console.WriteLine(player);
                            break;

                        case '4':
                            Console.WriteLine("Monster info: ");
                            //print monster details to the screen
                            Console.WriteLine(monster);
                            break;
                       
                        case '5':
                            //quit the whole game. "reload = true;" gives us a new room and monster, "quit = true" quits the game, leaving both the inner AND outer loops.
                            Console.WriteLine("You give up, and leave your dungeon for the last time. Goodbye.");
                            quit = true;
                            break;

                        default:
                            Console.WriteLine("Do you think this is a game?? Quit playing around!");
                            break;
                    }//end switch
                    #endregion
                    //Check Player Life. If they are dead, quit the game and show them their score.
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude... You died!\a");
                        quit = true;//leave both loops.
                    }

                } while (!reload && !quit); //While reload and quit are both FALSE (!true), keep looping. If either becomes true, leave the inner loop.
                #endregion

            } while (!quit);//While quit is NOT true, keep looping.

            #region Exit
            Console.WriteLine("You defeated " + player.Score +
                " monster" + (player.Score == 1 ? "." : "s."));
            #endregion
        }//End Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "Your beloved room of antique pottery has been ransacked." +
                " Clearly, a reckless fiend has been rolling around into your pots, reveling in the damage they caused.",

                "Tragically, your beloved altar has been desecrated. All of your hard-earned dragon skulls and troll-fat" +
                "candles have been moved around, and your prized soul gems are missing. The Great One will not be pleased with this setback.",

                "The catacombs are in dire shape. Coffins have been smashed, the gold and prized heirlooms stolen from those who are resting inside. " +
                "Great-Uncle Hrothgar and Granny Magdalene are in pieces across the floor." +
                "You sigh in frustration. You only just summoned them yesterday. It'll take so much work to raise them again. ",

                "In your alchemical laboratory, a strange liquid bubbles in your cauldron. Someone has recently tried to brew a potion" +
                "in it, and it clearly backfired. *Sigh* This thing is cast iron. You hope you don't have to reseason it. All your " +
                "best ingredients are gone too. Only some garlic and a handful of small white flowers are left, having rolled under" +
                "the table. ",

                "In the entrance to your dungeon, a warm fire crackles. The aroma of stew full of venison and spices wafts through the air. Disgusting. You can't believe someone" +
                "would ruin perfectly good meat by burning it and mixing it with plants. ",

                "In the Midden, the wretches and wraiths that lived down there have been slain. Now where are you going to get body parts from when it is time to summon" +
                "your master?? You'll have to start raiding camps again, like a common barbarian.",

                "The library horrifies you. Some spellbooks have been taken, and other books have been reshelved. " +
                "You had gone through and meticulously stacked and organized them for your rituals, and some ignorant fool has ruined hours of careful planning.",

                "The vast cavern you step into is full of spiderwebs. Dew glistens on the delicate threads. Your sweet, eight-legged friends lay splattered across" +
                "the ground. Even the brood mother didn't escape the carnage. Only a few egg sacs remain untouched. Your heart aches, and you make a mental note to come back" +
                "and tend to the few remaining unhatched babies after you get your revenge. " 
           
            };

            Random rand = new Random();
            //rooms.Length
            int index = rand.Next(rooms.Length);
            string room = rooms[index];
            return room;

            //Refactor:
            //return rooms[new Random().Next(rooms.Length)];
        }//End GetRoom()

    }//End class
}//end namespace