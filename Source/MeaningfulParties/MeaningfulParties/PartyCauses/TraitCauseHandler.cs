using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace MeaningfulParties.PartyCauses
{
    public static class TraitCauseHandler
    {
        public static Dictionary<string, PartyCauseDef> TraitPartyCauses = new List<(TraitDef key, PartyCauseDef value)>
            {
                (TraitDefOf.Jealous, PartyCauseDefOf.Jealous),
                (TraitDef.Named("Masochist"), PartyCauseDefOf.Masochist),
                (TraitDefOf.Pyromaniac, PartyCauseDefOf.Pyromaniac),
                (TraitDef.Named("Nimble"), PartyCauseDefOf.Nimble),
                (TraitDef.Named("Tough"), PartyCauseDefOf.Tough),
                (TraitDef.Named("TooSmart"), PartyCauseDefOf.TooSmart),
                (TraitDefOf.Kind, PartyCauseDefOf.Kind),
                (TraitDefOf.CreepyBreathing, PartyCauseDefOf.CreepyBreathing),
                (TraitDefOf.Gay, PartyCauseDefOf.Pride),
                (TraitDefOf.Bisexual, PartyCauseDefOf.Pride),
                (TraitDefOf.Asexual, PartyCauseDefOf.Pride),
                (TraitDefOf.Joyous, PartyCauseDefOf.Joyous),
            }.Where(kvp => kvp.key != null)
            .ToDictionary(kvp => kvp.key.defName, kvp => kvp.value);

        public static Dictionary<string, (Predicate<int> matches, PartyCauseDef def)> ScaledTraitCauses =
            new List<(TraitDef key, (Predicate<int>, PartyCauseDef) value)>
                {
                    (TraitDefOf.Industriousness, (degree => degree > 0, PartyCauseDefOf.Industriousness)),
                    (TraitDef.Named("NaturalMood"), (degree => degree > 0, PartyCauseDefOf.NaturalMood)),
                    (TraitDef.Named("Nerves"), (degree => degree > 0, PartyCauseDefOf.Nerves)),
                    (TraitDef.Named("Beauty"), (degree => degree > 0, PartyCauseDefOf.Beauty)),
                }.Where(kvp => kvp.key != null)
                .ToDictionary(kvp => kvp.key.defName, kvp => kvp.value);

        public static void AddTraitPartyCauses(Pawn pawn)
        {
            if (pawn?.story?.traits?.allTraits == null)
            {
                return;
            }

            foreach (var trait in pawn.story.traits.allTraits)
            {
                if (trait?.def?.defName == null)
                {
                    continue;
                }

                if (TraitPartyCauses.ContainsKey(trait.def.defName))
                {
                    TraitPartyCauses[trait.def.defName].Push(pawn);
                }

                if (ScaledTraitCauses.ContainsKey(trait.def.defName)
                    && ScaledTraitCauses[trait.def.defName].matches(trait.Degree))
                {
                    ScaledTraitCauses[trait.def.defName].def?.Push(pawn);
                }
            }
        }
    }
}