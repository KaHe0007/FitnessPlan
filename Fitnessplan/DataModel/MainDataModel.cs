using FitnessLibrary.Base;

namespace Fitnessplan.DataModel
{
    public class MainDataModel : ModelBase
    {
        private string _today;
        public string Today
        {
            get { return _today; }
            set
            {
                _today = value;
                NotifyPropertyChanged("Today");
            }
        }

        private string _tomorrow;
        public string Tomorrow
        {
            get { return _tomorrow; }
            set
            {
                _tomorrow = value;
                NotifyPropertyChanged("Tomorrow");
            }
        }
    }
}