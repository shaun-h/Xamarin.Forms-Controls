using System;
using System.Collections.Generic;
using CalendarControl.ViewModels;
using Xamarin.Forms;

namespace CalendarControl.Views
{
    public partial class LicensesPage : ContentPage
    {
        public LicensesPage()
        {
            InitializeComponent();
            BindingContext = new LicensesViewModel();
        }
    }
}
