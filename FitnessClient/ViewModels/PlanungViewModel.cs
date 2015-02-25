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
        private int _benutzerId = 1;

        public PlanungViewModel()
        {
            Wochenplan = new List<Plan>();
            SelectedThemen = new List<Thema>();
            LoadWeeksAndDays();
            LoadTree();
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
            var week = WeeksHelper.GetWeekOfYear(today);
            Weeks = WeeksHelper.GetWeeks(today);
            Weekdays = new List<Tuple<string, DateTime, int>>();

            var monday = WeeksHelper.FirstDateOfWeek(DateTime.Now.Year, week);
            Weekdays.Add(new Tuple<string, DateTime, int>("Montag", monday, GetPlanId(monday)));
            Weekdays.Add(new Tuple<string, DateTime, int>("Dienstag", monday.AddDays(1), GetPlanId(monday.AddDays(1))));
            Weekdays.Add(new Tuple<string, DateTime, int>("Mittwoch", monday.AddDays(2), GetPlanId(monday.AddDays(2))));
            Weekdays.Add(new Tuple<string, DateTime, int>("Donnerstag", monday.AddDays(3), GetPlanId(monday.AddDays(3))));
            Weekdays.Add(new Tuple<string, DateTime, int>("Freitag", monday.AddDays(4), GetPlanId(monday.AddDays(4))));
            Weekdays.Add(new Tuple<string, DateTime, int>("Samstag", monday.AddDays(5), GetPlanId(monday.AddDays(5))));
            Weekdays.Add(new Tuple<string, DateTime, int>("Sonntag", monday.AddDays(6), GetPlanId(monday.AddDays(6))));

            SelectedWeek = new ObservableProperty<int>();
            SelectedWeek.Subscribe(SubscribeWeek);
            SelectedWeek.Value = WeeksHelper.GetWeekOfYear(today) + 1; //Standardmäßig die nächste Woche auswählen

            SelectedWeekday = new ObservableProperty<Tuple<string, DateTime, int>>();
            SelectedWeekday.Subscribe(SubscribeWeekday);
            SelectedWeekday.Value = Weekdays.First(); //Standardmäßig den Montag auswählen
        }

        private int GetPlanId(DateTime datum)
        {
            if (datum.Year.ToString() != "0001")
            {
                var firstDatum = FitnessDataService.Instance.TageService.Select().Where(x => x.Datum == datum);
                if (firstDatum.Any())
                {
                    var entry = FitnessDataService.Instance.PlanService.Select().Where(x => x.DatumId == firstDatum.First().DatumId);
                    if (entry.Any())
                        return entry.First().PlanId;
                    return
                        FitnessDataService.Instance.PlanService.Insert(new Plan
                                                                           {
                                                                               BenutzerId = _benutzerId,
                                                                               DatumId = firstDatum.First().DatumId
                                                                           }).PlanId;
                }
            }
            return 0;
        }

        private void SubscribeWeek(int week)
        {
            foreach (var day in Weekdays)
            {
                var firstDatum = FitnessDataService.Instance.TageService.Select().Where(x => x.Datum == day.Item2);
                var tag = FitnessDataService.Instance.PlanService.Select().First(x => x.DatumId == firstDatum.First().DatumId);
                var datum = FitnessDataService.Instance.TageService.Select().Where(x => x.Datum == day.Item2);
                if(datum.Any())
                    Wochenplan.Add(tag ?? new Plan { BenutzerId = 1, DatumId = datum.First().DatumId });
            }
        }

        private void SubscribeVerzeichnis(Verzeichnis verzeichnis)
        {
            if (verzeichnis != null)
            {
                Themen = FitnessDataService.Instance.ThemaService.Select()
                                           .Where(x => x.VerzeichnisId == verzeichnis.VerzeichnisId);
                if (Themen.Any())
                {
                    foreach (var t in Themen.ToList())
                    {
                        var themaId = t.ThemaId;
                        Uebungen = FitnessDataService.Instance.UebungService.Select().Where(x => x.ThemaId == themaId).ToList();
                    }
                }
            }
        }

        private void SubscribeWeekday(Tuple<string, DateTime, int> weekday)
        {
            if (weekday != null && weekday.Item2.Year != 0001 && Wochenplan.Any())
            {
                var firstDatum = FitnessDataService.Instance.TageService.Select().Where(x => x.Datum == weekday.Item2);
                if (firstDatum.Any())
                {
                    var first = firstDatum.First().DatumId;
                    var tagesplan = Wochenplan.FirstOrDefault(x => x.DatumId == first);
                    if (tagesplan != null)
                    {
                        var tagesprogramm = FitnessDataService.Instance.ProgrammService.Select()
                                              .Where(x => x.PlanId == tagesplan.PlanId);
                        var uebungen = tagesprogramm.Select(programm => FitnessDataService.Instance.UebungService.Select()
                                                  .First(x => x.UebungId == programm.UebungId)).ToList();

                        var tempThemen = new List<Thema>();
                        foreach (var uebung in uebungen)
                        {
                            var thema = tempThemen.Where(x => x.ThemaId == uebung.ThemaId);
                            if (thema.Any())
                            {
                                //Thema existiert bereits, Übung ergänzen
                                thema.First().Uebung.Add(uebung);
                            }
                            else
                            {
                                if (uebung.ThemaId != null)
                                {
                                    //Thema muss erst angelegt werden
                                    var uebungWithThema = FitnessDataService.Instance.ThemaService.Select()
                                                          .First(x => x.ThemaId == uebung.ThemaId);
                                    var newThema = uebungWithThema;
                                    newThema.Uebung.Clear();
                                    newThema.Uebung.Add(uebung);
                                    tempThemen.Add(uebungWithThema);
                                }
                            }
                        }
                        SelectedThemen = new List<Thema>(tempThemen);
                    }
                }
            }
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
            //TODO: Die Datenbank wird warum auch immer umgesetzt
            var thema = SelectedTreeItem as Thema;
            if (thema != null)
            {
                //ganzes Thema mit allen Übungen hinzufügen
                var uebungen = FitnessDataService.Instance.UebungService.Select().Where(x => x.ThemaId == thema.ThemaId).ToList();
                foreach (var uebung in uebungen)
                {
                    FitnessDataService.Instance.ProgrammService.Insert(new Programm
                    {
                        PlanId = SelectedWeekday.Value.Item3,
                        UebungId = uebung.UebungId
                    });
                }
            }
            else
            {
                //einzelne Übung hinzufügen
                var uebung = SelectedTreeItem as Uebung;
                if (uebung != null)
                {
                    var programm = new Programm
                                       {
                                           PlanId = SelectedWeekday.Value.Item3,
                                           UebungId = uebung.UebungId
                                       };
                    FitnessDataService.Instance.ProgrammService.Insert(programm);
                }
            }

            SubscribeWeekday(SelectedWeekday.Value);
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
            var thema = SelectedUebungItem as Thema;
            if (thema != null)
            {
                //komplettes Thema entfernen
                var uebungen = FitnessDataService.Instance.UebungService.Select().Where(x => x.ThemaId == thema.ThemaId).ToList();
                foreach (var uebung in uebungen)
                {
                    var p = FitnessDataService.Instance.ProgrammService.Select().Where(x => x.PlanId == SelectedWeekday.Value.Item3 && x.UebungId == uebung.UebungId);
                    foreach (var programm in p)
                    {
                        FitnessDataService.Instance.ProgrammService.Delete(programm);
                    }
                }
            }
            else
            {
                //einzelne Übung entfernen
                var uebung = SelectedUebungItem as Uebung;
                if (uebung != null)
                {
                    var programm = FitnessDataService.Instance.ProgrammService.Select().First(x => x.PlanId == SelectedWeekday.Value.Item3 && x.UebungId == uebung.UebungId);
                    FitnessDataService.Instance.ProgrammService.Delete(programm);
                }
            }
            SubscribeWeekday(SelectedWeekday.Value);
        }
    }
}