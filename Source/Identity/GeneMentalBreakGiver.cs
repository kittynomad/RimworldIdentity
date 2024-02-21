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
	public class Hediff_FlarenRage : HediffWithComps
	{
		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06001639 RID: 5689 RVA: 0x0008333A File Offset: 0x0008153A
		/*public override string LabelBase
		{
			get
			{
				return "ChemicalDependency".Translate(this.chemical.Named("CHEMICAL"));
			}
		}*/
		public override bool ShouldRemove
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x0600163B RID: 5691 RVA: 0x0008335B File Offset: 0x0008155B
		public override bool Visible
		{
			get
			{
				return (this.LinkedGene == null || this.LinkedGene.Active) && base.Visible;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x0600163C RID: 5692 RVA: 0x0008337A File Offset: 0x0008157A
		/*public bool ShouldSatify
		{
			get
			{
				return this.Severity >= this.def.stages[1].minSeverity - 0.1f;
			}
		}*/

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x0600163D RID: 5693 RVA: 0x000833A4 File Offset: 0x000815A4
		public Gene_Flaren_Mindset LinkedGene
		{
			get
			{
				if (this.cachedDependencyGene == null && this.pawn.genes != null)
				{
					List<Gene> genesListForReading = this.pawn.genes.GenesListForReading;
					for (int i = 0; i < genesListForReading.Count; i++)
					{
						Gene_Flaren_Mindset gene_Flaren_Mindset;
						if ((gene_Flaren_Mindset = (genesListForReading[i] as Gene_Flaren_Mindset)) != null)
						{
							this.cachedDependencyGene = gene_Flaren_Mindset;
							break;
						}
					}
				}
				return this.cachedDependencyGene;
			}
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x00083548 File Offset: 0x00081748
		/*public override bool TryMergeWith(Hediff other)
		{
			Hediff_ChemicalDependency hediff_ChemicalDependency;
			return (hediff_ChemicalDependency = (other as Hediff_ChemicalDependency)) != null && hediff_ChemicalDependency.chemical == this.chemical && base.TryMergeWith(other);
		}*/

		// Token: 0x06001640 RID: 5696 RVA: 0x00083578 File Offset: 0x00081778
		/*public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Defs.Look<ChemicalDef>(ref this.chemical, "chemical");
		}*/

		// Token: 0x04001188 RID: 4488

		// Token: 0x04001189 RID: 4489
		[Unsaved(false)]
		private Gene_Flaren_Mindset cachedDependencyGene;
	}
	public class Gene_Flaren_Mindset : Gene
	{
		public Hediff_FlarenRage LinkedHediff
		{
			get
			{
				List<Hediff> hediffs = this.pawn.health.hediffSet.hediffs;
				for (int i = 0; i < hediffs.Count; i++)
				{
					Hediff_FlarenRage hediff_FlarenRage;
					if ((hediff_FlarenRage = (hediffs[i] as Hediff_FlarenRage)) != null)
					{
						return hediff_FlarenRage;
					}
				}
				return null;
			}
		}
		public override void PostAdd()
		{
			/*if (!ModLister.CheckBiotech("Chemical dependency"))
			{
				return;
			}*/
			base.PostAdd();
			//Hediff_FlarenRage hediff_FlarenRage = (Hediff_FlarenRage)HediffMaker.MakeHediff(DefOfDysphoria.FlarenRage, this.pawn);
			//this.pawn.health.AddHediff(hediff_FlarenRage);
			HediffGiverUtility.TryApply(this.pawn, DefOfDysphoria.FlarenRage, null);
		}
		public override void PostRemove()
		{
			Hediff_FlarenRage linkedHediff = this.LinkedHediff;
			if (linkedHediff != null)
			{
				this.pawn.health.RemoveHediff(linkedHediff);
			}
			base.PostRemove();
		}

	}
}

