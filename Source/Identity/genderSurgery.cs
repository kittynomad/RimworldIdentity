using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
//using Identity;

namespace Identity
{
    public class genderSurgery : Recipe_InstallArtificialBodyPart
    {
        public void swapGenderHediff(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients,
            Bill bill, Hediff addHed, Hediff removeHed)
        {
            if (billDoer == null)
            {
                return;
            }

            if (!CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
            {
                TaleRecorder.RecordTale(TaleDefOf.DidSurgery, billDoer, pawn);
                pawn.health.AddHediff(addHed, part);

                if (!pawn.Dead)
                {
                    if (removeHed != null)
                    {
                        pawn.health.hediffSet.hediffs.Remove(removeHed);
                    }
                }
                pawn.Drawer.renderer.graphics.ResolveAllGraphics();
              /*  Messages.Message(
                    string.Format("PS_Messages_SurgeryResult_Success".Translate(), billDoer.LabelShort,
                        pawn.LabelShort, "PS_Messages_Surgery_SexChange".Translate()), new LookTargets(pawn),
                    MessageTypeDefOf.TaskCompletion);*/
            }
            else
            {
               /* Messages.Message(
                    string.Format("PS_Messages_SurgeryResult_Botched".Translate(), billDoer.LabelShort,
                        pawn.LabelShort, "PS_Messages_Surgery_SexChange".Translate()), new LookTargets(pawn),
                    MessageTypeDefOf.NegativeHealthEvent); */
            }
        }
    }

    public class ShoulderBroadenSurgery : genderSurgery
    {
        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients,
            Bill bill)
        {
            Hediff hediff = HediffMaker.MakeHediff(DefOfDysphoria.BroadShoulders, pawn);
            Hediff hediff2 = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.NarrowShoulders);
            this.swapGenderHediff(pawn, part, billDoer, ingredients,
            bill, hediff, hediff2 );
        }
    }

    public class ShoulderReduceSurgery : genderSurgery
    {
        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients,
            Bill bill)
        {
            Hediff hediff = HediffMaker.MakeHediff(DefOfDysphoria.NarrowShoulders, pawn);
            Hediff hediff2 = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.BroadShoulders);
            this.swapGenderHediff(pawn, part, billDoer, ingredients,
            bill, hediff, hediff2);
        }
    }

    public class BreastAugSurgery : genderSurgery
    {
        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients,
            Bill bill)
        {
            Hediff hediff = HediffMaker.MakeHediff(DefOfDysphoria.breastImplant, pawn);
            Hediff hediff2 = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.NoBreasts);
            this.swapGenderHediff(pawn, part, billDoer, ingredients,
            bill, hediff, hediff2);
        }
    }

    public class TopSurgery : genderSurgery
    {
        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients,
            Bill bill)
        {
            Hediff hediff = HediffMaker.MakeHediff(DefOfDysphoria.NoBreasts, pawn);
            Hediff hediff2 = pawn.health.hediffSet.GetFirstHediffOfDef(DefOfDysphoria.Breasts);
            this.swapGenderHediff(pawn, part, billDoer, ingredients,
            bill, hediff, hediff2);
        }
    }
}
