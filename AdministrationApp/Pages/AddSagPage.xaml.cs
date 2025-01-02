using DTO.Model;
using BusinessLogic.BLL;
using Microsoft.Maui.Controls;

namespace AdministrationApp
{
    public partial class AddSagPage : ContentPage
    {
        private readonly SagBLL _sagBLL;
        private readonly AfdelingsInfo _selectedAfdeling;

        public AddSagPage(AfdelingsInfo selectedAfdeling)
        {
            InitializeComponent();
            _sagBLL = new SagBLL();
            _selectedAfdeling = selectedAfdeling;
            AfdelingLabel.Text = $"Afdeling: {_selectedAfdeling.Navn}";
        }

        // Handle save button click
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var overskrift = SagOverskriftEntry.Text;
            var beskrivelse = SagBeskrivelseEntry.Text;
            var afdelingNr = _selectedAfdeling.AfdelingNr;

            if (string.IsNullOrEmpty(overskrift) || string.IsNullOrEmpty(beskrivelse))
            {
                await DisplayAlert("Error", "Please enter valid Sag Overskrift and Beskrivelse", "OK");
                return;
            }
            
            var newSag = new SagsInfo(overskrift, beskrivelse, afdelingNr);

            try
            {
                // Save the new sag
                _sagBLL.CreateSag(newSag);
                await DisplayAlert("Success", "Sag added successfully.", "OK");

                // Navigate back to the previous page (e.g., the list of sager)
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}