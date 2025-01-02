using DTO.Model;
using BusinessLogic.BLL;
using Microsoft.Maui.Controls;

namespace AdministrationApp
{
    public partial class AddMedarbejderPage : ContentPage
    {
        private readonly MedarbejderBLL _medarbejderBLL;

        public AddMedarbejderPage()
        {
            InitializeComponent();
            _medarbejderBLL = new MedarbejderBLL();
        }

        // Handle save button click
        private async void OnSaveClicked(object sender, EventArgs e)
        {
          

            var initialer = InitialerEntry.Text;
            var cpr = CprEntry.Text;
            var navn = NavnEntry.Text;

            if (string.IsNullOrEmpty(initialer) || string.IsNullOrEmpty(cpr) || string.IsNullOrEmpty(navn))
            {
                await DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            var newMedarbejder = new Medarbejder( initialer, cpr, navn);

            try
            {
                // Save the new medarbejder
                _medarbejderBLL.CreateMedarbejder(newMedarbejder);
                await DisplayAlert("Success", "Medarbejder added successfully.", "OK");

                // Navigate back to the previous page (e.g., the list of medarbejdere)
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}