using System.Collections.Generic;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(IncidentWorker), nameof(IncidentWorker.TryExecute))]
    public class IncidentWorker_TryExecute
    {
        private static HashSet<string> _incidents = new HashSet<string>
        {
            nameof(PartyCauseDefOf.AmbrosiaSprout),
            nameof(PartyCauseDefOf.PsychicSoothe),
            nameof(PartyCauseDefOf.ThrumboPasses),
            nameof(PartyCauseDefOf.GameEndedWanderersJoin),
            nameof(PartyCauseDefOf.Eclipse),
            nameof(PartyCauseDefOf.Aurora),
            nameof(PartyCauseDefOf.GiveQuest_EndGame_ShipEscape),

            nameof(PartyCauseDefOf.RaidEnemy),
            nameof(PartyCauseDefOf.Infestation),
            nameof(PartyCauseDefOf.ManhunterPack)
        };

        static void Postfix(IncidentWorker __instance, ref bool __result)
        {
            if (__result == false)
            {
                return;
            }

            if (_incidents.Contains(__instance.def.defName))
            {
                PartyCauseDef.Named(__instance.def.defName).Push();
            }
        }
    }
}