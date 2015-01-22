using FitnessClient.ViewModels;
using FitnessClientLibrary.Common;

namespace FitnessClient.Views
{
    /// <summary>
    /// Interaktionslogik für UebungView.xaml
    /// </summary>
    public partial class UebungView : IView
    {
        private readonly UebungViewModel _viewModel;

        public UebungView()
        {
            InitializeComponent();
            _viewModel = new UebungViewModel();
            DataContext = _viewModel;
        }
    }
}
