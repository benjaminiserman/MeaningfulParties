using System.Collections.Generic;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(GameCondition), nameof(GameCondition.End))]
    public class GameCondition_End
    {
        private static HashSet<string> _gameConditions = new HashSet<string>
        {
            nameof(PartyCauseDefOf.PsychicDrone),
            nameof(PartyCauseDefOf.ToxicFallout),
            nameof(PartyCauseDefOf.VolcanicWinter),
            nameof(PartyCauseDefOf.HeatWave),
            nameof(PartyCauseDefOf.ColdSnap),
            nameof(PartyCauseDefOf.DeathPall),
            nameof(PartyCauseDefOf.GrayPall),
            nameof(PartyCauseDefOf.UnnaturalDarkness),
            nameof(PartyCauseDefOf.NoxiousHaze),
        };

        public static void Postfix(GameCondition __instance)
        {
            if (_gameConditions.Contains(__instance.def.defName))
            {
                PartyCauseDef.Named(__instance.def.defName).Push();
            }
        }
    }
}