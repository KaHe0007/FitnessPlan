using FitnessClient.DataModels;
using FitnessClient.Views;

namespace FitnessClient.ViewModels
{
    public class MainViewModel : MainDataModel
    {
        public MainViewModel()
        {
            UebungView = new UebungView();
            VerzeichnisView = new VerzeichnisView();
            ThemenView = new ThemaView();
            PlanungView = new PlanView();
            TrainingView = new TrainingView();
            EinstellungenView = new EinstellungenView();
        }
    }
}
