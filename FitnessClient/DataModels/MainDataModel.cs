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

        private IView _UebungView;
        public IView UebungView
        {
            get { return _UebungView; }
            set
            {
                _UebungView = value;
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
    }
}
