using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using USDA.Models;
namespace USDA
{
    public partial class TimeAttendanceEntryPage : ContentPage
    {
        public TimeAttendanceEntryPage()
        {
            InitializeComponent();
        }

        async void CloseDay_Clicked(object sender, EventArgs e)
        {
            var timeEntry = (TimeAttendance)BindingContext;
            timeEntry.idUser = 1;
            await App.Database.SaveTimeAttendanceAsync(timeEntry);
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var timeEntry = (TimeAttendance)BindingContext;
            timeEntry.idUser = 1;
            await App.Database.DeleteNoteAsync(timeEntry);
            await Navigation.PopAsync();
        }

        async void TimePicker_timeChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                var timeEntry = (TimeAttendance)BindingContext;
                var totalHours = timeEntry.EndTime - timeEntry.StartTime;
                timeEntry.TotalHours = totalHours.Hours + (totalHours.Minutes / 15) * 0.25;
               
            }
        }
    }
}
