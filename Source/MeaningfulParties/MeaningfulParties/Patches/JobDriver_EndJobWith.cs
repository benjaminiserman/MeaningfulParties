using System.Collections.Generic;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;
using Verse.AI;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(JobDriver), nameof(JobDriver.EndJobWith))]
    public class JobDriver_EndJobWith
    {
        private static HashSet<string> _jobs = new HashSet<string>
        {
            nameof(PartyCauseDefOf.AbsorbXenogerm),
            nameof(PartyCauseDefOf.ActivateMonolith),
            nameof(PartyCauseDefOf.BuildCubeStructure),
            nameof(PartyCauseDefOf.CreateXenogerm),
            nameof(PartyCauseDefOf.NociosphereDepart),
            nameof(PartyCauseDefOf.Nuzzle),
            nameof(PartyCauseDefOf.Play_Hoopstone),
            nameof(PartyCauseDefOf.Play_Horseshoes),
            nameof(PartyCauseDefOf.Play_GameOfUr),
            nameof(PartyCauseDefOf.Play_Chess),
            nameof(PartyCauseDefOf.Play_Billiards),
            nameof(PartyCauseDefOf.Play_MusicalInstrument),
            nameof(PartyCauseDefOf.Play_Poker),
            nameof(PartyCauseDefOf.WatchTelevision),
            nameof(PartyCauseDefOf.UseTelescope),
            nameof(PartyCauseDefOf.ReleaseAnimalToWild),
            nameof(PartyCauseDefOf.ActivateArchonexusCore),
            nameof(PartyCauseDefOf.SlaveEmancipation),
            nameof(PartyCauseDefOf.ReleasePrisoner),
            nameof(PartyCauseDefOf.Lessontaking),
            nameof(PartyCauseDefOf.Resurrect)
        };

        private static object[] GetArgsForJob(string jobDefName, JobDriver jobDriver)
        {
            var args = new object[] { jobDriver.pawn, jobDriver.job.targetA };

            return args;
        }

        public static void Prefix(JobDriver __instance, JobCondition condition)
        {
            if (__instance.job == null || __instance.pawn.CurJob != __instance.job)
            {
                return;
            }

            if (condition != JobCondition.Succeeded)
            {
                return;
            }

            var defName = __instance.job?.def?.defName;
            if (defName == null || !_jobs.Contains(defName))
            {
                return;
            }

            var args = GetArgsForJob(defName, __instance);
            PartyCauseDef.Named(defName).Push(targets: args);
        }
    }
}