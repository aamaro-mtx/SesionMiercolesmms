using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PryDelegateCommand.Commands;

namespace PryDelegateCommand.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            //Se le pasa como parametro el metodo que realiza la accion y si se puede o no ejecuta.
            ComandoConvertirAMayusculas = new DelegateCommand1(StringToUpper(), t => t != null && !String.IsNullOrWhiteSpace(t.ToString()));
            ComandoCerrarAplicacion = new DelegateCommand1(ExecuteComandoCerrarAplicacion, CanExecuteComandoCerrarAplicacion);
        }

        private Action<object> StringToUpper()
        {
            return t => Texto = t.ToString().ToUpper();
        }

        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set
            {
                _texto = value;
                if (PropertyChanged != null)
                {
                    OnPropertyChanged();
                }
                ComandoCerrarAplicacion.RaiseCanExecuteChanged();
                ComandoConvertirAMayusculas.RaiseCanExecuteChanged();
            }
        }

        #region Interfaz INotifyPropertyChanged

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

        public DelegateCommand1 ComandoConvertirAMayusculas { get; private set; }
        public DelegateCommand1 ComandoCerrarAplicacion { get; private set; }

        public event EventHandler ComandoCerrarAplicacionEjecutado;

        bool CanExecuteComandoCerrarAplicacion(object parameter)
        {
            return Texto != null && Texto.Contains("FIN");
        }

        void ExecuteComandoCerrarAplicacion(object parameter)
        {
            if (ComandoCerrarAplicacionEjecutado != null)
            {
                ComandoCerrarAplicacionEjecutado(this, EventArgs.Empty);
            }
        }
    }
}
