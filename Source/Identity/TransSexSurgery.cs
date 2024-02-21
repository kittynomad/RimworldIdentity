using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Identity
{
    public class TransSexSurgery : Recipe_InstallArtificialBodyPart
    {
        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients,
            Bill bill)
        {
            if (billDoer == null)
            {
                return;
            }

            if (!CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
            {
                TaleRecorder.RecordTale(TaleDefOf.DidSurgery, billDoer, pawn);
                pawn.gender = pawn.gender == Gender.Male ? Gender.Female : Gender.Male;
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
}
