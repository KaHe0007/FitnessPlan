using FitnessClient.ViewModels;
using FitnessClientLibrary.Common;

namespace FitnessClient.Views
{
    /// <summary>
    /// Interaktionslogik für ThemaView.xaml
    /// </summary>
    public partial class ThemaView : IView
    {
        private readonly ThemaViewModel _viewModel;

        public ThemaView()
        {
            InitializeComponent();
            _viewModel = new ThemaViewModel();
            DataContext = _viewModel;
        }
    }
}
