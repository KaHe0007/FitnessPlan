using System.Linq;
using FitnessClient.DataModels;
using FitnessClient.DataService;
using FitnessClientLibrary.Command;
using FitnessClientLibrary.Common;

namespace FitnessClient.ViewModels
{
    public class ThemaViewModel : ThemaDataModel
    {
        public ThemaViewModel()
        {
            Trainingsarten = FitnessDataService.Instance.TrainingsartService.Select();
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
            NeuesThema = new Thema();
            SelectedThema = new Thema();
            SelectedVerzeichnis = new ObservableProperty<Verzeichnis>();
            SelectedVerzeichnis.Subscribe(SubscribeVerzeichnis);
            SelectedVerzeichnis.Value = Verzeichnisse.First();
        }

        private void SubscribeVerzeichnis(Verzeichnis value)
        {
            Themen = FitnessDataService.Instance.ThemaService.Select().Where(x => x.VerzeichnisId == value.VerzeichnisId);
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
            FitnessDataService.Instance.ThemaService.Insert(NeuesThema);
            Themen = FitnessDataService.Instance.ThemaService.Select();
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
            FitnessDataService.Instance.ThemaService.Update();
        }
    }
}
