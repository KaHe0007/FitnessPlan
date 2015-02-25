using FitnessClientLibrary.Base;

namespace FitnessClient.DataModels
{
    public class EinstellungenDataModel : ModelBase
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

        private string _bildpfad;
        public string Bildpfad
        {
            get { return _bildpfad; }
            set
            {
                _bildpfad = value;
                NotifyPropertyChanged("Bildpfad");
            }
        }
    }
}
