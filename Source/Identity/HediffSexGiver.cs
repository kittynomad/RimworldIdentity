using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Identity
{
    class GenderHediffGiver : HediffGiver
    {
        public void decider(Pawn pawn, Hediff existing, Hediff other, Gender targetSex)
        {
            //small chance of opposite sex trait
            Random excp = new Random();
            int mayExcept = excp.Next(0, 100);
            if (mayExcept < 42)
            {

            }
            else if ((existing == null) && (other == null) && ((pawn.gender == targetSex) || (mayExcept >= 95)))
            {
                
                base.TryApply(pawn);
                
            }
            else if ((existing != null) && (existing.Severity < 0.5f))
            {
                existing.Severity = 0f;
            }
        }

        public void decider(Pawn pawn, Hediff existing, Hediff other, Gender targetGender, Hediff other2)
        {
            Random excp = new Random();
            int mayExcept = excp.Next(0, 100);
            if (mayExcept < 69)
            {

            }
            else if ((existing == null) && (other == null) && (other2 == null) && ((pawn.gender == targetGender) || (mayExcept >= 95)))
            {
                base.TryApply(pawn);

            }
            else if ((existing != null) && (existing.Severity < 0.5f))
            {
                existing.Severity = 0f;
            }
        }
    }
    class BroadShoulderGiver : GenderHediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            Hediff existing = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff);
            Hediff other = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.NarrowShoulders);
            this.decider(pawn, existing, other, Gender.Male);
            /*if ((existing == null) && (other == null))
            {
                if (base.TryApply(pawn))
                {
                    // Apply new hediff
                   // base.SendLetter(pawn, cause);

                    // Overwrite its severity if it worked
                    existing = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff);
                    if (existing != null)
                    {
                        if ((pawn.gender == Gender.Male))
                        {
                            existing.Severity = 0.5f;
                        }
                        else if (pawn.gender == Gender.Female)
                        {
                            existing.Severity = 0.02f;
                        }
                    }
                }
            }
            */

        }
    }

    class NarrowShoulderGiver : GenderHediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            Hediff existing = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff);
            Hediff other = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.BroadShoulders);
            this.decider(pawn, existing, other, Gender.Female);

        }
    }

    class BreastGiver : GenderHediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            Hediff existing = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff);
            Hediff other = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.NoBreasts);
            this.decider(pawn, existing, other, Gender.Female);

        }
    }

    class NoBreastGiver : GenderHediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            Hediff existing = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff);
            Hediff other = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.Breasts);
            this.decider(pawn, existing, other, Gender.Male);

        }
    }
}
