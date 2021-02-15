using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace CalendarControl.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        //Backing fields
        private CalendarItemViewModel _selectedItem;
        private CalendarItemViewModel _previousSelectedItem;
        private CalendarItemViewModel _selectedDate;
        private DateTime _calendarMonth;

        //Property to show the current month
        public string MonthText => _calendarMonth.ToString("MMMM yyyy");

        //Commands used to change between months
        public ICommand PreviousMonth { get; }
        public ICommand NextMonth { get; }

        //The current datetime object for the month the control is showing
        public DateTime CalendarMonth
        {
            get => _calendarMonth;
            set
            {
                SetProperty(ref _calendarMonth, value);
                //As the month has been changed you need to tell the UI that the MonthText property has also changed
                OnPropertyChanged(nameof(MonthText));
                //Lets create all the items month selected
                CreateItemsForMonth(CalendarMonth);
            }
        }

        //The command to bind to for when the selected item is changed
        public ICommand SelectedItemChangedCommand { get; set; }

        //A property to show how you can use a date when it is selected. In this example this just shown in a label
        //but it be that you show a list of appointments on the selected date etc.
        public CalendarItemViewModel SelectedDate
        {
            get => _selectedDate;
            set
            {
                SetProperty(ref _selectedDate, value);
            }
        }

        //The property that is set by the view when a user selects in the calendar control
        public CalendarItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                //if the selects the same item just return (nothing to be done)
                if (_selectedItem == value) return;

                //if the item has the type or empty or header lets not actually do anything
                if (value.Type == "empty" || value.Type == "header") return;

                //If we get here it must be a date so set the selected date
                SelectedDate = value;

                if (_selectedItem != null)
                {
                    //if this is not the first time the user has selected something then lets set _previousSelectedItem before updating the backing field
                    _previousSelectedItem = _selectedItem;
                }

                SetProperty(ref _selectedItem, value);
            }
        }

        //This Collection is used to store all items in the calendar control
        public ObservableRangeCollection<CalendarItemViewModel> Items { get; set; }

        public CalendarViewModel()
        {
            SelectedItemChangedCommand = new Command(() => {
                ItemChangedCommand();
            });
            Items = new ObservableRangeCollection<CalendarItemViewModel>();

            //On initialistion lets set the calendar month to the current date
            CalendarMonth = DateTime.Now;

            //Setup the previous and next month commands by just adding or subtracting a month from the calendar month property
            PreviousMonth = new Command(() => { CalendarMonth = CalendarMonth.AddMonths(-1); CheckSelected(); });
            NextMonth = new Command(() => { CalendarMonth = CalendarMonth.AddMonths(1); CheckSelected(); });
        }

        //Method to create all items for the control
        public void CreateItemsForMonth(DateTime date)
        {
            //lets start by creating the header row
            var items = new List<CalendarItemViewModel>
            {
                new CalendarItemViewModel("S", "header"),
                new CalendarItemViewModel("M", "header"),
                new CalendarItemViewModel("T", "header"),
                new CalendarItemViewModel("W", "header"),
                new CalendarItemViewModel("T", "header"),
                new CalendarItemViewModel("F", "header"),
                new CalendarItemViewModel("S", "header")
            };

            //default to first of the month for the date past in
            var dateToCalc = new DateTime(date.Year, date.Month, 1);

            //This is done to add blank items for when the month does not start on a Sunday to the items align with the header
            if (dateToCalc.DayOfWeek != DayOfWeek.Sunday)
            {
                for (var i = 0; i < (int)dateToCalc.DayOfWeek; i++)
                {
                    items.Add(new CalendarItemViewModel());
                }
            }

            //This loop adds an item for every day of the current month selected
            var currentMonth = date.Month;
            while (dateToCalc.Month == currentMonth)
            {
                var day = new CalendarItemViewModel(dateToCalc);
                //if the date for the item it is creating then flag it as today so it can be styled differently
                if (day.Date.Date == DateTime.Now.Date) day.Type = "today";
                items.Add(day);
                dateToCalc = dateToCalc.AddDays(1);
            }

            //Replace Range is used so only one call to update the UI is called
            Items.ReplaceRange(items);
        }

        //When the item is changed then we need to update the previous items type to no longer be selected and the new Item type to to be selected
        public void ItemChangedCommand()
        {
            if (_previousSelectedItem != null)
            {
                var item = Items.FirstOrDefault(x => x == _previousSelectedItem);
                if (item != null)
                {
                    item.Type = DateTime.Now.Date == _previousSelectedItem.Date.Date ? "today" : "date";
                }
            }

            var selectedItem = Items.FirstOrDefault(x => x == _selectedItem);
            if (selectedItem != null)
            {
                selectedItem.Type = "selected";
            }
        }

        //On changing the month lets check if the current month contains the selected date so it can be set up correctly
        private void CheckSelected()
        {
            if (SelectedDate != null)
            {
                var d = Items.FirstOrDefault(x => x.Date == SelectedDate.Date);
                if (d != null)
                {
                    SelectedItem = d;
                }
            }
        }
    }
}
