using System;
using JobSearch.Services;
using JobSearch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("TeamId", "Id")]
    public partial class TeamDetailPage : ContentPage
    {
        TeamDetailViewModel viewModel;

        public string TeamId
        {
            set
            {
                ITeamsDataStore teamsDataStore = ((App)Application.Current).TeamsDataStore;
                var team = teamsDataStore.GetItemAsync(Uri.UnescapeDataString(value)).Result;

                BindingContext = viewModel = new TeamDetailViewModel(team);
            }
        }

        public TeamDetailPage()
        {
            InitializeComponent();
        }

        // define first
        public TeamDetailPage(TeamDetailViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }
    }
}