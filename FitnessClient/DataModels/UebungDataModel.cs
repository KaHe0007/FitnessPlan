﻿using System.Collections.Generic;
using FitnessClientLibrary.Base;
using FitnessClientLibrary.Common;

namespace FitnessClient.DataModels
{
    public class UebungDataModel : ModelBase
    {
        private IEnumerable<Uebung> _Uebung;
        public IEnumerable<Uebung> Uebung
        {
            get { return _Uebung; }
            set
            {
                _Uebung = value;
                NotifyPropertyChanged("Uebung");
            }
        }

        private Uebung _selectedUebung;
        public Uebung SelectedUebung
        {
            get { return _selectedUebung; }
            set
            {
                _selectedUebung = value;
                NotifyPropertyChanged("SelectedUebung");
            }
        }

        private Uebung _neueUebung;
        public Uebung NeueUebung
        {
            get { return _neueUebung; }
            set
            {
                _neueUebung = value;
                NotifyPropertyChanged("NeueUebung");
            }
        }

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

        private ObservableProperty<Thema> _selectedThema;
        public ObservableProperty<Thema> SelectedThema
        {
            get { return _selectedThema; }
            set
            {
                _selectedThema = value;
                NotifyPropertyChanged("SelectedThema");
            }
        }
    }
}
