using DTO.Model;
using BusinessLogic.BLL;
using Microsoft.Maui.Controls;

namespace AdministrationApp
{
    public partial class AddAfdelingPage : ContentPage
    {
   

        public AddAfdelingPage()
        {
            InitializeComponent();
      
        }

        // Handle save button click
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var navn = AfdelingNavnEntry.Text;

            if (string.IsNullOrEmpty(navn))
            {
                await DisplayAlert("Error", "Please enter valid Afdeling Nr and Navn", "OK");
                return;
            }

            var newAfdeling = new AfdelingsInfo(navn);

            try
            {
                // Save the new afdeling
                AfdelingBLL.CreateAfdeling(newAfdeling);
                await DisplayAlert("Success", "Afdeling added successfully.", "OK");

                // Navigate back to the previous page (e.g., the list of afdelinger)
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}