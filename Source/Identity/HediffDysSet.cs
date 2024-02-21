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
    class HediffDysSet
    {
		public float DysTotal
		{
			get
			{
				if (this.cachedDys < 0f)
				{
					this.cachedDys = this.CalculateDys();
				}
				return this.cachedDys;
			}
		}
			private float CalculateDys()
		{
			if (!this.pawn.RaceProps.IsFlesh || this.pawn.Dead)
			{
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < this.hediffs.Count; i++)
			{
				//num += this.hediffs[i].PainOffset;
				num += 1;
			}
			for (int j = 0; j < this.hediffs.Count; j++)
			{
				//num *= this.hediffs[j].PainFactor;
			}
			return Mathf.Clamp(num, 0f, 1f);
		}
		public Pawn pawn;
		public List<Hediff> hediffs = new List<Hediff>();
		private float cachedDys = -1f;
		private bool? cachedHasHead;
		private Stack<BodyPartRecord> coveragePartsStack = new Stack<BodyPartRecord>();
		private HashSet<BodyPartRecord> coverageRejectedPartsSet = new HashSet<BodyPartRecord>();
		private Queue<BodyPartRecord> missingPartsCommonAncestorsQueue = new Queue<BodyPartRecord>();
	}
	
}
