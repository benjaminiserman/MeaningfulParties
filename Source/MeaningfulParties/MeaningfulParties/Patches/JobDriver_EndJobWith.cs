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
            nameof(PartyCauseDefOf.InstallImplant),
            nameof(PartyCauseDefOf.AbsorbXenogerm),
            nameof(PartyCauseDefOf.ActivateMonolith),
            nameof(PartyCauseDefOf.BuildCubeStructure),
            nameof(PartyCauseDefOf.CreateXenogerm),
            nameof(PartyCauseDefOf.DevourerDigest),
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
            nameof(PartyCauseDefOf.EmancipateSlave),
            nameof(PartyCauseDefOf.ReleasePrisoner),
            nameof(PartyCauseDefOf.Lessontaking)
        };

        private static object[] GetArgsForJob(string jobDefName, JobDriver jobDriver)
        {
            var args = new object[] { jobDriver.pawn, jobDriver.job.targetA };

            switch (jobDefName)
            {
                case nameof(JobDefOf.InstallImplant):
                {
                    args[0] = jobDriver.job.targetA;
                    args[1] = jobDriver.job.targetB;
                    break;
                }
                case nameof(JobDefOf.DevourerDigest):
                {
                    args[0] = ((JobDriver_DevourerDigest)jobDriver).pawn.GetComp<CompDevourer>().DigestingPawn;
                    break;
                }
            }

            return args;
        }

        public static void Postfix(JobDriver __instance, JobCondition condition)
        {
            if (condition != JobCondition.Succeeded)
            {
                return;
            }

            var defName = __instance.job.def.defName;
            if (!_jobs.Contains(defName))
            {
                return;
            }

            if (__instance is JobDriver_DevourerDigest devourerDigest
                && devourerDigest.pawn.GetComp<CompDevourer>().DigestingPawn?.IsColonist != true)
            {
                return;
            }

            var args = GetArgsForJob(defName, __instance);
            PartyCauseDef.Named(defName).Push(args);
        }
    }
}