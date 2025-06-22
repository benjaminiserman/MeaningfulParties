using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(CompDevourer), nameof(CompDevourer.DigestJobFinished))]
    public class CompDevourer_DigestJobFinished
    {
        public static void Prefix(CompDevourer __instance, int ___ticksDigesting, int ___ticksToDigestFully)
        {
            if (___ticksDigesting >= ___ticksToDigestFully && __instance.DigestingPawn.IsColonist)
            {
                PartyCauseDefOf.DevourerDigest.Push(__instance.DigestingPawn);
            }
        }
    }
}