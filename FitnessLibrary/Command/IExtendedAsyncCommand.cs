using System.Threading.Tasks;

namespace FitnessLibrary.Command
{
	public interface IExtendedAsyncCommand : IExtendedCommand
	{
		Task ExecuteAsync(object parameter);
	}
}