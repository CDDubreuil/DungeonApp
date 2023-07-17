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
        
        public Monster(string name, int hitChance, int block, int maxLife, int life, int maxDamage, int minDamage, string description)
            :base(name, hitChance, block, maxLife, life)

        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
        }
      
        public override string ToString()
        {
            return $"*****MONSTER*****\n{base.ToString()}\n" +
                $"Damage: {MinDamage} = {MaxDamage}\n" +
                $"Description: {Description}";
        }
        public override int CalcDamage()
        {
           int damage = new Random().Next(MinDamage, MaxDamage + 1);
            Life -= damage;
            return new Random().Next(MinDamage, MaxDamage + 1); //+ 1 because it's exclusive. 
        }
        

        public static Monster GetMonster()
        {
            
            Monster h1 = new Human("Lone Wanderer", 50, 20, 50, 35, 15, 5,  "A wretched soul, moving aimlessly through the lands. ");
            Monster h2 = new Human("Sneaky Thief", 70, 40, 85, 60, 30, 10,  "A lowly thief who will steal whatever they can to get by. ");
            Monster h3 = new Human("Bold Adventurer", 55, 55, 75, 75, 40, 15, "A brave person who is roaming in search of glory and riches. ");
            Monster h4 = new Human("White Knight", 65, 60, 145, 125, 50, 25,  "A noble hero who has sworn to rid the lands of evil. ");


            Monster d1 = new Dwarf("Bearded Lady", 50, 20, 70, 50, 40, 25, "A lady dwarf who has beautiful flowers braided into her long beard. ");
            Monster d2 = new Dwarf("Cheery Digger", 70, 20, 50, 50, 20, 5, "He won't. stop. whistling. ");
            Monster d3 = new Dwarf("General Foreman", 55, 20, 150, 50, 25, 15, "A gruff old dwarf who is much stronger than his aged frame suggests. ");
            Monster d4 = new Dwarf("Tiny Miner", 65, 80, 50, 50, 40, 5, "Just a tiny lil fella with a big ol' pickaxe.  ");


            Monster e1 = new Elf("Woodsy Ranger", 50, 30, 80, 35, 15, 5, "This elf smells like patchouli . ");
            Monster e2 = new Elf("Sharp-Eyed Archer", 70, 70, 60, 60, 30, 10, "You barely see this elf, who was camping in the shadows, hoping to snipe you. ");
            Monster e3 = new Elf("Crafty Artificer", 55, 110, 75, 75, 40, 15, "An elf is tinkering with some magical contraption it has built to explore your ruins.");
            Monster e4 = new Elf("Wise Archmage", 65, 60, 165, 125, 60, 25, "Powerful spells swirl around this ancient elf, who radiates an incredible energy.");


         




            List<Monster> monsters = new()
            { h1, d1, e1,
            h2, h2, d2, d2, e2, e2,
            h3, h3, d3, d3, e3, e3,  
            h4, d4, e4 
            };

            Random rand = new Random();
            int index = rand.Next(monsters.Count);
            Monster monster = monsters[index];
            return monster;

        }//Monster life between 50 and 75, monster's block must be less than player hit chance. 
    } // IsFluffy = new Random().Next(100) <= 5; There is a 5% chance of the bunny being fluffy. 

}
