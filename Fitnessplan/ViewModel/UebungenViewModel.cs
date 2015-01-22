using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitnessplan.DataModel;
using Fitnessplan.Structure;
using Fitnessplan.XmlStructure;
using Windows.Data.Xml.Dom;

namespace Fitnessplan.ViewModel
{
    public class UebungViewModel : UebungDataModel
    {
        public UebungViewModel()
        {
            SelectedVerzeichnis = new Verzeichnis();
            var urlVerzeichnis = string.Format("{0}{1}.xml", FitnessConstants.RootUrlUebung, "Uebung");
            LoadVerzeichnisse(new Uri(urlVerzeichnis));
        }

        public async void LoadVerzeichnisse(Uri uri)
        {
            var verzeichnisse = new List<Verzeichnis>();
            var xmlDocument = await XmlDocument.LoadFromUriAsync(uri);
            var nodes = xmlDocument.GetElementsByTagName("verzeichnis")[0].ChildNodes;
            foreach (var node in nodes)
            {
                var attributes = node.Attributes;
                if (attributes != null)
                {
                    var themaValue = GetAttribute(attributes, VerzeichnisConstants.Thema);
                    var verzeichnis = new Verzeichnis
                                          {
                                              Id = GetAttribute(attributes, VerzeichnisConstants.Id),
                                              Beschreibung = GetAttribute(attributes, VerzeichnisConstants.Beschreibung),
                                              Thema = themaValue,
                                              Titel = GetAttribute(attributes, VerzeichnisConstants.Titel),
                                              Schema = VerzeichnisConstants.GetSchemaFromString(GetAttribute(attributes, VerzeichnisConstants.Schema)),
                                              ThemaListe = new List<Thema>()
                                              //ThemaListe = GetThemaList(themaValue).Result
                                          };
                    verzeichnisse.Add(verzeichnis);
                }
            }
            UebungsVerzeichnis = verzeichnisse;
        }

        private async Task<List<Thema>> GetThemaList(string themaValue)
        {
            var listThema = new List<Thema>();
            var urlThema = new Uri(string.Format("{0}{1}", FitnessConstants.RootUrlUebung, themaValue));
            var xmlThema = await XmlDocument.LoadFromUriAsync(urlThema);
            var nodesThema = xmlThema.GetElementsByTagName("thema");
            foreach (var nodeThema in nodesThema)
            {
                var attrThema = nodeThema.Attributes;
                if (attrThema != null)
                {
                    var thema = new Thema
                    {
                        Id = GetAttribute(attrThema, ThemaConstants.Id),
                        Kategorie = GetAttribute(attrThema, ThemaConstants.Kategorie),
                        Titel = GetAttribute(attrThema, ThemaConstants.Titel),
                        Uebung = GetUebungList(nodeThema.ChildNodes).Result
                    };
                    listThema.Add(thema);
                }
            }
            return listThema;
        }

        private async Task<List<Uebung>> GetUebungList(XmlNodeList childNodes)
        {
            var Uebung = new List<Uebung>();
            if (childNodes != null && childNodes.Count > 0)
            {
                foreach (var child in childNodes)
                {
                    var attrUebung = child.Attributes;
                    if (attrUebung != null)
                    {
                        var uebung = new Uebung
                        {
                            Id = GetAttribute(attrUebung, UebungConstants.Id),
                            Beschreibung = GetAttribute(attrUebung, UebungConstants.Beschreibung),
                            Name = GetAttribute(attrUebung, UebungConstants.Name),
                            ImagePath = GetAttribute(attrUebung, UebungConstants.ImagePath),
                            Stufe = GetAttribute(attrUebung, UebungConstants.Stufe)
                        };
                        Uebung.Add(uebung);
                    }
                }
            }
            return Uebung;
        }

        private static string GetAttribute(XmlNamedNodeMap attributes, string name)
        {
            var namedItem = attributes.GetNamedItem(name);
            if (namedItem != null)
                return namedItem.InnerText;
            return null;
        }
    }
}
