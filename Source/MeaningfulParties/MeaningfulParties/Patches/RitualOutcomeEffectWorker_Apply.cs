using System.Collections.Generic;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(RitualOutcomeEffectWorker), nameof(RitualOutcomeEffectWorker.Apply))]
    public class RitualOutcomeEffectWorker_Apply
    {
        private static HashSet<string> _rituals = new HashSet<string>
        {
            nameof(PartyCauseDefOf.AnimaTreeLinking),
            nameof(PartyCauseDefOf.Bestowing),
            nameof(PartyCauseDefOf.BlindingCeremony),
            nameof(PartyCauseDefOf.ScarificationCeremony),
            nameof(PartyCauseDefOf.TreeConnection),
            nameof(PartyCauseDefOf.Conversion),
            nameof(PartyCauseDefOf.GladiatorDuel),
            nameof(PartyCauseDefOf.Execution),
            nameof(PartyCauseDefOf.SacrificePrisoner),
            nameof(PartyCauseDefOf.RoleChange),
            nameof(PartyCauseDefOf.Trial),
            nameof(PartyCauseDefOf.ThroneSpeech),
            nameof(PartyCauseDefOf.LeaderSpeech)
        };

        private static object[] GetArgsForRitual(string ritualDefName, LordJob_Ritual jobRitual)
        {
            switch (ritualDefName)
            {
                case "AnimaTreeLinking":
                    return new object[] { jobRitual.assignments.FirstAssignedPawn("organizer") };
                case "Bestowing":
                    return new object[] { jobRitual.assignments.FirstAssignedPawn("linker") };
                case "BlindingCeremony":
                case "ScarificationCeremony":
                    return new object[] { jobRitual.assignments.FirstAssignedPawn("target") };
                case "TreeConnection":
                    return new object[] { jobRitual.assignments.FirstAssignedPawn("connector") };
                case "Conversion":
                    return new object[]
                    {
                        jobRitual.assignments.FirstAssignedPawn("moralist"),
                        jobRitual.assignments.FirstAssignedPawn("convertee")
                    };
                case "GladiatorDuel":
                    return new object[]
                    {
                        jobRitual.assignments.FirstAssignedPawn("duelist1"),
                        jobRitual.assignments.FirstAssignedPawn("duelist2")
                    };
                case "Execution":
                    return new object[]
                    {
                        jobRitual.assignments.FirstAssignedPawn("executioner"),
                        jobRitual.assignments.FirstAssignedPawn("prisoner")
                    };
                case "SacrificePrisoner":
                    return new object[]
                    {
                        jobRitual.assignments.FirstAssignedPawn("moralist"),
                        jobRitual.assignments.FirstAssignedPawn("prisoner")
                    };
                case "RoleChange":
                    return new object[] { jobRitual.assignments.FirstAssignedPawn("role_changer") };
                case "Trial":
                    return new object[] { jobRitual.assignments.FirstAssignedPawn("convict") };
                case "ThroneSpeech":
                case "LeaderSpeech":
                    return new object[] { jobRitual.assignments.FirstAssignedPawn("speaker") };
            }

            return new object[2];
        }

        public static void Postfix(LordJob_Ritual jobRitual)
        {
            var ritualDefName = jobRitual.Ritual.behavior.def.defName;
            if (_rituals.Contains(ritualDefName))
            {
                var args = GetArgsForRitual(ritualDefName, jobRitual);
                PartyCauseDef.Named(ritualDefName).Push(args);
            }
        }
    }
}