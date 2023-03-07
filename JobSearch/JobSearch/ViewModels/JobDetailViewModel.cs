using JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace JobSearch.ViewModels
{
    public class JobDetailViewModel : BaseViewModel
    {
        public TeamJob Job { get; set; }
        public ICommand SendEmailCommand { get; private set; }
        public ICommand PhoneCallCommand { get; private set; }

        public JobDetailViewModel(TeamJob job)
        {
            Title = job?.Title;
            Job = job;

            SendEmailCommand = new Command(async () => {
                try
                {
                    var message = new EmailMessage
                    {
                        Subject = "Interested in the " + job.Title + " position",
                        Body = "",
                        To = new List<string> { job.Team.EmailAddress },
                    };
                    await Email.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Email is not supported on this device
                }
                catch (Exception ex)
                {
                    // Some other exception occurred
                }
            });

            PhoneCallCommand = new Command(() =>
            {
                try
                {
                    PhoneDialer.Open(job.Team.PhoneNumber);
                }
                catch (ArgumentNullException ex)
                {
                    // Number was null or white space
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Phone Dialer is not supported on this device.
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            });
        }
    }
}
