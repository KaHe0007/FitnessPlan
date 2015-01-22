using System.Windows.Input;

namespace FitnessLibrary.Common
{
    public interface IMenuItem
    {
        string Title { get; set; }
        string Image { get; set; }
        ICommand Cmd { get; set; }
        IView View { get; set; }
    }

    public class MenuItem : IMenuItem
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICommand Cmd { get; set; }
        public IView View { get; set; }
    }
}