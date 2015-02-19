using System;
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

        private IEnumerable<Uebung> _uebungen;
        public IEnumerable<Uebung> Uebungen
        {
            get { return _uebungen; }
            set
            {
                _uebungen = value;
                NotifyPropertyChanged("Uebungen");
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

        private ObservableProperty<int> _selectedWeek;
        public ObservableProperty<int> SelectedWeek
        {
            get { return _selectedWeek; }
            set
            {
                _selectedWeek = value;
                NotifyPropertyChanged("SelectedWeek");
            }
        }

        private IList<Tuple<string, DateTime, int>> _weekdays;
        public IList<Tuple<string, DateTime, int>> Weekdays
        {
            get { return _weekdays; }
            set
            {
                _weekdays = value;
                NotifyPropertyChanged("Weekdays");
            }
        }

        private IList<Plan> _wochenplan;
        public IList<Plan> Wochenplan
        {
            get { return _wochenplan; }
            set
            {
                _wochenplan = value;
                NotifyPropertyChanged("Wochenplan");
            }
        }

        private ObservableProperty<Tuple<string, DateTime, int>> _selectedWeekday;
        public ObservableProperty<Tuple<string, DateTime, int>> SelectedWeekday
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

        private List<Thema> _selectedThemen;
        public List<Thema> SelectedThemen
        {
            get { return _selectedThemen; }
            set
            {
                _selectedThemen = value;
                NotifyPropertyChanged("SelectedThemen");
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