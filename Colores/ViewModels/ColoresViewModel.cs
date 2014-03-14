using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Colores.ViewModels
{
    public class ColoresViewModel : INotifyPropertyChanged
    {
        public ColoresViewModel()
        {

        }

        #region Propiedades
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
