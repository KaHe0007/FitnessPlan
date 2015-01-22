using FitnessClient.ViewModels;
using FitnessClientLibrary.Common;

namespace FitnessClient.Views
{
    /// <summary>
    /// Interaktionslogik für VerzeichnisView.xaml
    /// </summary>
    public partial class VerzeichnisView : IView
    {
        private readonly VerzeichnisViewModel _viewModel;

        public VerzeichnisView()
        {
            InitializeComponent();
            _viewModel = new VerzeichnisViewModel();
            DataContext = _viewModel;
        }
    }
}
