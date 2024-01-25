using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp.DungeonLibrary
{
    public class Room

//I'd actually like to come in and use this class to make the dungeon linear using a system of bools to move the player cardinal directions, and I want to make an ascii map so the player
//doesn't get lost. I encountered lots of setbacks last week though so I don't have time for that yet.


    {
        private string _roomName;
    private int _roomNumber;
    private string _roomDescription;
    private bool _roomExitNorth;
    private bool _roomExitSouth;
    private bool _roomExitWest;
    private bool _roomExitEast;


    public string RoomName { get; set; }

    public int RoomNumber { get; set; }

    public string RoomDescription { get; set; }
    public bool RoomExitNorth { get; set; }
    public bool RoomExitSouth { get; set; }
    public bool RoomExitWest { get; set; }
    public bool RoomExitEast { get; set; }

    public Room(string roomName, int roomNumber, string roomDescription, bool roomExitNorth, bool roomExitSouth, bool roomExitWest, bool roomExitEast)
    {
        RoomName = roomName;
        RoomNumber = roomNumber;
        RoomDescription = roomDescription;
        RoomExitNorth = roomExitNorth;
        RoomExitSouth = roomExitSouth;
        RoomExitWest = roomExitWest;
        RoomExitEast = roomExitEast;

        }
        //Room courtyard = new Room("The Courtyard", 1, "The Courtyard is filled with tents and various camping supplies. You spitefully cut loose the horses and scare them off before you are spotted.", false, true, false, false);
        //Room entranceHall = new Room("The Entrance Hall", 2, "You hear voices echoing through the halls as soon as you enter. Some of your favorite cobwebs have been brushed away. \n To the east is the Great Hall. To the south is the library. West leads to an armory.", true, true, true, true);
        //Room greatHall = new Room("The Great Hall", 3, "This once was the room where a great king dined with his companions and guests. Now it's where you toss spare bodies when you run out of space in the crypt", false, true, true, false);
        //Room fairyGarden = new Room("The Fairy Garden", 4, "You exit the kitchen, and find yourself in a jarringly quaint and beautiful garden. Small, delicate fairies flit around. Your heart saddens as you realize the intruders have disturbed these sweet creatures.", false, false, false, true);
        //Room greenHouse = new Room("The Greenhouse", 5, "You enter the large greenhouse. Instantly you can feel yourself struggle to breathe in the steamy heat. A small band of warriors had evidently come in here earlier, but were no match for the giant carnivorous plants you lovingly cultivate here. ")
        //Room crypt = new Room("The Crypt", 6, "The crypts have been disturbed. Granny Hildegarde is in pieces on the floor. You sigh. It'll take weeks to gather enough materials to summon her again.", 
        //Room spiderNest = new Room("The Spider Nest, 7, "The vast cavern you step into is full of spiderwebs. Dew glistens on the delicate threads. Your sweet, eight-legged friends lay splattered across the ground. Even the brood mother didn't escape the carnage. Only a few egg sacs remain untouched. Your heart aches, and you make a mental note to come back and tend to the few remaining unhatched babies after you get your revenge.", )
        //Room observatory = new Room("The Observatory, 8, "The astrology tower echoes with the sounds of clanging armor. Your richly embroidered tapestries depicting the constellations have been slashed. Your ritual to summon your patron to destroy the kingdom nearby has been disrupted. You're gonna be in a lot of trouble later.
        //Room privateChambers = new Room("Your Private Chambers, 9, "Your beautiful dragon wife is sitting in the center of the cavernous room, fuming. There are piles of fresh humans strewn around her. You assure her that you will take care of the intruders, more to comfort yourself than her. She can clearly handle the situation just fine.", )
        //Room alchemyLab = new Room("The Alchemy Lab, 10, "You shriek with rage when you see that someone not only emptied out the griffin wing stew you make, but they also scrubbed the pot out. That was an ancient cast iron cauldron that had been seasoned for several centuries, now ruined by some pathetic do-gooder.", )
        //Room kitchen = new Room("The Kitchen", 11, "Some ruffian is digging through your cabinets. They see you and immediately brandish one of your carving knives, declaring that you are an enemy of the king who must be vanquished.", )
        //Room dungeonDungeon = new Room("Into the Depths of the Dungeon", 12, "In the deepest depths of your castle is a vast cavern. It is filled with the sound of water dripping on the dirt and stone floor. Bones and moss cover the ground. "
        //Room potteryDisplay = new Room("The Pottery Collection", 13, "This room once housed your vast antique pottery collection. Some inconsiderate fool appears to have rolled through them all, smashing them all to shards. You are furious, it took you decades to steal all that pottery.", )
      
    }
}
