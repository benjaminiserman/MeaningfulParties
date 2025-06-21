using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace MeaningfulParties.PartyCauses
{
    public static class TraitCauseHandler
    {
        public static Dictionary<string, PartyCauseDef> TraitPartyCauses = new Dictionary<TraitDef, PartyCauseDef>
            {
                { TraitDefOf.Jealous, PartyCauseDefOf.Jealous },
                { TraitDef.Named("Masochist"), PartyCauseDefOf.Masochist },
                { TraitDefOf.Pyromaniac, PartyCauseDefOf.Pyromaniac },
                { TraitDef.Named("Nimble"), PartyCauseDefOf.Nimble },
                { TraitDef.Named("Tough"), PartyCauseDefOf.Tough },
                { TraitDef.Named("TooSmart"), PartyCauseDefOf.TooSmart},
                { TraitDefOf.Kind, PartyCauseDefOf.Kind },
                { TraitDefOf.CreepyBreathing, PartyCauseDefOf.CreepyBreathing },
                { TraitDefOf.Gay, PartyCauseDefOf.Pride },
                { TraitDefOf.Bisexual, PartyCauseDefOf.Pride },
                { TraitDefOf.Asexual, PartyCauseDefOf.Pride },
                { TraitDefOf.Joyous, PartyCauseDefOf.Joyous },
            }.Where(kvp => kvp.Key != null)
            .ToDictionary(kvp => kvp.Key.defName, kvp => kvp.Value);

        public static Dictionary<string, (Predicate<int> matches, PartyCauseDef def)> ScaledTraitCauses =
            new Dictionary<TraitDef, (Predicate<int>, PartyCauseDef)>
                {
                    { TraitDefOf.Industriousness, (degree => degree > 0, PartyCauseDefOf.Industriousness) },
                    { TraitDef.Named("NaturalMood"), (degree => degree > 0, PartyCauseDefOf.NaturalMood) },
                    { TraitDef.Named("Nerves"), (degree => degree > 0, PartyCauseDefOf.Nerves) },
                    { TraitDef.Named("Beauty"), (degree => degree > 0, PartyCauseDefOf.Beauty) },
                }.Where(kvp => kvp.Key != null)
                .ToDictionary(kvp => kvp.Key.defName, kvp => kvp.Value);

        public static void AddTraitPartyCauses(Pawn pawn)
        {
            foreach (var trait in pawn.story.traits.allTraits)
            {
                if (TraitPartyCauses.ContainsKey(trait.def.defName))
                {
                    TraitPartyCauses[trait.def.defName].Push(pawn);
                }

                if (ScaledTraitCauses.ContainsKey(trait.def.defName)
                    && ScaledTraitCauses[trait.def.defName].matches(trait.Degree))
                {
                    ScaledTraitCauses[trait.def.defName].def.Push(pawn);
                }
            }
        }
    }
}