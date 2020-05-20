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
	public partial class ProposalEntryPage : ContentPage
	{
		public ProposalEntryPage ()
		{
			InitializeComponent ();
		}

        async void Save_Clicked(object sender, EventArgs e)
        {
            var proposalEntry = (Proposal)BindingContext;
            proposalEntry.LastUpdatedBy = "TestUser";
            await App.Database.SaveProposalAync(proposalEntry);
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var proposalEntry = (Proposal)BindingContext;
            await App.Database.DeleteProposalAsync(proposalEntry);
            await Navigation.PopAsync();
        }

        async void Status_SelectedIndexChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (statusPicker.SelectedItem.Equals("Submitted"))
            {
                submittedDateDatePicker.IsVisible = true;
                submittedDateLabel.IsVisible = true;
            }
            else
            {
                submittedDateDatePicker.IsVisible = false;
                submittedDateLabel.IsVisible = false;
            }



        }
    }
}