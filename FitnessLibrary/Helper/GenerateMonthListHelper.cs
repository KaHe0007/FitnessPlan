using System;
using System.Collections.Generic;

namespace FitnessLibrary.Helper
{
    public static class GenerateMonthListHelper
    {
        public static List<Tuple<int, string>> GenerateList() 
        {
            return new List<Tuple<int, string>> {
                new Tuple<int, string>(1, "Januar"), new Tuple<int, string>(2, "Februar"),
                new Tuple<int, string>(3, "März"), new Tuple<int, string>(4, "April"),
                new Tuple<int, string>(5, "Mai"), new Tuple<int, string>(6, "Juni"),
                new Tuple<int, string>(7, "Juli"), new Tuple<int, string>(8, "August"),
                new Tuple<int, string>(9, "September"), new Tuple<int, string>(10, "Oktober"),
                new Tuple<int, string>(11, "November"), new Tuple<int, string>(12, "Dezember")};
        }
    }
}
