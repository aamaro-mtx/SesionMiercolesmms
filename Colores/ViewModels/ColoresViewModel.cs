using System.Windows.Media;
using Colores.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Colores.ViewModels
{
    public class ColoresViewModel : INotifyPropertyChanged
    {
        public ColoresViewModel()
        {
            MouseMoveCommand = new DelegateCommand(ExecuteMouseMoveCommand, s => true);
        }

        public DelegateCommand MouseMoveCommand { get; private set; }

        #region Propiedades
        private Brush _bgbrush;

        public Brush BackGroundBrush
        {
            get { return _bgbrush; }
            set
            {
                _bgbrush = value;
                OnPropertyChanged();
            }
        }

        private string _colorName;

        public string ColorName
        {
            get { return _colorName; }
            set
            {
                _colorName = value;
                OnPropertyChanged();
            }
        }

        void ExecuteMouseMoveCommand(object parameter)
        {
            if (MouseMoveCommand != null)
            {
                var bgtmp = parameter as SolidColorBrush;
                if (bgtmp != null)
                {
                    BackGroundBrush = bgtmp;
                    ColorName = bgtmp.ToString();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
