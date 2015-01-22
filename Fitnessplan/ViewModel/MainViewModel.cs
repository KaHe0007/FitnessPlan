using System;
using Fitnessplan.DataModel;

namespace Fitnessplan.ViewModel
{
    public class MainViewModel : MainDataModel
    {
        public MainViewModel()
        {
            var now = DateTime.Now;
            Today = now.Day.ToString();
            Tomorrow = now.AddDays(1).Day.ToString();
        }
    }
}
