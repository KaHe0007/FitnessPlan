using FitnessClient.ViewModels;
using FitnessClientLibrary.Common;

namespace FitnessClient.Views
{
    /// <summary>
    /// Interaktionslogik für TrainingView.xaml
    /// </summary>
    public partial class TrainingView : IView
    {
        private readonly TrainingViewModel _viewModel;

        public TrainingView()
        {
            InitializeComponent();
            _viewModel = new TrainingViewModel();
            DataContext = _viewModel;
        }
    }
}
