using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace Identity
{/*
    public class IdentitySettings : ModSettings
    {
        /// <summary>
        /// The three settings our mod has.
        /// </summary>
        public bool exampleBool;
        public float preTransTrait = 0.5f;
        public float postTransTrait = 0.2f;
        public List<Pawn> exampleListOfPawns = new List<Pawn>();

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref exampleBool, "exampleBool");
            Scribe_Values.Look(ref preTransTrait, "preTransTrait", 0.5f);
            Scribe_Values.Look(ref postTransTrait, "postTransTrait", 0.2f);
            Scribe_Collections.Look(ref exampleListOfPawns, "exampleListOfPawns", LookMode.Reference);
            base.ExposeData();
        }
    }

    public class ExampleMod : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        ExampleSettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public ExampleMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<ExampleSettings>();
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("exampleBoolExplanation", ref settings.exampleBool, "exampleBoolToolTip");
            listingStandard.Label("Trans trait possibility (pre-transition)");
            settings.preTransTrait = listingStandard.Slider(settings.preTransTrait, 0f, 10f);
            settings.postTransTrait = listingStandard.Slider(settings.postTransTrait, 0f, 10f);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
       /* public override string SettingsCategory()
        {
            return "MyExampleModName".Translate();
        } 
    }*/
} 
