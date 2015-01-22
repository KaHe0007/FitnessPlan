using System;
using System.Collections.Generic;

namespace Fitnessplan.XmlStructure
{
    public class Plan
    {
        public DayOfWeek Wochentag { get; set; }
        public List<PlanUebung> PlanUebung { get; set; } 
    }

    public static class PlanConstants
    {
        public const string Montag = "montag";
        public const string Dienstag = "dienstag";
        public const string Mittwoch = "mittwoch";
        public const string Donnerstag = "donnerstag";
        public const string Freitag = "freitag";
        public const string Samstag = "samstag";
        public const string Sonntag = "sonntag";
    }
}