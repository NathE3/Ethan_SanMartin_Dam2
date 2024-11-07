using System.Globalization;
using System.Windows.Data;

namespace GestionArchivos.Service
{
    public class CarpetaOarchivo : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool esCarpeta)
            {
                return esCarpeta? "pack://application:,,,/Resources/iconoCarpeta.png" : "pack://application:,,,/Resources/iconoArchivo.png"; 
            }
            return null; 
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
