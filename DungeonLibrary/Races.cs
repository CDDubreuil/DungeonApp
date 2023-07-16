using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

namespace DungeonApp.DungeonLibrary
{
    public enum Race
    {
        None,
        Unicorn,
        Skeleton,
        Necromancer,
        Dragon,
        Vampire,
        Werewolf
        //Dragon-Upon hit, deals massive damage, BUT has a much lower chance to hit due to size. 
        //Skeleton-Lower chance to take damage
        //Vampire- Day and Night De/Buffs
        //Necromancer-Summon last killed enemy 
        //Unicorn-Laser Cannon Death Sentence=instakill
        //Werewolf-Charm enemies into not attacking
    }
    }




