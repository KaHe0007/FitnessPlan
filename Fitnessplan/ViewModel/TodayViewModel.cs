using System;
using FitnessLibrary.Helper;
using Fitnessplan.DataModel;
using Fitnessplan.Structure;
using Windows.Data.Xml.Dom;

namespace Fitnessplan.ViewModel
{
    public class TodayViewModel : TodayDataModel
    {
        public TodayViewModel(DateTime date)
        {
            var path = string.Format("{0}{1}/kw{2}.xml", FitnessConstants.RootUrlPlaene, date.Year, WeekOfYear.GetWeekOfYearAsString(date));
            XmlContent = path;
            LoadXmlFile(path, DayOfWeekHelper.GetNameByDate(date));
        }

        private async void LoadXmlFile(string url, string day)
        {
            var uri = new Uri(url);
            var xmlDocument = await XmlDocument.LoadFromUriAsync(uri);
            XmlContent = xmlDocument.GetXml();
            var nodesDay = xmlDocument.GetElementsByTagName(day.ToLower())[0].ChildNodes;
            foreach (var node in nodesDay)
            {
                var attributes = node.Attributes;
                if (attributes != null)
                {
                    var namedItem = attributes.GetNamedItem("id");
                    if (namedItem != null)
                    {
                        var thema = namedItem.InnerText;
                        XmlContentRight += " * " + thema + " * ";

                        if (node.HasChildNodes())
                        {
                            foreach (var childNode in node.ChildNodes)
                            {
                                var childAttributes = childNode.Attributes;
                                if (childAttributes != null && childAttributes.Count > 0)
                                {
                                    var xmlNode = childAttributes.GetNamedItem("kategorie");
                                    if (xmlNode != null)
                                        XmlContentRight += xmlNode.InnerText;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
