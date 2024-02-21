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
    class StatWorker_DysphoriaGood : ThoughtWorker
	{
		public static ThoughtState CurrentThoughtState(Pawn p)
		{
			float dysTotal = StatWorker_Dysphoria.dysphoriaTotal(p);

			if (dysTotal <= 0f)
			{
				return ThoughtState.Inactive;
			}
			if (dysTotal < 10f)
			{
				return ThoughtState.ActiveAtStage(0);
			}
			if (dysTotal < 25f)
			{
				return ThoughtState.ActiveAtStage(1);
			}
			if (dysTotal < 40f)
			{
				return ThoughtState.ActiveAtStage(2);
			}
			return ThoughtState.ActiveAtStage(3);
		}

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (ThoughtUtility.ThoughtNullified(p, this.def))
			{
				return ThoughtState.Inactive;
			}
			return StatWorker_DysphoriaGood.CurrentThoughtState(p);
		}
		
		// this instance of dysphoriaTotal is not used (check the version in StatWorker_Dysphoria)
		/*public static float dysphoriaTotal(Pawn p)
		{
			StatDef fem = DefOfDysphoria.FemStat;
			StatDef masc = DefOfDysphoria.MascStat;
			StatDef dys = DefOfDysphoria.dysphoriaStat;
			StatDef dysm = DefOfDysphoria.dysMultiplier;
			TraitDef mascID = DefOfDysphoria.maleGender;
			TraitDef femID = DefOfDysphoria.femaleGender;
			float femBase = p.GetStatValue(fem);
			float mascBase = p.GetStatValue(masc);
			float dysBase = p.GetStatValue(dys);
			float dysmBase = p.GetStatValue(dysm);
			if (p.gender == Gender.Male)
            {
				mascBase += 30;
            }
			if (p.gender == Gender.Female)
			{
				femBase += 30;
			}
			if (p.story.traits.HasTrait(mascID))
            {
				float femFinal = (femBase * -1f);
				float mascFinal = (mascBase * 1f);
				//Log.Message(p + "MAN!!!!!");
				//Log.Message("" + (femFinal + mascFinal));
				return (femFinal + mascFinal + dysBase) * dysmBase;
				
            }
			if (p.story.traits.HasTrait(femID))
			{
				float femFinal = (femBase * 1f);
				float mascFinal = (mascBase * -1f);
				return (femFinal + mascFinal + dysBase) * dysmBase;

			}
			return 0f;
		}
		*/
	}
}

