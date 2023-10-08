using kursach.Modules;
using MaterialDesignColors;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;

namespace kursach.Converter
{
    public class SwatchToColorItemAdapterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Swatch swatch && swatch.PrimaryHues.Any())
            {
                var primaryHue = swatch.PrimaryHues.First();
                return new XceedColorItemAdapter(primaryHue.Color, swatch.Name);
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
