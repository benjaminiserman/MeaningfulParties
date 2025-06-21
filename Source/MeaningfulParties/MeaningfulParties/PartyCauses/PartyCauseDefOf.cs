using System.Collections.Generic;
using RimWorld;
// ReSharper disable UnassignedField.Global

namespace MeaningfulParties.PartyCauses
{
    [DefOf]
    public static class PartyCauseDefOf
    {
        public static PartyCauseDef Perseverance;
        public static PartyCauseDef GoodTimes;
        public static PartyCauseDef Comradery;
        public static PartyCauseDef Serenity;
        public static PartyCauseDef StillAlive;
        public static PartyCauseDef Fallen;

        // IncidentWorker_TryExecute
        public static PartyCauseDef AmbrosiaSprout;
        public static PartyCauseDef PsychicSoothe;
        public static PartyCauseDef ThrumboPasses;
        public static PartyCauseDef GameEndedWanderersJoin;
        public static PartyCauseDef Eclipse;
        public static PartyCauseDef Aurora;
        public static PartyCauseDef GiveQuest_EndGame_ShipEscape;

        public static PartyCauseDef RaidEnemy;
        public static PartyCauseDef Infestation;
        public static PartyCauseDef ManhunterPack;

        // TaleRecorder_RecordTale
        public static PartyCauseDef TamedAnimal;
        public static PartyCauseDef Recruited;
        public static PartyCauseDef BondedWithAnimal;
        public static PartyCauseDef BecameLover;
        public static PartyCauseDef GaveBirth;
        public static PartyCauseDef Breakup;
        public static PartyCauseDef SocialFight;
        public static PartyCauseDef CollapseDodged;
        public static PartyCauseDef CaravanAssaultSuccessful;
        public static PartyCauseDef GainedMasterSkillWithPassion;
        public static PartyCauseDef CompletedLongConstructionProject;
        public static PartyCauseDef CompletedLongCraftingProject;
        public static PartyCauseDef DefeatedHostileFactionLeader;
        public static PartyCauseDef LaunchedShip;
        public static PartyCauseDef ClosedTheVoid;
        public static PartyCauseDef EmbracedTheVoid;
        public static PartyCauseDef TileSettled;
        public static PartyCauseDef BuiltSnowman;
        public static PartyCauseDef StruckMineable;
        public static PartyCauseDef FinishedResearchProject;

        // Others
        public static PartyCauseDef BestowingCeremony;
        public static PartyCauseDef Birthday;

        public static IEnumerable<PartyCauseDef> GetDefaultPartyCauseDefs()
        {
            return new List<PartyCauseDef>()
            {
                Perseverance,
                GoodTimes,
                Comradery,
                Serenity,
                StillAlive,
                Fallen
            };
        }
    }
}