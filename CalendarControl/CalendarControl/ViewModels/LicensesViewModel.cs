using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CalendarControl.ViewModels
{
    public class LicensesViewModel : BaseViewModel
    {
        public ObservableCollection<LicenseViewModel> Licenses { get; set; }
        public ICommand LicenseSelected => new Command(async (u) =>
        { 
            try
            {
                var uri = u as Uri;
                if(uri != null)
                {
                    await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                }
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        });
        public LicensesViewModel()
        {
            Licenses = new ObservableCollection<LicenseViewModel>();
            InitialiseLicenses();
        }

        private void InitialiseLicenses()
        {
            Licenses.Add(new LicenseViewModel("Xamarin.Forms", $"Xamarin SDK{Environment.NewLine}{Environment.NewLine}The MIT License(MIT){Environment.NewLine}{Environment.NewLine}Copyright(c).NET Foundation Contributors{Environment.NewLine}{Environment.NewLine}All rights reserved.{Environment.NewLine}{Environment.NewLine}Permission is hereby granted, free of charge, to any person obtaining a copy{Environment.NewLine}of this software and associated documentation files(the \"Software\"), to deal{Environment.NewLine}in the Software without restriction, including without limitation the rights{Environment.NewLine}to use, copy, modify, merge, publish, distribute, sublicense, and / or sell{Environment.NewLine}copies of the Software, and to permit persons to whom the Software is{Environment.NewLine}furnished to do so, subject to the following conditions:{Environment.NewLine}{Environment.NewLine}            The above copyright notice and this permission notice shall be included in all{Environment.NewLine}            copies or substantial portions of the Software.{Environment.NewLine}{Environment.NewLine}THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR{Environment.NewLine}IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,{Environment.NewLine}FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE{Environment.NewLine}AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER{Environment.NewLine}LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,{Environment.NewLine}OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE{Environment.NewLine}SOFTWARE."));
            Licenses.Add(new LicenseViewModel("Xamarin Essentials", $"Xamarin.Essentials{Environment.NewLine}{Environment.NewLine}The MIT License(MIT){Environment.NewLine}{Environment.NewLine}Copyright(c) Microsoft Corporation{Environment.NewLine}{Environment.NewLine}All rights reserved.{Environment.NewLine}{Environment.NewLine}Permission is hereby granted, free of charge, to any person obtaining a copy{Environment.NewLine}of this software and associated documentation files(the \"Software\"), to deal{Environment.NewLine}in the Software without restriction, including without limitation the rights{Environment.NewLine}to use, copy, modify, merge, publish, distribute, sublicense, and / or sell{Environment.NewLine}copies of the Software, and to permit persons to whom the Software is{Environment.NewLine}furnished to do so, subject to the following conditions:{Environment.NewLine}{Environment.NewLine}            The above copyright notice and this permission notice shall be included in all{Environment.NewLine}            copies or substantial portions of the Software.{Environment.NewLine}{Environment.NewLine}THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR{Environment.NewLine}IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,{Environment.NewLine}FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE{Environment.NewLine}AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER{Environment.NewLine}LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,{Environment.NewLine}OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE{Environment.NewLine}SOFTWARE."));
            Licenses.Add(new LicenseViewModel("Xamarin Community Toolkit", $"The MIT License (MIT){Environment.NewLine}Copyright(c).NET Foundation and Contributors{Environment.NewLine}All Rights Reserved{Environment.NewLine}{Environment.NewLine}Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files(the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and / or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:{Environment.NewLine}            The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.{Environment.NewLine}{Environment.NewLine}THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE."));
        }
    }
}
