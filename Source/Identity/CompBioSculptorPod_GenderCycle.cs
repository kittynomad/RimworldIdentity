using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using UnityEngine;
using Verse;

namespace Identity
{
    public class CompBioSculpterPod_GenderCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            Messages.Message("BiosculpterPleasureCompletedMessage".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent, true);
            pawn.gender = pawn.gender == Gender.Male ? Gender.Female : Gender.Male;
            pawn.Drawer.renderer.graphics.ResolveAllGraphics();
        }
    }

    public class CompProperties_CompBioSculpterPod_GenderCycle : CompProperties_BiosculpterPod_BaseCycle
    {
        // Token: 0x06006BBE RID: 27582 RVA: 0x0024AF4B File Offset: 0x0024914B
        public CompProperties_CompBioSculpterPod_GenderCycle()
        {
            this.compClass = typeof(CompBioSculpterPod_GenderCycle);
        }
    }
}
