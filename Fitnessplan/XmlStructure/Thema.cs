using System.Collections.Generic;

namespace Fitnessplan.XmlStructure
{
    public class Thema
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Kategorie { get; set; }
        public List<Uebung> Uebung { get; set; }
    }
    
    public static class ThemaConstants
    {
        public const string Id = "id";
        public const string Titel = "titel";
        public const string Kategorie = "kategorie";
        public const string Thema = "thema";
    }
}