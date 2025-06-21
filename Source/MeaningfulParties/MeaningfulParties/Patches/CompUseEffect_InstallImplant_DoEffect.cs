using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(CompUseEffect_InstallImplant), nameof(CompUseEffect_InstallImplant.DoEffect))]
    public class CompUseEffect_InstallImplant_DoEffect
    {
        public static void Postfix(CompUseEffect_InstallImplant __instance, Pawn user)
        {
            PartyCauseDefOf.Implant.Push(user, __instance.parent);
        }
    }
}