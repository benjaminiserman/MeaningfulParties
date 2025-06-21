using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(CompTargetEffect_Resurrect), nameof(CompTargetEffect_Resurrect.DoEffectOn))]
    public class CompTargetEffect_Resurrect_DoEffectOn
    {
        public static void Postfix(Thing target)
        {
            if (target is Corpse corpse)
            {
                PartyCauseDefOf.Resurrection.Push(corpse.InnerPawn);
            }
        }
    }
}