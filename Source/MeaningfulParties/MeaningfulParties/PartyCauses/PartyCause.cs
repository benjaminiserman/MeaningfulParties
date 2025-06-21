using Verse;

namespace MeaningfulParties.PartyCauses
{
    public class PartyCause
    {
        public int Day { get; set; }
        public PartyCauseDef Def { get; set; }

        public object Target { get; set; }
        public object Target2 { get; set; }

        public PartyCause(int day, PartyCauseDef def)
        {
            Day = day;
            Def = def;
        }
    }
}