using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp.DungeonLibrary
{
    public class Monster : Character
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
            {//MinDamage can't exceed max and can't be less than 1
                _minDamage = (value > 0 && value < MaxDamage) ? value : 1;
            }
        }
        public string Description { get; set; }
        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description)
            :base(name, hitChance, block, maxLife)

        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
        }
        public Monster() 
        { 
            //added so we can create "default" monster subtypes. 
            //Name = "Baby Goblin"
            //HitChance = 15
            //Goblin babyGoblin = new Goblin()
        }
        public override string ToString()
        {
            return $"*****MONSTER*****\n{base.ToString()}\n" +
                $"Damage: {MinDamage} = {MaxDamage}\n" +
                $"Description: {Description}";
        }
        public override int CalcDamage()
        {
            //throw new NotImplementedException();
            return new Random().Next(MinDamage, MaxDamage + 1); //+ 1 because it's exclusive. 
        }
        

        public static Monster GetMonster()
        {
            //TODO come back to replace these monsters with your own monster subtypes later. 
            Monster m1 = new("First Monster", 50, 20, 25, 8, 2, "This is a test monster");
            Monster m2 = new("Second Monster", 70, 20, 25, 8, 2, "This is a test monster");
            Monster m3 = new("Third Monster", 55, 20, 25, 8, 2, "This is a test monster");
            Monster m4 = new("Fourth Monster", 65, 20, 25, 8, 2, "This is a test monster");

            List<Monster> monsters = new()
            { m1, m1, 
            m2, m2, m2, m2,
            m3, m3, m3,
            m4
            };

            Random rand = new Random();
            int index = rand.Next(monsters.Count);
            Monster monster = monsters[index];
            return monster;

        }//Monster life between 50 and 75, monster's block must be less than player hit chance. 
    } // IsFluffy = new Random().Next(100) <= 5; There is a 5% chance of the bunny being fluffy. 

}
