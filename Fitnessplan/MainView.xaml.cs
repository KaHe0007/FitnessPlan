using System;
using System.Collections.Generic;
using Fitnessplan.Common;
using Fitnessplan.View;
using Fitnessplan.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Standardseite" ist unter http://go.microsoft.com/fwlink/?LinkId=234237 dokumentiert.

namespace Fitnessplan
{
    /// <summary>
    /// Eine Standardseite mit Eigenschaften, die die meisten Anwendungen aufweisen.
    /// </summary>
    public sealed partial class MainView : LayoutAwarePage
    {
        private readonly MainViewModel _viewModel;
        
        public MainView()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// Füllt die Seite mit Inhalt auf, der bei der Navigation übergeben wird. Gespeicherte Zustände werden ebenfalls
        /// bereitgestellt, wenn eine Seite aus einer vorherigen Sitzung neu erstellt wird.
        /// </summary>
        /// <param name="navigationParameter">Der Parameterwert, der an
        /// <see cref="Frame.Navigate(Type, Object)"/> übergeben wurde, als diese Seite ursprünglich angefordert wurde.
        /// </param>
        /// <param name="pageState">Ein Wörterbuch des Zustands, der von dieser Seite während einer früheren Sitzung
        /// beibehalten wurde. Beim ersten Aufrufen einer Seite ist dieser Wert NULL.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Behält den dieser Seite zugeordneten Zustand bei, wenn die Anwendung angehalten oder
        /// die Seite im Navigationscache verworfen wird. Die Werte müssen den Serialisierungsanforderungen
        /// von <see cref="SuspensionManager.SessionState"/> entsprechen.
        /// </summary>
        /// <param name="pageState">Ein leeres Wörterbuch, das mit dem serialisierbaren Zustand aufgefüllt wird.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void ButtonTodayOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TodayView));
        }
        
        private void ButtonTomorrowOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TodayView), 1);
        }
        
        private void ButtonUebungOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UebungView));
        }
        
        private void ButtonPlanOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlanView));
        }
    }
}
