using FitnessClient.ViewModels;
using FitnessClientLibrary.Common;

namespace FitnessClient.Views
{
    /// <summary>
    /// Interaktionslogik für PlanView.xaml
    /// </summary>
    public partial class PlanView : IView
    {
        private readonly PlanungViewModel _viewModel;

        public PlanView()
        {
            InitializeComponent();
            _viewModel = new PlanungViewModel();
            DataContext = _viewModel;
        }
    }
}
