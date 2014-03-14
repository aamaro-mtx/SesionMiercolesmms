using System;
using System.Drawing;
using System.Windows.Data;

namespace Colores.Converters
{
    public class HexToColorConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var tmp = value as string;
            return !string.IsNullOrEmpty(tmp) ? ColorTranslator.FromHtml(tmp).Name : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var tmp = value as string;
            return !string.IsNullOrEmpty(tmp) ? ColorTranslator.FromHtml(tmp).Name : string.Empty;
        }

        #endregion
    }
}
