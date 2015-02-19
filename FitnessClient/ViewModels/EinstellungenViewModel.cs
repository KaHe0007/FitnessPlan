using System;
using FitnessClient.DataService;
using FitnessClientLibrary.Command;

namespace FitnessClient.ViewModels
{
    public class EinstellungenViewModel
    {
        private RelayCommand _createDaysCommand;
        public RelayCommand CreateDaysCommand
        {
            get
            {
                return _createDaysCommand ?? (_createDaysCommand = new RelayCommand(CreateDays));
            }
        }

        public void CreateDays(object param)
        {
            var begin = new DateTime(DateTime.Now.Year, 1, 1);
            var end = new DateTime(DateTime.Now.Year, 12, 31);

            for (DateTime date = begin; date <= end; date = date.AddDays(1))
            {
                //TODO: Wochentag und Jahr
                FitnessDataService.Instance.TageService.Insert(new Tage {Datum = date});
            }
        }
    }
}
