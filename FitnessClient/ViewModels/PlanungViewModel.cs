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
            
            var today = DateTime.Now;
            var week = WeeksHelper.GetWeekOfYear(today);
            Weeks = WeeksHelper.GetWeeks(today);
            LoadWeekdays(week);

            SelectedWeek = new ObservableProperty<int>();
            SelectedWeek.Subscribe(SubscribeWeek);
            SelectedWeek.Value = WeeksHelper.GetWeekOfYear(today) + 1; //Standardmäßig die nächste Woche auswählen

            SelectedWeekday = new ObservableProperty<Tuple<string, DateTime, int>>();
            SelectedWeekday.Subscribe(SubscribeWeekday);
            SelectedWeekday.Value = Weekdays.First(); //Standardmäßig den Montag auswählen

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

        private void LoadWeekdays(int week)
        {
            var weekdays = new List<Tuple<string, DateTime, int>>();

            var montag = WeeksHelper.FirstDateOfWeek(DateTime.Now.Year, week);
            var dienstag = montag.AddDays(1);
            var mittwoch = montag.AddDays(2);
            var donnerstag = montag.AddDays(3);
            var freitag = montag.AddDays(4);
            var samstag = montag.AddDays(5);
            var sonntag = montag.AddDays(6);

            weekdays.Add(new Tuple<string, DateTime, int>(string.Format("Montag ({0})", montag.ToShortDateString()), montag, GetPlanId(montag)));
            weekdays.Add(new Tuple<string, DateTime, int>(string.Format("Dienstag ({0})", dienstag.ToShortDateString()), dienstag, GetPlanId(dienstag)));
            weekdays.Add(new Tuple<string, DateTime, int>(string.Format("Mittwoch ({0})", mittwoch.ToShortDateString()), mittwoch, GetPlanId(mittwoch)));
            weekdays.Add(new Tuple<string, DateTime, int>(string.Format("Donnerstag ({0})", donnerstag.ToShortDateString()), donnerstag, GetPlanId(donnerstag)));
            weekdays.Add(new Tuple<string, DateTime, int>(string.Format("Freitag ({0})", freitag.ToShortDateString()), freitag, GetPlanId(freitag)));
            weekdays.Add(new Tuple<string, DateTime, int>(string.Format("Samstag ({0})", samstag.ToShortDateString()), samstag, GetPlanId(samstag)));
            weekdays.Add(new Tuple<string, DateTime, int>(string.Format("Sonntag ({0})", sonntag.ToShortDateString()), sonntag, GetPlanId(sonntag)));

            Weekdays = new List<Tuple<string, DateTime, int>>(weekdays);
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
            LoadWeekdays(week);
            foreach (var day in Weekdays)
            {
                var firstDatum = FitnessDataService.Instance.TageService.Select().Where(x => x.Datum == day.Item2);
                if (firstDatum.Any())
                {
                    var tag = FitnessDataService.Instance.PlanService.Select().First(x => x.DatumId == firstDatum.First().DatumId);
                    var datum = FitnessDataService.Instance.TageService.Select().Where(x => x.Datum == day.Item2);
                    if (datum.Any())
                        Wochenplan.Add(tag ?? new Plan {BenutzerId = 1, DatumId = datum.First().DatumId});
                }
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