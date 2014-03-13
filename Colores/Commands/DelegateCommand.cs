using System;
using System.Windows.Input;

namespace Colores.Commands
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;


        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_execute!=null)
            {
                _execute(parameter);
            }
        }

        internal void RaiseCanExecuteChanged()
        {
            if (_canExecute!=null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
