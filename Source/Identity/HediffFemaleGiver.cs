using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Identity
{
    class HediffFemaleGiver : HediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            Hediff existing = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff);
           //Hediff faker = pawn.health.hediffSet.GetFirstHediffOfDef(this.breastImplant);
            if (existing == null)
            {
                if (base.TryApply(pawn))
                {
                    // Apply new hediff
                   // base.SendLetter(pawn, cause);

                    // Overwrite its severity if it worked
                    existing = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff);
                    if (existing != null)
                    {
                        if (pawn.gender == Gender.Female)
                        {
                            existing.Severity = 0.5f;
                        }
                        else if (pawn.gender == Gender.Male)
                        {
                            existing.Severity = 0.02f;
                        }
                    }
                }
            }

        }
    }
}
