using FitnessClient.DataModels;
using FitnessClient.DataService;

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
    }
}
