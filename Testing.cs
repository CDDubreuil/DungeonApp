using DungeonApp.DungeonLibrary;
using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonApp
{
    public class Testing
    {


        static void Main(string[] args)
        {
            Console.Title = "Dungeon Defender";


            Weapon w1 = new Weapon("Unarmed", 5, 15, 5, "No weapon equipped",  WeaponType.Unarmed);
            Weapon w2 = new Weapon("Rusty Sword", 10, 20, 10, "A rusty old sword", WeaponType.Rusty_Sword);
            Weapon w3 = new Weapon("Big Bonk", 15, 30, 10, "A massive club", WeaponType.Big_Bonk);
            Weapon w4 = new Weapon("Wooden Bow", 10, 20, 25, "A sleek bow",  WeaponType.Wooden_Bow);
            Weapon w5 = new Weapon("Flame Staff", 15, 25, 20, "A sizzling staff",WeaponType.Flame_Staff);
            List<Weapon> weapons = new()
            {
        w1, w2, w3, w4, w5
            };

            Player player = new Player(Race.None, null, 0, 10, 10, 10, 10, "", 50, 50, 120, 120);
            
            Console.WriteLine("You come upon a decrepit castle, crumbling after eras of disuse. Vines snake around the walls. Bone shards stand out\n starkly against the dark earth. " +
                "You sigh with contentment. Home.\n");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("You freeze. Voices echo joyously from nside the castle walls. You warily creep in and see that soldiers from the nearby kingdom have set up camp in your home. Furiously you prepare yourself.\n");
            Thread.Sleep(3000);
            Console.Clear();
         
            Console.WriteLine("No man will over take your home, or else your name isn't....wait, what was your name again?\n");
            string characterName = Console.ReadLine();
            player.Name = characterName;
            Console.Clear();
            Console.WriteLine("\nWhat kind of creature are you?\n");

            List<Race> race = new List<Race>()
            {
               
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
                Console.WriteLine($"{raceDesc}");
                static string GetRaceDesc(Race race)
                {

                    switch (race)
                    {
                        case Race.Skeleton:
                            return "\nNot sure how they plan on killing you when you're already dead. ";
                            break;
                        case Race.Necromancer:
                            return "\nYou've never met a corpse you didn't like. ";
                            break;
                        case Race.Dragon:
                            return "\nHonestly if you really wanted to, you could just barbecue all these people who are lurking about.";
                            break;
                        case Race.Vampire:
                            return "\nYou really hope none of these dungeon delvers are Italian. ";
                            break;
                        case Race.Werewolf:
                            return "\nYou spent 6 hours brushing your hair this morning.";
                            break;
                        default:
                            return "..";
                            break;
                    }


                }

                player.CalculateStats();
                player.MaxLife += player.RaceHealth;
                Console.Clear();

                Console.WriteLine("Hissing furiously, you grab your weapon. It is a: \n");

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
                            case WeaponType.Rusty_Sword:
                                return "This thing is covered in blood already. Gross";
                            case WeaponType.Wooden_Bow:
                                return "A simple and sleek bow";
                            case WeaponType.Big_Bonk:
                                return "Unga bunga";
                            case WeaponType.Flame_Staff:
                                return "This spicy little staff used to do healing spells until you spilled a bottle of Sriracha on it";
                            default:
                                return "Unknown weapon";
                        }



                    }

                    selectedWeapon.CalculateWeapon(player);
                    Console.Clear();
                  
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
                            playerHitChance += player.RaceAgility;
                            playerDamage += player.RaceStrength;
                          
                            int trueMonsterDamage = Math.Max(monsterDamage - player.RaceDefense, 0);
                            int truePlayerDamage = playerDamage + player.RaceStrength;
                            int truePlayerHitChance = playerHitChance + player.RaceAgility;
                          
                            int trueLife = player.Life + player.RaceHealth;

                            switch (action)
                            {
                                case '1':
                                    Console.WriteLine("Attack!");
                                    if (truePlayerHitChance >= monsterHitChance)
                                    {
                                        //int playerDamage = player.CalcDamage();
                                        monster.Life -= truePlayerDamage;
                                        
                                    }
                                    if (monster.Life <= 0)
                                    {
                                        Console.WriteLine("The intruder has been defeated");
                                        player.Score++;
                                        reload = true;
                                    }
                                    else
                                    {
                                      
                                        Console.WriteLine($"You hit the enemy for {truePlayerDamage} damage!");
                                        player.Life -= trueMonsterDamage;
                                        Console.WriteLine($"The enemy fights back and wounds you for {trueMonsterDamage} damage!");
                                       
                                    }
                                    if (truePlayerDamage == 0)
                                    {
                                        Console.WriteLine("you missed the enemy!");
                                    }

                                    if (player.Life <= 0)
                                    {
                                        Console.WriteLine("You died.\a");
                                        quit = true;
                                    }
                                   
                                  
                                    break;
                                case '2':
                                    Console.WriteLine("Run Away!!");
                                    reload = true;
                                    break;
                                case '3':
                                    Console.WriteLine("Player info: ");
                                    Console.WriteLine(player.ToString());
                                    Console.WriteLine($"Weapon Damage: {selectedWeapon.MinDamage} - {selectedWeapon.MaxDamage}");
                                    Console.WriteLine($"Weapon Bonus Hit Chance: {selectedWeapon.BonusHitChance} %");
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
             "You hear voices echoing through the halls as soon as you enter. Some of your favorite cobwebs have been brushed away.",
             "You exit the kitchen, and find yourself in a jarringly quaint and beautiful garden. Small, delicate fairies flit around. Your heart saddens as you realize the intruders have disturbed them. They are too sour to eat now. ",
             "The astrology tower echoes with the sounds of clanging armor. Your richly embroidered tapestries depicting the constellations have been slashed. Your ritual to summon your patron to destroy the kingdom nearby has been disrupted. You're gonna be in a lot of trouble later.",
             "This room once housed your vast antique pottery collection. Some inconsiderate fool appears to have rolled through them all, smashing them all to shards. You are furious, it took you decades to steal all that pottery.",
             "You enter the large greenhouse. Instantly you can feel yourself struggle to breathe in the steamy heat. A small band of warriors had evidently come in here earlier, but were no match for the giant carnivorous plants you lovingly cultivate here.",
              "The Courtyard is filled with tents and various sundry items. You spitefully cut loose the horses and scare them off before you are spotted."         
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