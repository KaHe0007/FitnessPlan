using FitnessClientLibrary.Base;
using FitnessClientLibrary.Common;

namespace FitnessClient.DataModels
{
    public class MainDataModel : ModelBase
    {
        private IView _contentView;
        public IView ContentView
        {
            get { return _contentView; }
            set
            {
                _contentView = value;
                NotifyPropertyChanged("ContentView");
            }
        }
    }
}
