using System;
using System.Collections.Generic;
using JobSearch.ViewModels;
using JobSearch.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobSearch
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("teamdetail", typeof(TeamDetailPage));
            Routing.RegisterRoute("jobdetail", typeof(JobDetailPage));
        }

        private void RateApp_Click(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            DisplayAlert("Rate!", "You selected the Rate This App menu item.", "Ok");
        }

        private void OpenUrl(string url)
        {
            Current.FlyoutIsPresented = false;
            Launcher.OpenAsync(url);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            OpenUrl("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/");
        }

        private void Tos_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.pluralsight.com/terms");
        }

        private void Privacy_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.pluralsight.com/privacy");
        }
    }
}

