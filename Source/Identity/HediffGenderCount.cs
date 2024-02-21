using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RimWorld;
using Verse;

namespace Identity
{
	//depricated class. gives severity-based thoughts according to how many female parts a pawn has.
	public static class HediffSexCount
	{
		public static int CountFemaleParts(this HediffSet hs)
		{
			int num = 0;
			List<Hediff> hediffs = hs.hediffs;
			for (int i = 0; i < hediffs.Count; i++)
			{
				if (hediffs[i].def.HasModExtension<genderedStuff>())
				{
					if (hediffs[i].def.GetModExtension<genderedStuff>().isFeminine)
                    {
						num++;
                    }
				}
			}
			return num;
		}
	}
}
