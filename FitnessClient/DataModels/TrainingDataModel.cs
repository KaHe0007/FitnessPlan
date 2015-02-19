using FitnessClientLibrary.Base;

namespace FitnessClient.DataModels
{
    public class TrainingDataModel : ModelBase
    {
        private string _youtubeUrl;
        public string YoutubeUrl
        {
            get { return _youtubeUrl; }
            set
            {
                _youtubeUrl = value;
                NotifyPropertyChanged("YoutubeUrl");
            }
        }

        private string _selectedDatum;
        public string SelectedDatum
        {
            get { return _selectedDatum; }
            set
            {
                _selectedDatum = value;
                NotifyPropertyChanged("SelectedDatum");
            }
        }
        
        private string _bild;
        public string Bild
        {
            get { return _bild; }
            set
            {
                _bild = value;
                NotifyPropertyChanged("Bild");
            }
        }
        
        private bool _nextVisible;
        public bool NextVisible
        {
            get { return _nextVisible; }
            set
            {
                _nextVisible = value;
                NotifyPropertyChanged("NextVisisble");
            }
        }

        private Training _selectedTraining;
        public Training SelectedTraining
        {
            get { return _selectedTraining; }
            set
            {
                _selectedTraining = value;
                NotifyPropertyChanged("SelectedTraining");
            }
        }

        private Uebung _selectedUebung;
        public Uebung SelectedUebung
        {
            get { return _selectedUebung; }
            set
            {
                _selectedUebung = value;
                NotifyPropertyChanged("SelectedUebung");
            }
        }
        
        private Plan _today;
        public Plan Today
        {
            get { return _today; }
            set
            {
                _today = value;
                NotifyPropertyChanged("Today");
            }
        }
    }
}
