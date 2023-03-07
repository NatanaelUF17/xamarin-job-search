using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobSearch.Services;
using JobSearch.Views;

namespace JobSearch
{
    public partial class App : Application
    {
        ITeamsDataStore _TeamsDataStore;
        private ITeamsDataStore GetTeamsDataStore()
        {
            if (_TeamsDataStore == null)
                _TeamsDataStore = new TeamsDataStore();
            return _TeamsDataStore;
        }
        public ITeamsDataStore TeamsDataStore => GetTeamsDataStore();

        IJobsDataStore _JobsDataStore;
        private IJobsDataStore GetJobsDataStore()
        {
            if (_JobsDataStore == null)
            _JobsDataStore = new JobsDataStore(TeamsDataStore.GetItemsAsync(true).Result);
            return _JobsDataStore;
        }
        public IJobsDataStore JobsDataStore => GetJobsDataStore();

        public App ()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        public static Color LookupColor(string key)
        {
            try
            {
                Application.Current.Resources.TryGetValue(key, out var newColor);
                return (Color)newColor;
            }
            catch
            {
                return Color.White;
            }
        }
    }
}

