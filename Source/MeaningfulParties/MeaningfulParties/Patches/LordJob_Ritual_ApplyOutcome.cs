using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(LordJob_Ritual), nameof(LordJob_Ritual.ApplyOutcome))]
    public class LordJob_Ritual_ApplyOutcome
    {
        private static HashSet<string> _rituals = new HashSet<string>
        {
            nameof(PartyCauseDefOf.AnimaTreeLinking),
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

        public static void AddPartyCause(LordJob_Ritual jobRitual)
        {
            var ritualDefName = jobRitual.Ritual.behavior.def.defName;
            if (_rituals.Contains(ritualDefName))
            {
                var args = GetArgsForRitual(ritualDefName, jobRitual);
                PartyCauseDef.Named(ritualDefName).Push(args);
            }
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var existingApply = AccessTools.Method(typeof(RitualOutcomeEffectWorker), "Apply");
            var found = false;
            foreach (var instruction in instructions)
            {
                yield return instruction;

                if (instruction.opcode == OpCodes.Callvirt && (MethodInfo)instruction.operand == existingApply)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call,
                        typeof(LordJob_Ritual_ApplyOutcome).GetMethod(nameof(AddPartyCause)));
                    found = true;
                }
            }

            if (!found)
            {
                Log.Error($"Failed to find MethodInfo {existingApply} in patch {nameof(LordJob_Ritual_ApplyOutcome)}");
            }
        }
    }
}