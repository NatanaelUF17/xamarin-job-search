using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobSearch.Models;
using JobSearch.Views;
using JobSearch.ViewModels;

namespace JobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsPage : ContentPage
    {
        readonly TeamsViewModel viewModel;
        public TeamsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TeamsViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem is Team team)
            {
                await Navigation.PushAsync(new TeamDetailPage(new TeamDetailViewModel(team)));
            }

            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Teams.Count == 0)
                viewModel.LoadTeamsCommand.Execute(null);
        }
    }
}