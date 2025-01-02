using DTO.Model;
using BusinessLogic.BLL;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;

namespace AdministrationApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MedarbejderBLL _medarbejderBLL;
        private readonly SagBLL _sagBLL;
        private AfdelingsInfo _selectedAfdeling;

        public MainPage()
        {
            InitializeComponent();
            _medarbejderBLL = new MedarbejderBLL();
            _sagBLL = new SagBLL();
        }

        // Load all Medarbejdere into the ListView
        private void LoadMedarbejdere()
        {
            var medarbejdere = _medarbejderBLL.FetchMedarbejdere();
            /*
            foreach (var medarbejder in medarbejdere)
            {
                medarbejder.TotalHours = _medarbejderBLL.getTotalHoursWorked(medarbejder.MedarbejderId);
            }
            */
            
            MedarbejderListView.ItemsSource = medarbejdere;
        }

        // Load all Afdelinger into the ListView
        private void LoadAfdelinger()
        {
            var afdelinger = AfdelingBLL.FetchAfdelinger();
            AfdelingListView.ItemsSource = afdelinger;
        }

        // Load Sager for the selected Afdeling
        private void LoadSager(int afdelingNr)
        {
            var sager = AfdelingBLL.FetchSager(afdelingNr);
            SagListView.ItemsSource = sager;
        }

        // Add Medarbejder Button clicked
        private async void OnAddMedarbejderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMedarbejderPage());
        }

        // Delete Medarbejder Button clicked
        private async void OnDeleteMedarbejderClicked(object sender, EventArgs e)
        {
            var selectedMedarbejder = (Medarbejder)MedarbejderListView.SelectedItem;
            if (selectedMedarbejder != null)
            {
                _medarbejderBLL.DeleteMedarbejder(selectedMedarbejder.MedarbejderId);
                LoadMedarbejdere();
            }
        }

        // Add Afdeling Button clicked
        private async void OnAddAfdelingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAfdelingPage());
        }

        // Delete Afdeling Button clicked
        private async void OnDeleteAfdelingClicked(object sender, EventArgs e)
        {
            var selectedAfdeling = (AfdelingsInfo)AfdelingListView.SelectedItem;
            if (selectedAfdeling != null)
            {
                AfdelingBLL.DeleteAfdeling(selectedAfdeling.AfdelingNr);
                LoadAfdelinger();
            }
        }

        // Add Sag Button clicked
        private async void OnAddSagClicked(object sender, EventArgs e)
        {
            if (_selectedAfdeling != null)
            {
                await Navigation.PushAsync(new AddSagPage(_selectedAfdeling));
            }
            else
            {
                await DisplayAlert("Error", "Please select an Afdeling first.", "OK");
            }
        }

        // Delete Sag Button clicked
        private async void OnDeleteSagClicked(object sender, EventArgs e)
        {
            var selectedSag = (SagsInfo)SagListView.SelectedItem;
            if (selectedSag != null)
            {
                _sagBLL.DeleteSag(selectedSag.SagsId);
                var selectedAfdeling = (AfdelingsInfo)AfdelingListView.SelectedItem;
                if (selectedAfdeling != null)
                {
                    LoadSager(selectedAfdeling.AfdelingNr);
                }
            }
        }

        // Page loaded - call the method to load data
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadMedarbejdere();
            LoadAfdelinger();
        }

        private async void OnMedarbejderSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMedarbejder = (Medarbejder)e.SelectedItem;
            if (selectedMedarbejder != null)
            {
                await DisplayAlert("Medarbejder Selected", $"You selected {selectedMedarbejder.Navn}", "OK");
            }
            ((ListView)sender).SelectedItem = null;
        }

        private void OnAfdelingSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedAfdeling = e.SelectedItem as AfdelingsInfo;
            _selectedAfdeling = selectedAfdeling;
            if (selectedAfdeling != null)
            {
                LoadSagerForAfdeling(selectedAfdeling.AfdelingNr);
            }
        }

        private void LoadSagerForAfdeling(int afdelingNr)
        {
            //ar sager = _sagBLL.FetchSager();
            var sager = AfdelingBLL.FetchSager(afdelingNr);
            
            SagListView.ItemsSource = sager;
        }

        private void OnToggleWeekToggled(object sender, ToggledEventArgs e)
        {
            // Implement logic to show/hide current week time registration
        }

        private void OnToggleMonthToggled(object sender, ToggledEventArgs e)
        {
            // Implement logic to show/hide current month time registration
        }
    }
}