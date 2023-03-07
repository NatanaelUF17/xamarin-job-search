using JobSearch.Models;
using JobSearch.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JobSearch.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ITeamsDataStore DataStore => ((App)App.Current).TeamsDataStore;
        public IJobsDataStore JobsDataStore => ((App)App.Current).JobsDataStore;

        public Team NewestTeam { get; set; }
        public Job NewestJob { get; set; }

        public Command LoadDataCommand { get; set; }
        public Command OpenTeamCommand { get; }
        public Command OpenJobCommand { get; }

        public HomeViewModel()
        {
            Title = "Home";

            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());
            OpenTeamCommand = new Command(async () => await Shell.Current.GoToAsync($"//teams/teamdetail?Id={NewestTeam.Id}"));
            OpenJobCommand = new Command(async () => await Shell.Current.GoToAsync($"//jobs/jobdetail?Id={NewestJob.Id}"));
        }
        async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var NewestTeamTask = DataStore.GetNewestTeamAsync();
                var NewestJobTask = JobsDataStore.GetNewestJobAsync();

                await Task.WhenAll(NewestJobTask, NewestTeamTask);

                NewestTeam = NewestTeamTask.Result;
                NewestJob = NewestJobTask.Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
