using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Front.Core.Util;

public class OnlyFileName : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not string s ? null : Path.GetFileNameWithoutExtension(s);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}