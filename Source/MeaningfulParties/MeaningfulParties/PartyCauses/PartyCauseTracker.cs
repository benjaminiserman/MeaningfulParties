using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace MeaningfulParties.PartyCauses
{
    public class PartyCauseTracker : WorldComponent
    {
        private static readonly Random Random = new Random();
        private readonly List<PartyCause> _partyCauses = new List<PartyCause>();
        private int _lastDay = 0;

        public void PushPartyCause(PartyCause partyCause)
        {
            if (!_partyCauses.Any(partyCause.IsDuplicateOf))
            {
                _partyCauses.Add(partyCause);
            }
        }

        public PartyCause PullPartyCause()
        {
            _partyCauses.RemoveWhere(cause =>
                cause.Def.daysLength > 0 && GenDate.DaysPassed - cause.Day > cause.Def.daysLength);

            var totalWeight = _partyCauses.Sum(cause => cause.Def.weight);
            var pickNum = Random.Next(totalWeight);
            var runningWeight = 0;
            PartyCause partyCause = null;
            foreach (var cause in _partyCauses)
            {
                if (pickNum < cause.Def.weight + runningWeight)
                {
                    partyCause = cause;
                    break;
                }

                runningWeight += cause.Def.weight;
            }

            if (partyCause == null)
            {
                return null;
            }

            if (partyCause.Def.daysLength > 0)
            {
                _partyCauses.Remove(partyCause);
            }

            return partyCause;
        }

        public PartyCauseTracker(World world) : base(world)
        {
            foreach (var partyCauseDef in PartyCauseDefOf.GetDefaultPartyCauseDefs())
            {
                partyCauseDef.Push(this);
            }
        }

        private static IEnumerable<Pawn> ColonistsAndBondedAnimals() => Find.Maps
            .SelectMany(map => map.mapPawns.AllHumanlike)
            .Where(pawn => pawn.IsColonist)
            .Concat(Find.Maps.SelectMany(map => map.mapPawns.SpawnedColonyAnimals)
                .Where(animal => animal.relations != null && animal.relations.DirectRelations
                    .Any(bond => bond.def == PawnRelationDefOf.Bond)));

        public override void WorldComponentTick()
        {
            if (_lastDay != GenDate.DaysPassed)
            {
                _lastDay = GenDate.DaysPassed;
                foreach (var colonist in ColonistsAndBondedAnimals())
                {
                    if (colonist.ageTracker?.BirthDayOfYear == GenLocalDate.DayOfYear(colonist.Map.Tile))
                    {
                        PartyCauseDefOf.Birthday.Push(colonist);
                    }

                    if (Random.Next(5) == 0)
                    {
                        TraitCauseHandler.AddTraitPartyCauses(colonist);
                    }
                }
            }

            base.WorldComponentTick();
        }
    }
}