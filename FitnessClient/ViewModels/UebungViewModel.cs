using System.Linq;
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
            NeueUebung = new Uebung();
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
            SelectedVerzeichnis = new ObservableProperty<Verzeichnis>();
            SelectedVerzeichnis.Subscribe(ChangeVerzeichnis);
            NeuSelectedVerzeichnis = new ObservableProperty<Verzeichnis>();
            NeuSelectedVerzeichnis.Subscribe(ChangeNeuVerzeichnis);
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
        
        private void ChangeNeuVerzeichnis(Verzeichnis verzeichnis)
        {
            if (verzeichnis != null)
            {
                ThemenNeu = FitnessDataService.Instance.ThemaService.Select()
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
            NeueUebung = new Uebung();
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

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete));
            }
        }

        private void Delete(object value)
        {
            FitnessDataService.Instance.UebungService.Delete(SelectedUebung);
        }
    }
}
