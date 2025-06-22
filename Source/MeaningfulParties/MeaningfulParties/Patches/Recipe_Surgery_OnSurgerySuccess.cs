using HarmonyLib;
using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties.Patches
{
    [HarmonyPatch(typeof(Recipe_Surgery), "OnSurgerySuccess")]
    public class Recipe_Surgery_OnSurgerySuccess
    {
        public static void Postfix(Recipe_Surgery __instance, Pawn pawn)
        {
            if (__instance is Recipe_InstallArtificialBodyPart
                || __instance is Recipe_InstallNaturalBodyPart
                || __instance is Recipe_InstallImplant)
            {
                PartyCauseDefOf.InstallImplant.Push(pawn, __instance.recipe.addsHediff);
            }
        }
    }
}