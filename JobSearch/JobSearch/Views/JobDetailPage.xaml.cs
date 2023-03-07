using System;
using JobSearch.Models;
using JobSearch.Services;
using JobSearch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("JobId", "Id")]
    public partial class JobDetailPage : ContentPage
    {
        JobDetailViewModel viewModel;

        public string JobId
        {
            set
            {
                ITeamsDataStore teamsDataStore = ((App)Application.Current).TeamsDataStore;
                IJobsDataStore jobsDataStore = ((App)Application.Current).JobsDataStore;

                var job = jobsDataStore.GetItemAsync(Uri.UnescapeDataString(value)).Result;
                var team = teamsDataStore.GetItemAsync(job.TeamId).Result;
                var teamJob = new TeamJob(job, team);

                BindingContext = viewModel = new JobDetailViewModel(teamJob);
            }
        }

        public JobDetailPage()
        {
            InitializeComponent();
        }

        public JobDetailPage(JobDetailViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }

    }
}