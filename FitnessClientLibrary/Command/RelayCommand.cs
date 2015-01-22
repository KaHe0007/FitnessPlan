using System;
using System.Windows.Input;

namespace FitnessClientLibrary.Command
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #region Constructors

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
