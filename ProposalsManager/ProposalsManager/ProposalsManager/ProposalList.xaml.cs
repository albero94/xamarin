using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProposalsManager.Models;

namespace ProposalsManager
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProposalList : ContentPage
	{
		public ProposalList ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProposalsAsync();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProposalEntryPage
            {
                BindingContext = new Proposal()
            });
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            await Navigation.PushAsync(new ProposalEntryPage
            {
                BindingContext = e.SelectedItem as Proposal
            });
        }
    }
}