using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(TaleRecorder), nameof(TaleRecorder.RecordTale))]
    public class TaleRecorder_RecordTale
    {
        private static HashSet<string> _tales = new HashSet<string>
        {
            nameof(PartyCauseDefOf.TamedAnimal),
            nameof(PartyCauseDefOf.Recruited),
            nameof(PartyCauseDefOf.BondedWithAnimal),
            nameof(PartyCauseDefOf.BecameLover),
            nameof(PartyCauseDefOf.Breakup),
            nameof(PartyCauseDefOf.SocialFight),
            nameof(PartyCauseDefOf.CollapseDodged),
            nameof(PartyCauseDefOf.CaravanAssaultSuccessful),
            nameof(PartyCauseDefOf.GainedMasterSkillWithPassion),
            nameof(PartyCauseDefOf.CompletedLongConstructionProject),
            nameof(PartyCauseDefOf.CompletedLongCraftingProject),
            nameof(PartyCauseDefOf.DefeatedHostileFactionLeader),
            nameof(PartyCauseDefOf.LaunchedShip),
            nameof(PartyCauseDefOf.ClosedTheVoid),
            nameof(PartyCauseDefOf.EmbracedTheVoid),
            nameof(PartyCauseDefOf.TileSettled),
            nameof(PartyCauseDefOf.BuiltSnowman),
            nameof(PartyCauseDefOf.StruckMineable),
            nameof(PartyCauseDefOf.FinishedResearchProject)
        };

        static void Prefix(TaleDef def, object[] args)
        {
            if (_tales.Contains(def.defName))
            {
                PartyCauseDef.Named(def.defName).Push(targets: args);
            }

            if (def.defName == nameof(PartyCauseDefOf.GaveBirth))
            {
                var pawn = args[0] as Pawn;

                if (pawn.IsNonMutantAnimal && !pawn.Name.ToStringShort.Any(char.IsDigit))
                {
                    PartyCauseDefOf.GaveBirthAnimal.Push(targets: args);
                }
                else if (pawn.IsColonist)
                {
                    PartyCauseDefOf.GaveBirth.Push(targets: args);
                }
            }
        }
    }
}