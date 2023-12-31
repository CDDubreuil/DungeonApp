﻿namespace DungeonLibrary
{
    public abstract class Character
        //Abstract denotes the beginning of an inheritance chain.
        //This is an incomplete implementation and must be inherited. You cannot
        //create/instantiate an abstract object.
    {
        private string _name;
        private int _hitChance;
        private int _maxLife;
        private int _life;
        private int _block;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            //Life cannot be more than MaxLife (think healing). If it is, just set it to the value of MaxLife.
            set { _life = value <= MaxLife ? value : MaxLife; } //always reference other properties, not fields, in case there are business rules in place.
        }

        public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;//Life depends on MaxLife, so set MaxLife FIRST. 
            //if we happen to assign Life first, it will default to 0, because it can't be more than MaxLife (0).
            Life = life;
        }//end fully qualified constructor.
      
     

        //In combat, the attacker's HitChance minus the defender's Block will determine whether the attack hits.        
        public virtual int CalcBlock() { return Block; }
        public virtual int CalcHitChance() { return HitChance; }
        //If an attacker lands a hit, we will call the attacker's CalcDamage() to determine how much damage to do.
        //Virtual makes it possible but not required to override

        //an abstract method is an incomplete implementation. This method must be 
        //overridden in a child class for the implementation to be complete.
        //abstract methods can only exist in abstract classes. 
        public abstract int CalcDamage();
        //virtual : possible to override, but not required.
        //abstract : required to be overridden.

        public override string ToString()
        {
            //return base.ToString(); -> DungeonLibrary.Character
            return $"---- {Name} ----\n" +
                   $"Life: {Life} / {MaxLife}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}%\n";
        }
    }
}