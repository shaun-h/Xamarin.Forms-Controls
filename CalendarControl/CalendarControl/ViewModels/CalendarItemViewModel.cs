using System;
namespace CalendarControl.ViewModels
{
    public class CalendarItemViewModel : BaseViewModel
    {
        private string _type;
        public DateTime Date { get; }
        public string Label { get; }
        public string Type
        {
            get => _type;
            set
            {
                SetProperty(ref _type, value);
            }
        }
        public CalendarItemViewModel(DateTime date)
        {
            Date = date.Date;
            Type = "date";
            Label = Date.Day.ToString();
        }
        public CalendarItemViewModel(string label = " ", string type = "empty")
        {
            Type = type;
            Label = label;
        }
    }
}
