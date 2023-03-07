using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using JobSearch.Models;

namespace JobSearch.Services
{
	public class JobSearchHandler : SearchHandler
	{
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue)) ItemsSource = null;

            var jobsDataStore = ((App)Application.Current).JobsDataStore;

            ItemsSource = jobsDataStore.GetTeamJobs()
                .Where(j => j.Tags.Contains(newValue, StringComparer.OrdinalIgnoreCase))
                .ToList<TeamJob>();
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            var navigationUrl = $"//jobs/jobdetail?Id={((TeamJob)item).Id}";

            await Task.Delay(500);

            await Shell.Current.GoToAsync(navigationUrl, true);
        }
    }
}

