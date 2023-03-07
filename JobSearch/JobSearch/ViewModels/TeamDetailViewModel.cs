using JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobSearch.ViewModels
{
    public class TeamDetailViewModel : BaseViewModel
    {
        public Team Team { get; set; }
        public ICommand SendEmailCommand { get; private set; }
        public ICommand PhoneCallCommand { get; private set; }

        public TeamDetailViewModel(Team team = null)
        {
            Title = team?.Name;
            Team = team;

            SendEmailCommand = new Command(async () => {
                try
                {
                    var message = new EmailMessage
                    {
                        Subject = "Interested in new opportunities",
                        Body = "",
                        To = new List<string> { Team.EmailAddress },
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
                    PhoneDialer.Open(Team.PhoneNumber);
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
