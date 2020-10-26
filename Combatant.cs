﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    class Combatant
    {
        public enum characters
        {
            CrissWithAGun,
            TheRatMaster,
            DrMilk,
            RatWizard,
            RatGamer
        };

        public Image pic;
        public Label lbl;
        public string Name;
        public int[] health;
        public Card[] hand;
        public characters character;






        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public class Preset
        {

            public const int HUMANHEIGHT = 500;
            public string name;
            public string source;
            public string backgroundSource;
            public int health;
            public int height;
            public Card[] deck;
            public bool playable;
            public bool fightable;
            public characters character;

            Preset[] presets = new Preset[]
       {
            new Preset
            {
                character = characters.DrMilk,
                name = "Dr. Milk",
                source = "DrMilk.png",
                health = 50,
                height = HUMANHEIGHT-1,
                playable = true,
                fightable = false,
            },
            new Preset
            {
                character = characters.TheRatMaster,
                name = "The Rat Master",
                source = "standard.png",
                health = 55,
                height = HUMANHEIGHT,
                playable = false,
                fightable = false,
            },
            new Preset
            {
                character = characters.CrissWithAGun,
                name = "Criss With a Gun",
                source = "crisswithagun.png",
                health = 1000,
                height = HUMANHEIGHT,
                playable = false,
                fightable = false,
            },
            new Preset
            {
                character = characters.RatWizard,
                name = "Rat Wizard",
                source = "rat_wiz.png",
                health = 40,
                height = 250,
                playable = false,
                fightable = false,
            },
            new Preset
            {
                character = characters.RatGamer,
                name = "Rat Gamer",
                source = "Rat_Gamer.png",
                backgroundSource = "Library.jpg",
                health = 35,
                height = 300,
                playable = false,
                fightable = true,
            }
       };
        }

        Combatant player = new Combatant();
        Combatant enemy = new Combatant();

       
    }
}