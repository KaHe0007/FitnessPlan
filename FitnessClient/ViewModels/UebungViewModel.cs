using System.Linq;
using FitnessClient.DataModels;
using FitnessClient.DataService;
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
    }
}
