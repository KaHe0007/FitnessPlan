using FitnessClient.ViewModels;
using FitnessClientLibrary.Common;

namespace FitnessClient.Views
{
    /// <summary>
    /// Interaktionslogik für EinstellungenView.xaml
    /// </summary>
    public partial class EinstellungenView : IView
    {
        private readonly EinstellungenViewModel _viewModel;

        public EinstellungenView()
        {
            InitializeComponent();
            _viewModel = new EinstellungenViewModel();
            DataContext = _viewModel;
        }
    }
}
