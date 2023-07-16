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

            Weapon w1 = new Weapon("Unarmed", 5, 15, 5, "No weapon equipped", WeaponType.Unarmed);
            Weapon w2 = new Weapon("Saw Cleaver", 10, 20, 10, "A serrated cleaver", WeaponType.Saw_Cleaver);
            Weapon w3 = new Weapon("Big Bonk", 15, 25, 10, "A heavy blunt weapon", WeaponType.Big_Bonk);
            List<Weapon> weapons = new()
            {
        w1, w2, w3
            };

            Player player = new Player(Race.None, null, 0, "", 50,50,50,50);
            
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
            player.Name = characterName;
            Console.Clear();
            Console.WriteLine("\nWhat manner of creature are you?\n");

            List<Race> race = new List<Race>()
            {
                Race.Unicorn,
                Race.Skeleton,
                Race.Necromancer,
                Race.Dragon,
                Race.Vampire,
                Race.Werewolf
            };



            for (int i = 0; i < race.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {race[i]}");
            }

            Console.WriteLine("Please select a race by entering its number");
            int raceIndex = 0;
            if (!int.TryParse(Console.ReadLine(), out raceIndex) || raceIndex < 1 || raceIndex > race.Count)
            { Console.WriteLine("Invalid race selection"); }
            else
            {
                
                Race selectedRace = race[raceIndex - 1];
                player.PlayerRace = selectedRace;
                Console.WriteLine($"Selected race: {selectedRace}");
                string raceDesc = GetRaceDesc(selectedRace);
                Console.WriteLine($"Description: {raceDesc}");
                static string GetRaceDesc(Race race)
                {

                    switch (race)
                    {
                        case Race.Unicorn:
                            return "\nIt's not all sunshine and rainbows anymore.";
                        case Race.Skeleton:
                            return "\nNot sure how they plan on killing you when you're already dead. ";
                        case Race.Necromancer:
                            return "\nYou've never met a corpse you didn't like. ";
                        case Race.Dragon:
                            return "\nHonestly if you really wanted to, you could just barbecue all these people who are lurking about.";
                        case Race.Vampire:
                            return "\nYou really hope none of these dungeon delvers are Italian. ";
                        case Race.Werewolf:
                            return "\nYou spent 6 hours brushing your hair this morning.";
                        default:
                            return "..";
                    }


                }



                for (int i = 0; i < weapons.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {weapons[i].Name}");
                }

                Console.WriteLine("Please select a weapon by entering its number");
                int weaponIndex = 0;
                if (!int.TryParse(Console.ReadLine(), out weaponIndex) || weaponIndex < 1 || weaponIndex > weapons.Count)
                { Console.WriteLine("Invalid weapon selection"); }
                else
                {
                    Weapon selectedWeapon = weapons[weaponIndex - 1];
                    
                    player.EquippedWeapon = selectedWeapon;
                    Console.WriteLine($"Selected weapon: {selectedWeapon.Name}");
                    string weaponDesc = GetWeaponDesc(selectedWeapon.Type);
                    Console.WriteLine($"Description: {weaponDesc}");
                    static string GetWeaponDesc(WeaponType weapon)
                    {
                        switch (weapon)
                        {
                            case WeaponType.Unarmed:
                                return "You didn't bother grabbing any weapons";
                            case WeaponType.Saw_Cleaver:
                                return "This thing is covered in blood already. Gross";
                            case WeaponType.Big_Bonk:
                                return "Unga bunga";
                            default:
                                return "Unknown weapon";
                        }



                    }


                    Room entrance = new("The entrance to the dungeon awaits", 1, true, false, false, false);
                    
                    bool quit = false;
                    do
                    {



                        Monster monster = Monster.GetMonster();
                        Console.WriteLine(GetRoom());
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
                                    int playerHitChance = player.CalcHitChance();
                                    int monsterHitChance = monster.CalcHitChance();
                            int playerDamage = player.CalcDamage();
                            int monsterDamage = monster.CalcDamage();
                            switch (action)
                            {
                                case '1':
                                    Console.WriteLine("Attack!");
                                    if (playerHitChance >= monsterHitChance)
                                    {
                                        //int playerDamage = player.CalcDamage();
                                        monster.Life -= playerDamage;
                                        player.Life -= monsterDamage;
                                    }
                                    if (monster.Life <= 0)
                                    {
                                        Console.WriteLine("The intruder has been defeated");
                                        player.Score++;
                                        reload = true;
                                    }
                                    else
                                    {
                                    //int monsterDamage = monster.CalcDamage();
                                        player.Life -= monsterDamage;
                                        Console.WriteLine($"You hit the enemy for {playerDamage} damage!");
                                        Console.WriteLine($"The enemy fights back and wounds you for {monsterDamage} damage!");
                                    
                                    }
                                    if (playerDamage == 0)
                                    {
                                        Console.WriteLine("you missed the enemy!");
                                    }
                                    break;
                                case '2':
                                    Console.WriteLine("Run Away!!");
                                    reload = true;
                                    break;
                                case '3':
                                    Console.WriteLine("Player info: ");
                                    Console.WriteLine(player);
                                    Console.WriteLine($"Player Race: {player.PlayerRace}");
                                    Console.WriteLine($"Equipped Weapon: {player.EquippedWeapon.Name}");
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
                            if (player.Life <= 0)
                            {
                                Console.WriteLine("Dude... You died!\a");
                                quit = true;
                            }

                        } while (!reload && !quit);


                    } while (!quit);

                    Console.WriteLine("You defeated " + player.Score +
                        " monster" + (player.Score == 1 ? "." : "s."));





                    static string GetRoom()
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
        }
    }
}