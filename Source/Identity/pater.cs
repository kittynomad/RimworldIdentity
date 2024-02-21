using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Identity
{
   public class pater
    {
        public static Gender getGender(Pawn p)
        {
			if (p.story.traits.HasTrait(DefOfDysphoria.maleGender))
			{
				return Gender.Male;
			}
			else if (p.story.traits.HasTrait(Identity.DefOfDysphoria.femaleGender))
			{
				return Gender.Female;
			}
			else
            {
				return p.gender;
            }
		}
    }
}
