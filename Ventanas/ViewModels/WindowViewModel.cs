using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ventanas.Commands;

namespace Ventanas.ViewModels
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        public WindowViewModel()
        {
            AddTwoNumbersCommand = new DelegateCommand(ExecuteAddTwoNumbersCommand, CanExecuteAddTwoNumbersCommand);
            ShowWindowCommand = new DelegateCommand(ExecuteShowWindowCommand, (s) => true);
        }

        public DelegateCommand ShowWindowCommand { get; private set; }
        public DelegateCommand AddTwoNumbersCommand { get; private set; }

        public EventHandler CommandShowWindowExecuted;
        public EventHandler AddTwoNumbersCommandExecuted;

        void ExecuteAddTwoNumbersCommand(object paramter)
        {
            Result = Number1 + Number2;
        }

        bool CanExecuteAddTwoNumbersCommand(object parameter)
        {
            return Number1 != 0 && Number2 != 0;
        }


        void ExecuteShowWindowCommand(object parameter)
        {
            if (CommandShowWindowExecuted != null)
            {
                CommandShowWindowExecuted(this, EventArgs.Empty);
            }
        }

        #region Propiedades
        private int _number1;

        public int Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                if (value != _number1)
                {
                    OnPropertyChanged();
                }
                ShowWindowCommand.RaiseCanExecuteChanged();
                AddTwoNumbersCommand.RaiseCanExecuteChanged();
            }
        }

        private int _number2;

        public int Number2
        {
            get { return _number2; }
            set
            {
                _number2 = value;
                if (value != _number2)
                {
                    OnPropertyChanged();
                }
                ShowWindowCommand.RaiseCanExecuteChanged();
                AddTwoNumbersCommand.RaiseCanExecuteChanged();
            }
        }

        private int _result;

        public int Result
        {
            get { return _result; }
            set
            {
                _result = value;
                //if (value != _result)
                //{
                OnPropertyChanged();
                //}
            }
        }
        #endregion


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
