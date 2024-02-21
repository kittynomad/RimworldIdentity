using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace Identity
{
    public class ThoughtWorker_Precept_IsTrans_Social : ThoughtWorker_Precept_Social
    {
        protected override ThoughtState ShouldHaveThought(Pawn p, Pawn otherPawn)
        {
            TraitDef mascID = DefOfDysphoria.maleGender;
            TraitDef femID = DefOfDysphoria.femaleGender;
            if (otherPawn.story.traits.HasTrait(mascID))
            {
                return true;
            }
            if (otherPawn.story.traits.HasTrait(femID))
            {
                return true;
            }
            return false;
        }
    }
}
