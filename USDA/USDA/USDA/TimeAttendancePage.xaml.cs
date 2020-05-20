using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using USDA.Models;

namespace USDA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimeAttendancePage : ContentPage
	{
		public TimeAttendancePage ()
		{
			InitializeComponent ();
		}


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetTimeAttendancesAsync();
        }

        async void OnTimeEntryAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimeAttendanceEntryPage
            {
                BindingContext = new TimeAttendance()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TimeAttendanceEntryPage
            {
                BindingContext = e.SelectedItem as TimeAttendance,
            });
        }

    }
}