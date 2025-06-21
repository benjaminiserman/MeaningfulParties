using HarmonyLib;
using MeaningfulParties.PartyCauses;
using Verse;

namespace MeaningfulParties.Patches
{
    public class Hediff_Pregnant_NotifyPlayerOfTrimesterPassing
    {
        [HarmonyPatch(typeof(Hediff_Pregnant), "NotifyPlayerOfTrimesterPassing")]
        public static void Postfix(Hediff_Pregnant __instance)
        {
            PartyCauseDefOf.BabyShower.Push(__instance.pawn);
        }
    }
}