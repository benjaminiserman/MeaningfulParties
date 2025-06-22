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
        public static PartyCauseDef CalmBeforeStorm;

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
        public static PartyCauseDef Resurrection;
        public static PartyCauseDef BabyShower;

        // JobDriver_EndJobWith
        public static PartyCauseDef InstallImplant;
        public static PartyCauseDef AbsorbXenogerm;
        public static PartyCauseDef ActivateMonolith;
        public static PartyCauseDef BuildCubeStructure;
        public static PartyCauseDef CreateXenogerm;
        public static PartyCauseDef DevourerDigest;
        public static PartyCauseDef NociosphereDepart;
        public static PartyCauseDef Nuzzle;
        public static PartyCauseDef Play_Hoopstone;
        public static PartyCauseDef Play_Horseshoes;
        public static PartyCauseDef Play_GameOfUr;
        public static PartyCauseDef Play_Chess;
        public static PartyCauseDef Play_Billiards;
        public static PartyCauseDef Play_MusicalInstrument;
        public static PartyCauseDef Play_Poker;
        public static PartyCauseDef WatchTelevision;
        public static PartyCauseDef UseTelescope;
        public static PartyCauseDef ReleaseAnimalToWild;
        public static PartyCauseDef ActivateArchonexusCore;
        public static PartyCauseDef EmancipateSlave;
        public static PartyCauseDef ReleasePrisoner;
        public static PartyCauseDef Lessontaking;

        // Traits
        public static PartyCauseDef Jealous;
        public static PartyCauseDef Masochist;
        public static PartyCauseDef Pyromaniac;
        public static PartyCauseDef Nimble;
        public static PartyCauseDef Tough;
        public static PartyCauseDef TooSmart;
        public static PartyCauseDef Kind;
        public static PartyCauseDef CreepyBreathing;
        public static PartyCauseDef Pride;
        public static PartyCauseDef Joyous;

        public static PartyCauseDef Industriousness;
        public static PartyCauseDef NaturalMood;
        public static PartyCauseDef Nerves;
        public static PartyCauseDef Beauty;

        // GameCondition_End
        public static PartyCauseDef PsychicDrone;
        public static PartyCauseDef ToxicFallout;
        public static PartyCauseDef VolcanicWinter;
        public static PartyCauseDef HeatWave;
        public static PartyCauseDef ColdSnap;
        public static PartyCauseDef DeathPall;
        public static PartyCauseDef GrayPall;
        public static PartyCauseDef UnnaturalDarkness;
        public static PartyCauseDef NoxiousHaze;

        // Pawn_HealthTracker_RemoveHediff
        public static PartyCauseDef Plague;
        public static PartyCauseDef GutWorms;
        public static PartyCauseDef WoundInfection;
        public static PartyCauseDef Flu;
        public static PartyCauseDef Malaria;
        public static PartyCauseDef SleepingSickness;
        public static PartyCauseDef Blindness;
        public static PartyCauseDef Dementia;
        public static PartyCauseDef Alzheimers;
        public static PartyCauseDef HeartArteryBlockage;
        public static PartyCauseDef AlcoholAddiction;
        public static PartyCauseDef GoJuiceAddiction;
        public static PartyCauseDef PsychiteAddiction;
        public static PartyCauseDef SmokeleafAddiction;
        public static PartyCauseDef WakeUpAddiction;

        // RitualOutcomeEffectWorker_apply
        public static PartyCauseDef AnimaTreeLinking;
        public static PartyCauseDef Bestowing;
        public static PartyCauseDef BlindingCeremony;
        public static PartyCauseDef ScarificationCeremony;
        public static PartyCauseDef TreeConnection;
        public static PartyCauseDef Conversion;
        public static PartyCauseDef GladiatorDuel;
        public static PartyCauseDef Execution;
        public static PartyCauseDef SacrificePrisoner;
        public static PartyCauseDef RoleChange;
        public static PartyCauseDef Trial;
        public static PartyCauseDef ThroneSpeech;
        public static PartyCauseDef LeaderSpeech;

        // Vanilla Events Expanded compat
        [MayRequire("VanillaExpanded.VEE")] public static PartyCauseDef VEE_IceAge;
        [MayRequire("VanillaExpanded.VEE")] public static PartyCauseDef VEE_GlobalWarming;
        [MayRequire("VanillaExpanded.VEE")] public static PartyCauseDef VEE_PsychicRain;
        [MayRequire("VanillaExpanded.VEE")] public static PartyCauseDef VEE_LongNight;

        public static IEnumerable<PartyCauseDef> GetDefaultPartyCauseDefs() => new List<PartyCauseDef>
        {
            Perseverance,
            GoodTimes,
            Comradery,
            Serenity,
            StillAlive,
            Fallen,
            CalmBeforeStorm
        };
    }
}