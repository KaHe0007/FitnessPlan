using System.Collections.Generic;
using FitnessClientLibrary.Base;

namespace FitnessClient.DataModels
{
    public class VerzeichnisDataModel : ModelBase
    {
        private IEnumerable<Verzeichnis> _verzeichnisse;
        public IEnumerable<Verzeichnis> Verzeichnisse
        {
            get { return _verzeichnisse; }
            set
            {
                _verzeichnisse = value;
                NotifyPropertyChanged("Verzeichnisse");
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

        private Verzeichnis _neuesVerzeichnis;
        public Verzeichnis NeuesVerzeichnis
        {
            get { return _neuesVerzeichnis; }
            set
            {
                _neuesVerzeichnis = value;
                NotifyPropertyChanged("NeuesVerzeichnis");
            }
        }
    }
}
