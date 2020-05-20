using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using USDA.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace USDA
{
    public partial class App : Application
    {
        static UsdaDatabase database;

        public static UsdaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UsdaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usda.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TimeAttendancePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
