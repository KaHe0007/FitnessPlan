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
            Verzeichnisse = FitnessDataService.Instance.VerzeichnisService.Select();
            var today = DateTime.Now;
            Weeks = WeeksHelper.GetWeeks(today);
            Weekdays = WeeksHelper.WeekDays();
            SelectedTreeItem = new Uebung();
            SelectedWeek = WeeksHelper.GetWeekOfYear(today);
            SelectedVerzeichnis = new ObservableProperty<Verzeichnis>();
            SelectedVerzeichnis.Subscribe(LoadThema);
            SelectedVerzeichnis.Value = Verzeichnisse.First();
            SelectedUebungen = new List<Thema>();
        }

        private void LoadThema(Verzeichnis verzeichnis)
        {
            Themen = FitnessDataService.Instance.ThemaService.Select()
                                  .Where(x => x.VerzeichnisId == verzeichnis.VerzeichnisId);
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

        }
    }
}