﻿using System.Linq;
using FitnessClient.DataModels;
using FitnessClient.DataService;
using FitnessClientLibrary.Command;
using FitnessClientLibrary.Common;

namespace FitnessClient.ViewModels
{
    public class UebungViewModel : UebungDataModel
    {
        public UebungViewModel()
        {
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
            SelectedVerzeichnis = new ObservableProperty<Verzeichnis>();
            SelectedVerzeichnis.Subscribe(ChangeVerzeichnis);
            SelectedThema = new ObservableProperty<Thema>();
            SelectedThema.Subscribe(ChangeThema);
        }

        private void ChangeVerzeichnis(Verzeichnis verzeichnis)
        {
            if (verzeichnis != null)
            {
                Themen = FitnessDataService.Instance.ThemaService.Select()
                                           .Where(x => x.VerzeichnisId == verzeichnis.VerzeichnisId);
            }
        }

        private void ChangeThema(Thema thema)
        {
            if (thema != null)
            {
                Uebung = FitnessDataService.Instance.UebungService.Select().Where(x => x.ThemaId == thema.ThemaId);
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(Add));
            }
        }

        private void Add(object value)
        {
            FitnessDataService.Instance.UebungService.Insert(NeueUebung);
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(Save));
            }
        }

        private void Save(object value)
        {
            FitnessDataService.Instance.UebungService.Update();
        }
    }
}
