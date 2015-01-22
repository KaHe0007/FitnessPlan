using System.Collections.Generic;
using FitnessLibrary.Base;
using Fitnessplan.XmlStructure;

namespace Fitnessplan.DataModel
{
    public class TodayDataModel : ModelBase
    {
        private List<Verzeichnis> _verzeichnis;
        public List<Verzeichnis> Verzeichnis
        {
            get { return _verzeichnis; }
            set
            {
                _verzeichnis = value;
                NotifyPropertyChanged("Verzeichnis");
            }
        }

        private Plan _plan;
        public Plan Plan
        {
            get { return _plan; }
            set
            {
                _plan = value;
                NotifyPropertyChanged("Plan");
            }
        }
    }
}
