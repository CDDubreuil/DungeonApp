using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp.DungeonLibrary
{
    public class Room
    {
        private string _roomName;
        private int _roomNumber;
        private string _roomEncounter;
        private bool _roomExitNorth;
        private bool _roomExitSouth;
        private bool _roomExitWest;
        private bool _roomExitEast;


        public string RoomName { get { return _roomName; } set { _roomName = value; } }
        
        public int RoomNumber { get { return _roomNumber; } set { _roomNumber = value; } }
        
        public string RoomEncounter { get { return _roomEncounter; } set { _roomEncounter = value; } }
        public bool RoomExitNorth { get; set; }
        public bool RoomExitSouth { get; set; }
        public bool RoomExitWest { get; set; }  
        public bool RoomExitEast { get; set; }

        public Room(string roomName, int roomNumber, string roomEncounter, bool roomExitNorth, bool roomExitSouth, bool roomExitWest, bool roomExitEast)
        {
            RoomName = roomName;
            RoomNumber = roomNumber;
            RoomEncounter = roomEncounter; 
            RoomExitNorth = roomExitNorth;
            RoomExitSouth = roomExitSouth;
            RoomExitWest = roomExitWest;
            RoomExitEast = roomExitEast;

        }





















    }
}
