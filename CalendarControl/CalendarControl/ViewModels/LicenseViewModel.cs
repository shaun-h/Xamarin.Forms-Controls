using System;
namespace CalendarControl.ViewModels
{
    public class LicenseViewModel : BaseViewModel
    {
        private string _title;
        private string _license;

        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public string License
        {
            get => _license;
            set
            {
                SetProperty(ref _license, value);
            }
        }

        public LicenseViewModel(string title, string license)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace", nameof(title));
            }

            Title = title;
            License = license;
        }
    }
}
