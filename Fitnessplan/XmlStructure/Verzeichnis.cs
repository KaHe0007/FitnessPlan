using System;
using System.Collections.Generic;
using Fitnessplan.Structure;

namespace Fitnessplan.XmlStructure
{
    public class Verzeichnis
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Beschreibung { get; set; }
        public string Thema { get; set; }
        public UebungSchema Schema { get; set; }
        public List<Thema> ThemaListe { get; set; }
    }

    public static class VerzeichnisConstants
    {
        public const string Id = "id";
        public const string Titel = "titel";
        public const string Beschreibung = "beschreibung";
        public const string Schema = "schema";
        public const string Thema = "thema";

        public static UebungSchema GetSchemaFromString(string schema)
        {
            return (UebungSchema)Enum.Parse(typeof(UebungSchema), schema);
        }
    }
}