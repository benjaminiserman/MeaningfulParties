using System.IO;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace MeaningfulParties
{
    public class MeaningfulPartiesMod : Mod
    {
        internal static string VersionDir => Path.Combine(ModLister.GetActiveModWithIdentifier("winggar.meaningfulparties").RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public MeaningfulPartiesMod(ModContentPack content) : base(content)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            if (Prefs.DevMode)
            {
                File.WriteAllText(VersionDir, CurrentVersion);
            }

            new Harmony("winggar.meaningfulparties").PatchAll();
        }
    }
}