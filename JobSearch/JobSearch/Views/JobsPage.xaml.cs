using JobSearch.Models;
using JobSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobsPage : ContentPage
    {
        readonly JobsViewModel viewModel;
        public JobsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new JobsViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem is TeamJob job)
            {
                await Navigation.PushAsync(new JobDetailPage(new JobDetailViewModel(job)));
            }

            ItemsListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Jobs.Count == 0)
                viewModel.LoadJobsCommand.Execute(null);
        }
    }
}