using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace Identity
{
    public class ThoughtWorker_Precept_GenderConflict : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            TraitDef mascID = DefOfDysphoria.maleGender;
            TraitDef femID = DefOfDysphoria.femaleGender;
            if (p.story.traits.HasTrait(mascID))
            {
                return true;
            }
            if (p.story.traits.HasTrait(femID))
            {
                return true;
            }
            return false;
        }
    }
}
