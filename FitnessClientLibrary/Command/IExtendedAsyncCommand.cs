using System.Threading.Tasks;

namespace FitnessClientLibrary.Command
{
	public interface IExtendedAsyncCommand : IExtendedCommand
	{
		Task ExecuteAsync(object parameter);
	}
}