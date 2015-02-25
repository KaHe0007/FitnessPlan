using FitnessClient.DataModels;
using FitnessClient.Views;
using FitnessClientLibrary.Command;

namespace FitnessClient.ViewModels
{
    public class MainViewModel : MainDataModel
    {
        public MainViewModel()
        {
            ContentView = new TrainingView();
        }

        private RelayCommand _uebungCommand;
        public RelayCommand UebungCommand
        {
            get
            {
                return _uebungCommand ?? (_uebungCommand = new RelayCommand(LoadUebungView));
            }
        }

        public void LoadUebungView(object element)
        {
            ContentView = new UebungView();
        }
        
        private RelayCommand _katalogeCommand;
        public RelayCommand KatalogeCommand
        {
            get
            {
                return _katalogeCommand ?? (_katalogeCommand = new RelayCommand(LoadVerzeichnisView));
            }
        }

        public void LoadVerzeichnisView(object element)
        {
            ContentView = new VerzeichnisView();
        }

        private RelayCommand _themaCommand;
        public RelayCommand ThemaCommand
        {
            get
            {
                return _themaCommand ?? (_themaCommand = new RelayCommand(LoadThemaView));
            }
        }

        public void LoadThemaView(object element)
        {
            ContentView = new ThemaView();
        }
        
        private RelayCommand _planungCommand;
        public RelayCommand PlanungCommand
        {
            get
            {
                return _planungCommand ?? (_planungCommand = new RelayCommand(LoadPlanungView));
            }
        }

        public void LoadPlanungView(object element)
        {
            ContentView = new PlanView();
        }
        
        private RelayCommand _trainingCommand;
        public RelayCommand TrainingCommand
        {
            get
            {
                return _trainingCommand ?? (_trainingCommand = new RelayCommand(LoadTrainingView));
            }
        }

        public void LoadTrainingView(object element)
        {
            ContentView = new TrainingView();
        }
        
        private RelayCommand _einstellungenCommand;
        public RelayCommand EinstellungenCommand
        {
            get
            {
                return _einstellungenCommand ?? (_einstellungenCommand = new RelayCommand(LoadEinstellungenView));
            }
        }

        public void LoadEinstellungenView(object element)
        {
            ContentView = new EinstellungenView();
        }
    }
}
