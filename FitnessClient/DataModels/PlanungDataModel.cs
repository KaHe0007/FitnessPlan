using System.Collections.Generic;
using FitnessClientLibrary.Base;
using FitnessClientLibrary.Common;

namespace FitnessClient.DataModels
{
    public class PlanungDataModel : ModelBase
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
        
        private IEnumerable<int> _weeks;
        public IEnumerable<int> Weeks
        {
            get { return _weeks; }
            set
            {
                _weeks = value;
                NotifyPropertyChanged("Weeks");
            }
        }

        private int _selectedWeek;
        public int SelectedWeek
        {
            get { return _selectedWeek; }
            set
            {
                _selectedWeek = value;
                NotifyPropertyChanged("SelectedWeek");
            }
        }
        
        private IEnumerable<string> _weekdays;
        public IEnumerable<string> Weekdays
        {
            get { return _weekdays; }
            set
            {
                _weekdays = value;
                NotifyPropertyChanged("Weekdays");
            }
        }
        
        private string _selectedWeekday;
        public string SelectedWeekday
        {
            get { return _selectedWeekday; }
            set
            {
                _selectedWeekday = value;
                NotifyPropertyChanged("SelectedWeekday");
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

        private List<Thema> _selectedUebungen;
        public List<Thema> SelectedUebungen
        {
            get { return _selectedUebungen; }
            set
            {
                _selectedUebungen = value;
                NotifyPropertyChanged("SelectedUebungen");
            }
        }

        private object _selectedTreeItem;
        public object SelectedTreeItem
        {
            get { return _selectedTreeItem; }
            set
            {
                _selectedTreeItem = value;
                NotifyPropertyChanged("SelectedTreeItem");
            }
        }

        private object _selectedUebungItem;
        public object SelectedUebungItem
        {
            get { return _selectedUebungItem; }
            set
            {
                _selectedUebungItem = value;
                NotifyPropertyChanged("SelectedUebungItem");
            }
        }
    }
}
