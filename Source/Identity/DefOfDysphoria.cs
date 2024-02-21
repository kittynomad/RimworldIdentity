using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Identity
{
    [DefOf]
    public static class DefOfDysphoria
    {
        public static StatDef FemStat;
        public static StatDef MascStat;
        public static StatDef FlarenStat;
        public static StatDef dysphoriaStat;
        public static StatDef dysMultiplier;
        public static TraitDef maleGender;
        public static TraitDef femaleGender;
        public static TraitDef androgyneGender;
        public static TraitDef noGenderPref;
        public static TraitDef monster;
        public static HediffDef NarrowShoulders;
        public static HediffDef BroadShoulders;
        public static HediffDef NoBreasts;
        public static HediffDef Breasts;
        public static HediffDef breastImplant;

        public static GeneDef Flaren_Mindset;
        public static HediffDef FlarenRage;
        public static MentalBreakDef FlarenBreak;

        static DefOfDysphoria()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(DefOfDysphoria));
        }

    }
}
