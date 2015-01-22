using System.Collections.Generic;
using FitnessClientLibrary.Base;
using FitnessClientLibrary.Common;

namespace FitnessClient.DataModels
{
    public class ThemaDataModel : ModelBase
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
        
        private IEnumerable<Thema> _themen;
        public IEnumerable<Thema> Themen
        {
            get { return _themen; }
            set
            {
                _themen = value;
                NotifyPropertyChanged("Themen");
            }
        }

        private IEnumerable<Trainingsart> _trainingsarten;
        public IEnumerable<Trainingsart> Trainingsarten
        {
            get { return _trainingsarten; }
            set
            {
                _trainingsarten = value;
                NotifyPropertyChanged("Trainingsarten");
            }
        }

        private Thema _selectedThema;
        public Thema SelectedThema
        {
            get { return _selectedThema; }
            set
            {
                _selectedThema = value;
                NotifyPropertyChanged("SelectedThema");
            }
        }

        private Thema _neuesThema;
        public Thema NeuesThema
        {
            get { return _neuesThema; }
            set
            {
                _neuesThema = value;
                NotifyPropertyChanged("NeuesThema");
            }
        }

        private ObservableProperty<Verzeichnis> _selectedVerzeichnis;
        public ObservableProperty<Verzeichnis> SelectedVerzeichnis
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
