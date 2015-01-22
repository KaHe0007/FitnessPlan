using System.ComponentModel;
using System.Windows.Input;

namespace FitnessLibrary.Command
{
	public interface IExtendedCommand : ICommand, INotifyPropertyChanged
	{
		//bool IsExecutable { get; }
	}
}