using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using JobSearch.Models;
using JobSearch.Views;
using JobSearch.Services;
using System.Collections.Generic;

namespace JobSearch.ViewModels
{
    public class JobsViewModel : BaseViewModel
    {
        public IJobsDataStore DataStore;
        public ObservableCollection<TeamJob> Jobs { get; set; }
        public Command LoadJobsCommand { get; set; }

        public JobsViewModel()
        {
            DataStore = ((App)App.Current).JobsDataStore;

            Title = "Browse Jobs";
            Jobs = new ObservableCollection<TeamJob>();
            LoadJobsCommand = new Command(async () => await ExecuteLoadJobsCommand());
        }

        async Task ExecuteLoadJobsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Jobs.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Jobs.Add(DataStore.GetTeamJobFromJob(item));
                }
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
