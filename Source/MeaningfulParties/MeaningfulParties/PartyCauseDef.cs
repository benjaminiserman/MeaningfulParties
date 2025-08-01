using MeaningfulParties.PartyCauses;
using RimWorld;
using Verse;

namespace MeaningfulParties
{
    public class PartyCauseDef : Def
    {
        public string letterText;
        public int weight;
        public int daysLength;

        public void Push(PartyCauseTracker tracker = null)
        {
            var foundTracker = tracker ?? Find.World.GetComponent<PartyCauseTracker>();
            foundTracker.PushPartyCause(new PartyCause(GenDate.DaysPassed, this));
        }

        public void Push(params object[] targets)
        {
            var target1 = targets.Length >= 1 ? targets[0] : null;
            var target2 = targets.Length >= 2 ? targets[1] : null;

            var foundTracker = Find.World.GetComponent<PartyCauseTracker>();
            foundTracker.PushPartyCause(new PartyCause(GenDate.DaysPassed, this)
            {
                Target = target1,
                Target2 = target2,
            });
        }

        public static PartyCauseDef Named(string defName) => DefDatabase<PartyCauseDef>.GetNamed(defName);
    }
}