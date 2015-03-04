using System;
using System.Collections.Generic;
using System.Linq;
using FitnessClient.DataModels;
using FitnessClient.DataService;
using FitnessClientLibrary.Command;
using FitnessClientLibrary.Common;
using FitnessClientLibrary.Helper;

namespace FitnessClient.ViewModels
{
    public class TrainingViewModel : TrainingDataModel
    {
        public IList<string> Tage { get; set; }
        private IEnumerator<Programm> Programm { get; set; }

        public TrainingViewModel()
        {
            SelectedDatum = new ObservableProperty<string>();
            SelectedDatum.Subscribe(LoadTraining);
            SelectedDatum.Value = DateTime.Now.ToShortDateString();
            LoadDays();
            LoadTraining(DateTime.Now.ToShortDateString());
        }

        private void LoadTraining(object element)
        {
            var datum = FitnessDataService.Instance.TageService.Select().Where(x => x.Datum.Value.ToShortDateString() == SelectedDatum.Value);
            if (datum.Any())
            {
                var plan = FitnessDataService.Instance.PlanService.Select().FirstOrDefault(x => x.DatumId == datum.First().DatumId);
                if (plan != null)
                {
                    var programm = FitnessDataService.Instance.ProgrammService.Select().Where(x => x.PlanId == plan.PlanId);
                    Programm = programm.GetEnumerator();
                    Programm.MoveNext();

                    if (Programm.Current != null)
                    {
                        SelectedUebung = FitnessDataService.Instance.UebungService.Select()
                                              .First(x => x.UebungId == Programm.Current.UebungId);
                        NextVisible = true;
                        LoadImage();
                    }

                    Today = plan;
                    SelectedTraining = new Training { PlanId = plan.PlanId };
                }
            }
        }

        private void LoadImage()
        {
            var imagePath = SelectedUebung.Bildpfad;
            if(string.IsNullOrEmpty(imagePath))
                Bild = "http://www.womenshealthmag.com/files/wh6_uploads/images/fitness-habits-02.jpg";
            else
            {
                if (imagePath.Contains("http"))
                    Bild = imagePath;
                else
                    Bild = Properties.Settings.Default.Bildpfad + imagePath;
            }
        }

        private void LoadDays()
        {
            var week = WeeksHelper.GetWeekOfYear(DateTime.Now);
            var monday = WeeksHelper.FirstDateOfWeek(DateTime.Now.Year, week);
            Tage = new List<string>
                       {
                           monday.ToShortDateString(),
                           monday.AddDays(1).ToShortDateString(),
                           monday.AddDays(2).ToShortDateString(),
                           monday.AddDays(3).ToShortDateString(),
                           monday.AddDays(4).ToShortDateString(),
                           monday.AddDays(5).ToShortDateString(),
                           monday.AddDays(6).ToShortDateString()
                       };
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(Save));
            }
        }
        
        private void Save(object value)
        {
            //TODO: Bemerkung als Pflichtfeld
            SelectedTraining.Absolviert = true;
            if(SelectedTraining.TrainingId == 0)
                FitnessDataService.Instance.TrainingService.Insert(SelectedTraining);
            else
                FitnessDataService.Instance.TrainingService.Update();
        }
        
        //private RelayCommand _startCommand;
        //public RelayCommand StartCommand
        //{
        //    get
        //    {
        //        return _startCommand ?? (_startCommand = new RelayCommand(Start));
        //    }
        //}
        
        //private void Start(object value)
        //{
        //    LoadTraining(SelectedDatum);
        //}

        private RelayCommand _nextUebungCommand;
        public RelayCommand NextUebungCommand
        {
            get
            {
                return _nextUebungCommand ?? (_nextUebungCommand = new RelayCommand(NextUebung));
            }
        }

        private void NextUebung(object value)
        {
            Programm.MoveNext();
            var next = Programm.Current;
            if (next != null)
            {
                //Nächste Übung
                SelectedUebung = FitnessDataService.Instance.UebungService.Select().First(x => x.UebungId == next.UebungId);
                LoadImage();
            }
            else
            {
                //Training beendet
                NextVisible = false;
            }
        }
    }
}
