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
    class StatWorker_Dysphoria : ThoughtWorker
	{
		public static ThoughtState CurrentThoughtState(Pawn p)
		{
			float dysTotal = StatWorker_Dysphoria.dysphoriaTotal(p);

			if (dysTotal >= 0f)
			{
				return ThoughtState.Inactive;
			}
			if (dysTotal > -10f)
			{
				return ThoughtState.ActiveAtStage(0);
			}
			if (dysTotal > -25f)
			{
				return ThoughtState.ActiveAtStage(1);
			}
			if (dysTotal > -40f)
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
			return StatWorker_Dysphoria.CurrentThoughtState(p);
		}
		
		public static float dysphoriaTotal(Pawn p)
		{
			StatDef fem = DefOfDysphoria.FemStat;
			StatDef masc = DefOfDysphoria.MascStat;
			StatDef flaren = DefOfDysphoria.FlarenStat;
			StatDef dys = DefOfDysphoria.dysphoriaStat;
			StatDef dysm = DefOfDysphoria.dysMultiplier;
			TraitDef mascID = DefOfDysphoria.maleGender;
			TraitDef femID = DefOfDysphoria.femaleGender;
			TraitDef androID = DefOfDysphoria.androgyneGender;
			TraitDef monster = DefOfDysphoria.monster;
			GeneDef flarenMindset = DefOfDysphoria.Flaren_Mindset;
			float femBase = p.GetStatValue(fem);
			float mascBase = p.GetStatValue(masc);
			float dysBase = p.GetStatValue(dys);
			float dysmBase = p.GetStatValue(dysm);
			float flBase = p.GetStatValue(flaren);

			if(p.genes.HasGene(flarenMindset))
            {
				flBase = 0;
            }
			if (p.gender == Gender.Male)
            {
				mascBase += 30;
            }
			if (p.gender == Gender.Female)
			{
				femBase += 30;
			}
			if (p.story.traits.HasTrait(monster))
            {
				flBase = -flBase;
            }
			if (p.story.traits.HasTrait(mascID))
            {
				//float femFinal = (femBase * -1f);
				//float mascFinal = (mascBase * 1f);
				//Log.Message(p + "MAN!!!!!");
				//Log.Message("" + (femFinal + mascFinal));
				return (-femBase + mascBase + dysBase - flBase) * dysmBase;
				
            }
			if (p.story.traits.HasTrait(femID))
			{
				//float femFinal = (femBase * 1f);
				//float mascFinal = (mascBase * -1f);
				return (femBase - mascBase + dysBase - flBase) * dysmBase;

			}
			if (p.story.traits.HasTrait(androID))
			{
				float statDif = Math.Abs(femBase - mascBase);
				
				return (-statDif + dysBase + 20f - flBase) * dysmBase;

			}
			return (dysBase - flBase) * dysmBase;
		}
	}
}

