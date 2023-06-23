using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp.DungeonLibrary
{
    public class Human : Monster
    {

        private int _minDamage;
        public int MaxDamage { get; set; }

        public int MinDamage
        {
            get
            {
                return _minDamage;
            }

            set
            {
                _minDamage = (value > 0 && value < MaxDamage) ? value : 1;
            }
        }
        public string Description { get; set; }
        public Human (string name, int HitChance, int block, int maxLife, int maxDamage, int minDamage, string description)
            : base(name, HitChance, block, maxLife)

        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
        }
        public Human()
        {
           
        }
        public override string ToString()
        {
            return $"*****MONSTER*****\n{base.ToString()}\n" +
                $"Damage: {MinDamage} = {MaxDamage}\n" +
                $"Description: {Description}";
        }
        public override int CalcDamage()
        {
            
            return new Random().Next(MinDamage, MaxDamage + 1);
        }


        public static Human GetHuman()
        {
            
            Human h1 = new Human("Lone Wanderer", 50, 20, 25, 8, 2, "A wretched soul, moving aimlessly through the lands. ");
            Human h2 = new Human("Sneaky Thief", 70, 20, 25, 8, 2, "A lowly thief who will steal whatever they can to get by. ");
            Human h3 = new Human ("Bold Adventurer", 55, 20, 25, 8, 2, "A brave person who is roaming in search of glory and riches. ");
            Human h4 = new Human ("White Knight", 65, 20, 25, 8, 2, "A noble hero who has sworn to rid the lands of evil. ");

            List<Human> humans = new()
            { h1, h1,
            h2, h2, h2, h2,
            h3, h3, h3,
            h4
            };

            return humans[new Random().Next(0, humans.Count)];
          

        }
    } 

}