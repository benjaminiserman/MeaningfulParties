using System.Collections.Generic;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(Pawn_HealthTracker), nameof(Pawn_HealthTracker.RemoveHediff))]
    public class Pawn_HealthTracker_RemoveHediff
    {
        private static HashSet<string> _hediffs = new HashSet<string>
        {
            nameof(PartyCauseDefOf.Plague),
            nameof(PartyCauseDefOf.GutWorms),
            nameof(PartyCauseDefOf.WoundInfection),
            nameof(PartyCauseDefOf.Flu),
            nameof(PartyCauseDefOf.Malaria),
            nameof(PartyCauseDefOf.SleepingSickness),
            nameof(PartyCauseDefOf.Blindness),
            nameof(PartyCauseDefOf.Dementia),
            nameof(PartyCauseDefOf.Alzheimers),
            nameof(PartyCauseDefOf.HeartArteryBlockage),
            nameof(PartyCauseDefOf.AlcoholAddiction),
            nameof(PartyCauseDefOf.GoJuiceAddiction),
            nameof(PartyCauseDefOf.PsychiteAddiction),
            nameof(PartyCauseDefOf.SmokeleafAddiction),
            nameof(PartyCauseDefOf.WakeUpAddiction),
        };

        public static void Postfix(Hediff hediff)
        {
            if (_hediffs.Contains(hediff.def.defName) && hediff.pawn.IsColonist)
            {
                PartyCauseDef.Named(hediff.def.defName).Push(hediff.pawn);
            }
        }
    }
}