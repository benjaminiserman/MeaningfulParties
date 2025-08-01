using System.Linq;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(GatheringWorker), "SendLetter")]
    public class GatheringWorker_SendLetter
    {
        private static string[] replaceableDefs =
        {
            "Party", "VSIE_OutdoorParty", "VSIE_BingeParty"
        };

        static bool Prefix(GatheringWorker __instance, IntVec3 spot, Pawn organizer)
        {
            if (!replaceableDefs.Contains(__instance.def.defName))
            {
                return true;
            }

            var partyCauseTracker = Find.World.GetComponent<PartyCauseTracker>();
            var partyCause = partyCauseTracker.PullPartyCause();

            Find.LetterStack.ReceiveLetter(
                (TaggedString)__instance.def.letterTitle,
                __instance.def.letterText.Formatted(organizer.Named("ORGANIZER"),
                    partyCause.Def.letterText.Formatted(
                        partyCause.Target.Named("TARGET"),
                        partyCause.Target2.Named("TARGET2")
                    ).Named("CELEBRATION")
                ),
                LetterDefOf.PositiveEvent,
                new TargetInfo(spot, organizer.Map)
            );

            return false;
        }
    }
}