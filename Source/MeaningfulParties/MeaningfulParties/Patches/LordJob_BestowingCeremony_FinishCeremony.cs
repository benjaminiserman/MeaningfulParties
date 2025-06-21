using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(LordJob_BestowingCeremony), nameof(LordJob_BestowingCeremony.FinishCeremony))]
    public class LordJob_BestowingCeremony_FinishCeremony
    {
        static void Postfix(Pawn pawn)
        {
            PartyCauseDefOf.BestowingCeremony.Push(pawn);
        }
    }
}