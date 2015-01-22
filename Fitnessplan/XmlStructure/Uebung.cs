namespace Fitnessplan.XmlStructure
{
    public class Uebung
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public string ImagePath { get; set; }
        public string Stufe { get; set; }
    }

    public static class UebungConstants
    {
        public const string Id = "id";
        public const string Name = "name";
        public const string Beschreibung = "beschreibung";
        public const string ImagePath = "bild";
        public const string Stufe = "stufe";
    }
}
