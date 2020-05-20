using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProposalsManager.Data;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProposalsManager
{
    public partial class App : Application
    {
        static ProposalDatabase database;

        public static ProposalDatabase Database
        {
            get
            {
                if (database == null) database = new ProposalDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proposal.db3"));
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProposalList());
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
