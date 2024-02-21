using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RimWorld;
using Verse;

namespace Identity
{
    public class ThoughtWorker_wrongGender : ThoughtWorker_Precept_HasProsthetic
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            int num = ThoughtWorker_wrongGender.FemPartsCount(p);
            if (num > 0)
            {
                return ThoughtState.ActiveAtStage(num - 1);
            }
            return false;
        }

        public static int FemPartsCount(Pawn p)
        {
            return p.health.hediffSet.CountFemaleParts();
        }

    }
}
