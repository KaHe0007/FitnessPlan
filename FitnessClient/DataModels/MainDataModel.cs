using FitnessClientLibrary.Base;
using FitnessClientLibrary.Common;

namespace FitnessClient.DataModels
{
    public class MainDataModel : ModelBase
    {
        private IView _verzeichnisView;
        public IView VerzeichnisView
        {
            get { return _verzeichnisView; }
            set
            {
                _verzeichnisView = value;
                NotifyPropertyChanged("VerzeichnisView");
            }
        }

        private IView _uebungView;
        public IView UebungView
        {
            get { return _uebungView; }
            set
            {
                _uebungView = value;
                NotifyPropertyChanged("UebungView");
            }
        }

        private IView _themenView;
        public IView ThemenView
        {
            get { return _themenView; }
            set
            {
                _themenView = value;
                NotifyPropertyChanged("ThemenView");
            }
        }

        private IView _planungView;
        public IView PlanungView
        {
            get { return _planungView; }
            set
            {
                _planungView = value;
                NotifyPropertyChanged("PlanungView");
            }
        }
        
        private IView _trainingView;
        public IView TrainingView
        {
            get { return _trainingView; }
            set
            {
                _trainingView = value;
                NotifyPropertyChanged("TrainingView");
            }
        }

        private IView _einstellungenView;
        public IView EinstellungenView
        {
            get { return _einstellungenView; }
            set
            {
                _einstellungenView = value;
                NotifyPropertyChanged("EinstellungenView");
            }
        }
    }
}
