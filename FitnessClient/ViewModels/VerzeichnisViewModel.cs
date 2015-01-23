using FitnessClient.DataModels;
using FitnessClient.DataService;
using FitnessClientLibrary.Command;

namespace FitnessClient.ViewModels
{
    public class VerzeichnisViewModel : VerzeichnisDataModel
    {
        public VerzeichnisViewModel()
        {
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
            NeuesVerzeichnis = new Verzeichnis();
            SelectedVerzeichnis = new Verzeichnis();
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
            FitnessDataService.Instance.VerzeichnisService.Insert(NeuesVerzeichnis);
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
            FitnessDataService.Instance.VerzeichnisService.Update();
        }
    }
}
