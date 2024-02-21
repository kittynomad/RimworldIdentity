using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace Identity
{
	public class MentalState_FlarenBreak : MentalState
	{
		// Token: 0x0600324D RID: 12877 RVA: 0x00002662 File Offset: 0x00000862
		public override bool ForceHostileTo(Thing t)
		{
			return true;
		}

		// Token: 0x0600324E RID: 12878 RVA: 0x00002662 File Offset: 0x00000862
		public override bool ForceHostileTo(Faction f)
		{
			return true;
		}

		// Token: 0x0600324F RID: 12879 RVA: 0x0000249D File Offset: 0x0000069D
		public override RandomSocialMode SocialModeMax()
		{
			return RandomSocialMode.Off;
		}
	}
	public class JobGiver_FlarenBreak : ThinkNode_JobGiver
	{
		protected override Job TryGiveJob(Pawn pawn)
		{
			if (Rand.Value < 0.5f)
			{
				Job job = JobMaker.MakeJob(JobDefOf.Wait_Combat);
				job.expiryInterval = 90;
				job.canUseRangedWeapon = false;
				return job;
			}
			if (pawn.TryGetAttackVerb(null, false, false) == null)
			{
				return null;
			}
			Pawn pawn2 = this.FindPawnTarget(pawn);
			if (pawn2 != null)
			{
				Job job2 = JobMaker.MakeJob(JobDefOf.AttackMelee, pawn2);
				job2.maxNumMeleeAttacks = 1;
				job2.expiryInterval = Rand.Range(420, 900);
				job2.canBashDoors = true;
				return job2;
			}
			return null;
		}

		// Token: 0x0600400F RID: 16399 RVA: 0x001702B8 File Offset: 0x0016E4B8
		private Pawn FindPawnTarget(Pawn pawn)
		{
			return (Pawn)AttackTargetFinder.BestAttackTarget(pawn, TargetScanFlags.NeedReachable, delegate (Thing x)
			{
				Pawn pawn2;
				StatDef flaren = DefOfDysphoria.FlarenStat;
				return (pawn2 = (x as Pawn)) != null && pawn2.Spawned && !pawn2.Downed && !pawn2.IsInvisible() && (pawn2.GetStatValue(flaren) > 1);
			}, 0f, this.maxAttackDistance, default(IntVec3), float.MaxValue, true, true, false);
		}

		// Token: 0x06004010 RID: 16400 RVA: 0x0017030C File Offset: 0x0016E50C
		public override ThinkNode DeepCopy(bool resolve = true)
		{
			JobGiver_FlarenBreak jobGiver_FlarenBreak = (JobGiver_FlarenBreak)base.DeepCopy(resolve);
			jobGiver_FlarenBreak.maxAttackDistance = this.maxAttackDistance;
			return jobGiver_FlarenBreak;
		}

		// Token: 0x04002538 RID: 9528
		private const float WaitChance = 0.5f;

		// Token: 0x04002539 RID: 9529
		private const int WaitTicks = 90;

		// Token: 0x0400253A RID: 9530
		private const int MinMeleeChaseTicks = 420;

		// Token: 0x0400253B RID: 9531
		private const int MaxMeleeChaseTicks = 900;

		// Token: 0x0400253C RID: 9532
		private float maxAttackDistance = 40f;
	}
}


