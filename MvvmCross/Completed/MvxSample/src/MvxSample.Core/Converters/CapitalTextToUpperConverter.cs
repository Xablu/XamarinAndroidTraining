using System;
using System.Globalization;
using MvvmCross.Converters;

namespace MvxSample.Core.Converters
{
    public class CapitalTextToUpperConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().ToUpper();
        }
    }
}
