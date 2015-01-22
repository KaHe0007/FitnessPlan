using System.ComponentModel;
using System.Windows.Input;

namespace FitnessClientLibrary.Command
{
	public interface IExtendedCommand : ICommand, INotifyPropertyChanged
	{
		//bool IsExecutable { get; }
	}
}