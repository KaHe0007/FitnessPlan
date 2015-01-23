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
    public class PlanungViewModel : PlanungDataModel
    {
        public PlanungViewModel()
        {
            LoadWeeksAndDays();
            LoadTree();
            Wochenplan = new List<Plan>();
            SelectedUebungen = new List<Thema>();
        }

        private void LoadTree()
        {
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
            SelectedTreeItem = new Uebung();
            SelectedVerzeichnis = new ObservableProperty<Verzeichnis>();
            SelectedVerzeichnis.Subscribe(SubscribeVerzeichnis);
            SelectedVerzeichnis.Value = Verzeichnisse.First();
        }

        private void LoadWeeksAndDays()
        {
            var today = DateTime.Now;
            Weeks = WeeksHelper.GetWeeks(today);
            Weekdays = WeeksHelper.WeekDays();

            SelectedWeek = new ObservableProperty<int>();
            SelectedWeek.Subscribe(SubscribeWeek);
            SelectedWeek.Value = WeeksHelper.GetWeekOfYear(today);
            
            SelectedWeekday = new ObservableProperty<string>();
            SelectedWeekday.Subscribe(SubscribeWeekday);
            SelectedWeekday.Value = Weekdays.First();
        }

        private void SubscribeWeek(int week)
        {
            var monday = WeeksHelper.FirstDateOfWeek(DateTime.Now.Year, week);
            var sunday = monday.AddDays(7);
            var plan = FitnessDataService.Instance.PlanService.Select().Where(x => x.Datum >= monday && x.Datum <= sunday);
            Wochenplan = plan.ToList();
        }

        private void SubscribeVerzeichnis(Verzeichnis verzeichnis)
        {
            Themen = FitnessDataService.Instance.ThemaService.Select()
                                  .Where(x => x.VerzeichnisId == verzeichnis.VerzeichnisId);
        }

        private void SubscribeWeekday(string weekday)
        {
            
        }

        private RelayCommand _uebungAddCommand;
        public RelayCommand UebungAddCommand
        {
            get
            {
                return _uebungAddCommand ?? (_uebungAddCommand = new RelayCommand(UebungAdd));
            }
        }

        private void UebungAdd(object value)
        {
            var dummy = new List<Thema>();
            dummy = SelectedUebungen;
            var thema = SelectedTreeItem as Thema;
            if (thema != null)
            {
                dummy.Add(thema);
            }
            else
            {
                var uebung = SelectedTreeItem as Uebung;
                var values = SelectedUebungen.Find(x => x.ThemaId == uebung.ThemaId);
                if (values != null)
                {
                    //Thema gibt schon mal
                    values.Uebung.Add(uebung);
                    //TODO: ???
                }
                else
                {
                    //Thema gibts noch nicht
                    var newThema = uebung.Thema;
                    newThema.Uebung.Clear();
                    newThema.Uebung.Add(uebung);
                    dummy.Add(newThema);
                }
            }

            if (dummy.Any())
            {
                SelectedUebungen = new List<Thema>(dummy);
            }
        }

        private RelayCommand _uebungDeleteCommand;
        public RelayCommand UebungDeleteCommand
        {
            get
            {
                return _uebungDeleteCommand ?? (_uebungDeleteCommand = new RelayCommand(UebungDelete));
            }
        }

        private void UebungDelete(object value)
        {
            var mondayList = new List<Thema>();
            mondayList = SelectedUebungen;
            var thema = SelectedUebungItem as Thema;
            if (thema != null)
            {
                mondayList.Remove(thema);
            }
            //else
            //{
            //    var uebung = SelectedUebungItem as Uebung;
            //    mondayList.Find(x => x.Uebung == uebung)

            //    {
            //        mondayList.Remove(uebung);
            //    }
            //}

            SelectedUebungen = new List<Thema>(mondayList);
        }

        private RelayCommand _savePlanCommand;
        public RelayCommand SavePlanCommand
        {
            get
            {
                return _savePlanCommand ?? (_savePlanCommand = new RelayCommand(SavePlan));
            }
        }

        private void SavePlan(object value)
        {
            var a = Wochenplan;
        }
    }
}