using Fitnessplan.Structure;

namespace Fitnessplan.XmlStructure
{
    public class PlanUebung
    {
        public int Id { get; set; }
        public Thema Thema { get; set; }
        public UebungSchema Schema { get; set; }
        public string Kategorie { get; set; }
        public int Wiederholung { get; set; }
        public int Anzahl { get; set; }
        public int AktStufe { get; set; }
    }
    
    public static class PlanUebungConstants
    {
        public const string Id = "id";
        public const string Thema = "thema";
        public const string Schema = "schema";
        public const string Kategorie = "kategorie";
        public const string Wiederholung = "wiederholung";
        public const string Anzahl = "anzahl";
        public const string AktStufe = "aktStufe";
    }
}