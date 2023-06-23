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
            Console.WriteLine("Hello Adventurer! Welcome to the Dungeon of Doom!");
            #endregion

            #region Player Creation
            //Player Creation, after we've learned how to create custom Datatypes.
            //Reference the notes in the TestHarness for some ideas of how to expand player creation.

            //Potential expansion - Let the user choose from a list of pre-made weapons.
            Weapon sword = new("Lightsaber", 1, 8, 10, true, WeaponType.Sword);

            //Potential Expansion - Let the user choose their name and Race
            Player player = new("Leeroy Jenkins", Race.Human, sword);

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
                            //TODO Combat functionality
                            break;
                        case '2':
                            Console.WriteLine("Run Away!!");
                            //TODO Give the monster a free attack chance

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
                            Console.WriteLine("No one likes a quitter!");
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
                "The walls are adorned with portraits of fearsome dragons, while a stuffed unicorn head hangs above the fireplace.",
                "An enormous crystal chandelier hangs from the ceiling, casting a rainbow of colors across the room.",
                "A giant mushroom serves as the centerpiece of the room, surrounded by whimsical fairy lights.",
                "The floor is covered in a thick layer of soft, green moss, making it feel like you're walking on a forest floor.",
                "A bookshelf filled with magical tomes lines one wall, while a cauldron bubbles away in the corner.",
                "A suit of armor stands guard at the entrance, but it seems to be nodding off on the job.",
                "A large stone fireplace dominates the room, but instead of wood, it's filled with shimmering gold coins.",
                "A giant spiderweb stretches across the ceiling, with a creepy-crawly arachnid lurking nearby.",
                "A bed shaped like a giant clamshell takes up most of the space, complete with a fluffy pearl-white comforter.",
                "A gargoyle perched on the windowsill keeps watch over the room, occasionally shooting a jet of water out of its mouth."
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