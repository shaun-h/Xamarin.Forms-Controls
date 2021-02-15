using System;
using System.Globalization;
using Xamarin.Forms;

namespace CalendarControl.Converters
{
    public class CalendarItemStyleConverter : IValueConverter
    {
        public Style DayStyle { get; set; }
        public Style HeaderStyle { get; set; }
        public Style TodayStyle { get; set; }
        public Style SelectedStyle { get; set; }
        public Style EmptyStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value as string;

            if (type == null) throw new InvalidOperationException();

            if (EmptyStyle != null && type == "empty") return EmptyStyle;
            if (HeaderStyle != null && type == "header") return HeaderStyle;
            if (SelectedStyle != null && type == "selected") return SelectedStyle;
            if (TodayStyle != null && type == "today") return TodayStyle;
            if (DayStyle != null) return DayStyle;

            throw new InvalidOperationException("Item style is required");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
