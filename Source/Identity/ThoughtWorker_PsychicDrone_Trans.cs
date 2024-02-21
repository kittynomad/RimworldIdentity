/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;
using System.Reflection;
using System.Reflection.Emit;

namespace Identity
{
	//[HarmonyPatch(typeof(ThoughtWorker_PsychicDrone))]
	//[HarmonyPatch(nameof(ThoughtWorker_PsychicDrone_CurrentStateInternal))]
	[HarmonyPatch]
	static class ThoughtWorker_PsychicDrone_CurrentStateInternal
	{
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
		{
			//IL_0016
			var code = new List<CodeInstruction>(instructions);

			int insertionIndex = 17;
			/*for (int i = 0; i < code.Count - 1; i++) // -1 since we will be checking i + 1
			{
				if (code[i].opcode == OpCodes.Ldfld && (Map)code[i].operand == gameConditionManager && code[i + 1].opcode == OpCodes.Ret)
				{
					insertionIndex = i;
					break;
				}
			}

			
			for (int i = 0; i < code.Count; i++)
			{
				if (i == insertionIndex)
				{
					yield return new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(pater), nameof(pater.getGender))); // your instruction here
				}


				else
				{
					yield return code[i];
				}
					
			}

			
		}
	}
}
*/