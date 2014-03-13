using System;
using System.Windows.Input;

namespace PryDelegateCommand.Commands
{

    public class DelegateCommand1 : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public DelegateCommand1(Action<object> execute, Predicate<object> canExecute = null)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute(parameter);
            }
        }

        public event EventHandler CanExecuteChanged;

        internal void RaiseCanExecuteChanged()
        {
            if (_canExecute != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

    }
}
