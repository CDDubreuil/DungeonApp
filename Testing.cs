using DungeonApp.DungeonLibrary;
using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DungeonApp
{
    public class Testing
    {
        
    
    static void Main(string[] args)
        {

            


            Player player = new Player("raceName",UserWeapon.Unarmed, 0, "name", 75, 75, 120, 120);
            Console.WriteLine("You come upon a decrepit castle, crumbling after eras of disuse. Vines snake around the walls. Bone shards stand out\n starkly against the dark earth. " +
                "You sigh with contentment. Home.\n");
            // Thread.Sleep(6000);
            // Console.Clear();
            Console.WriteLine("You freeze. Voices. Inside the castle walls. You warily creep in and see that soldiers from the nearby kingdom have set up camp in your home. Furiously you prepare yourself.\n");
            //  Thread.Sleep(6000);
            // Console.Clear();
            Console.WriteLine("Time to DEFEND YOUR DUNGEON.\n");
            // Thread.Sleep(3000);
            // Console.Clear();
            Console.WriteLine("No man will over take your home, or else your name isn't....wait, what was your name again?\n");
            string characterName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nWhat manner of creature are you?\n");

            static UserRace GetUserRace()
            {
                while (true)
                {
                    foreach (var item in Enum.GetNames(typeof(UserRace)))
                    {
                        Console.WriteLine(item);
                    }
                    string raceInput = Console.ReadLine();
                    if (Enum.TryParse<UserRace>(raceInput, out UserRace selectedRace))
                    { return selectedRace; }
                    Console.WriteLine("Invalid");
                }
            }

            UserRace selectedRace = GetUserRace();
            string raceDesc = GetRaceDesc(selectedRace);


            string GetRaceDesc(UserRace race)
            {
                switch (race)
                {
                    case UserRace.Unicorn:
                        return "\nIt's not all sunshine and rainbows anymore.";
                    case UserRace.Zombie:
                        return "\nYou sure won't make any friends with that pretty face of yours. ";
                    case UserRace.Skeleton:
                        return "\nNot sure how they plan on killing you when you're already dead. ";
                    case UserRace.Necromancer:
                        return "\nYou've never met a corpse you didn't like. ";
                    case UserRace.Dragon:
                        return "\nHonestly if you really wanted to, you could just barbecue all these people who are lurking about.";
                    case UserRace.Vampire:
                        return "\nYou really hope none of these dungeon delvers are Italian. ";
                    case UserRace.Werewolf:
                        return "\nYou spent 6 hours brushing your hair this morning.";
                    default:
                        return "..";
                }
            }

            string raceName = Console.ReadLine();
            Console.WriteLine($"Description: {raceDesc}");

            player.Race = raceName;



            


            Console.WriteLine("\nFilled with rage, you grip your weapon. It is a: \n");



            static UserWeapon GetUserWeapon()
            {
                while (true)
                {
                    foreach (var item in Enum.GetNames(typeof(UserWeapon)))
                    {
                        Console.WriteLine(item);
                    }
                    string weaponInput = Console.ReadLine();
                    if (Enum.TryParse<UserWeapon>(weaponInput, out UserWeapon selectedWeapon))
                    { return selectedWeapon; }
                    Console.WriteLine("Invalid");
                }
            }

            UserWeapon selectedWeapon = GetUserWeapon();
            string weaponDesc = GetWeaponDesc(selectedWeapon);


            string GetWeaponDesc(UserWeapon weapon)

            {
                switch (weapon)
                {
                    case UserWeapon.Unarmed:
                        return "\nYou don't bother grabbing any weapons.";
                    case UserWeapon.Saw_Cleaver:
                        return "\nThis thing is covered in blood already. Gross.";
                    case UserWeapon.Big_Bonk:
                        return "\nUnga Bunga. ";
                    case UserWeapon.Spatula:
                        return "\nIt's pretty okay at smacking things. ";
                    case UserWeapon.Wabbajack:
                        return "\nYou have absolutely no clue what this staff does. ";
                    case UserWeapon.Crystal_Staff:
                        return "\nThe most stereotypical staff you can imagine.";
                    case UserWeapon.Staff_of_Sluggishness:
                        return "\nYou suppose this staff makes everyone feel...sluggish? ";
                    
                    default:
                        return "..";
                }
            }


            //string GetWeaponDesc(UserWeapon weapon)
            //{

            //}




            string weapon = Console.ReadLine();
         
           selectedWeapon = player.UserWeapon;


            

            Room entrance = new("The entrance to the dungeon awaits", 1, true, false, false, false);
            Player playerOne = new Player(raceName, UserWeapon.selectedWeapon, 0, characterName, 75, 75, 120, 120);








            bool quit = false;
            do
            {


                Console.WriteLine(GetRoom());

                Monster monster = Monster.GetMonster();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIn this room is a " + monster.Name);
                Console.ResetColor();






                bool reload = false;
                do
                {
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
                            break;
                        case '2':
                            Console.WriteLine("Run Away!!");
                            reload = true;
                            break;
                        case '3':
                            Console.WriteLine("Player info: ");
                            Console.WriteLine(playerOne);
                            break;

                        case '4':
                            Console.WriteLine("Monster info: ");
                            Console.WriteLine(monster);
                            break;

                        case '5':
                            Console.WriteLine("No one likes a quitter!");
                            quit = true;
                            break;

                        default:
                            Console.WriteLine("Do you think this is a game?? Quit playing around!");
                            break;
                    }
                    if (playerOne.Life <= 0)
                    {
                        Console.WriteLine("Dude... You died!\a");
                        quit = true;
                    }

                } while (!reload && !quit);


            } while (!quit);

            Console.WriteLine("You defeated " + playerOne.Score +
                " monster" + (playerOne.Score == 1 ? "." : "s."));

        }



        public static string GetRoom()
        {
            string[] rooms =
            {"The crypts have been disturbed. Granny Hildegarde is in pieces on the floor. You sigh. It'll take weeks to gather enough materials to summon her again.",
             "You enter the library and see that these barbarians have scattered the books across the floor. Have they never been taught to reshelf things??",
             "Your beautiful dragon wife is sitting in the center of the cavernous room, fuming. There are piles of fresh humans strewn around her. You assure her that you will take care of the intruders, " +
             "more to comfort yourself than her. She can clearly handle the situation just fine. ",
             "You don't know what the interlopers did, but when you go into your ritual space, there is an ominously glowing portal. You hesitate, then step through it. \n\nA room the likes of which you've never seen before appears before you. " +
             "The lights are cold and flicker, despite having no visible flames. A thick, oily stench hangs in the air, and there is a chill that gnaws at your bones. Signs all over the room are" +
             "covered in strange letters. You don't know what they mean, but see a string of symbols reoccuring across all of them. WAFFLE HOUSE. The few other beings here look haggard and worn, some seem hostile. You are surrounded by food and what appear to be cooking utensils. " +
             "You grab one of these unknown tools for protection, along with what seems to be a strange flat bread with a gridlike pattern indented across the surface of it. You back away through your portal and immediately destroy the sigils surrounding that cursed doorway.",
             "The astrology tower echoes with the sounds of clanging armor. Your richly embroidered tapestries depicting the constellations have been slashed. ",
             "This room once housed your vast antique pottery collection. Some inconsiderate fool appears to have rolled through them all, smashing them all to shards. You are furious, as a good argillomancer is incredibly expensive to hire."
            };

            Random rand = new Random();
            //rooms.Length;
            int index = rand.Next(rooms.Length);
            string room = rooms[index];
            return room;

            //Refactor:
           // return rooms[new Random().Next(rooms.Length)];
        }
        //  End GetRoom();

    }
}