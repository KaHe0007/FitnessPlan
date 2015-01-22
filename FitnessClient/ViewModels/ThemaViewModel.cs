using FitnessClient.DataModels;
using FitnessClient.DataService;

namespace FitnessClient.ViewModels
{
    public class ThemaViewModel : ThemaDataModel
    {
        public ThemaViewModel()
        {
            Themen = FitnessDataService.Instance.ThemaService.Select();
            Trainingsarten = FitnessDataService.Instance.TrainingsartService.Select();
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
            NeuesThema = new Thema();
            SelectedThema = new Thema();
        }
    }
}
