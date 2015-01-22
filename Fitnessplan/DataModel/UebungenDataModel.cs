using System.Collections.Generic;
using FitnessLibrary.Base;
using Fitnessplan.XmlStructure;

namespace Fitnessplan.DataModel
{
    public class UebungDataModel : ModelBase
    {
        private IEnumerable<Verzeichnis> _uebungsVerzeichnis;
        public IEnumerable<Verzeichnis> UebungsVerzeichnis
        {
            get { return _uebungsVerzeichnis; }
            set
            {
                _uebungsVerzeichnis = value;
                NotifyPropertyChanged("UebungsVerzeichnis");
            }
        }

        private Verzeichnis _selectedVerzeichnis;
        public Verzeichnis SelectedVerzeichnis
        {
            get { return _selectedVerzeichnis; }
            set
            {
                _selectedVerzeichnis = value;
                NotifyPropertyChanged("SelectedVerzeichnis");
            }
        }
    }
}
