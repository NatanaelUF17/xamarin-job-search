using JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Services
{
    public class TeamsDataStore : ITeamsDataStore
    {
        readonly List<Team> teams;
        public TeamsDataStore()
        {
            teams = GetTeams();
        }
        private List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>
            {
                new Team { Name = "North side", ContactName = "Kay Schemz", EmailAddress = "kschemz@example.com", Location = "123 Clearview Ln, North Side", PhoneNumber = "555-123-4444", ImageUrl = "northside.jpg", BackgroundColor = "#b5d5c6", LabelColor = "#014d37" },
                new Team { Name = "Downtown", ContactName = "Larry Schemz", EmailAddress = "lschemz@example.com", Location = "9108 Western Ave, Downtown", PhoneNumber = "555-123-5555", ImageUrl = "downtown.jpg", BackgroundColor = "#f1eed0", LabelColor = "#575213" },
                new Team { Name = "Lake side", ContactName = "B. Carlyle Seen", EmailAddress = "bseen@example.com", Location = "461 Lakeview Dr, Lake Side", PhoneNumber = "555-123-8100", ImageUrl = "lakeside.jpg", BackgroundColor = "#91b0ca", LabelColor = "#265e7d" }
            };

            return teams;
        }

        public async Task<Team> GetItemAsync(string id)
        {
            return await Task.FromResult(teams.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Team>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(teams);
        }

        public async Task<Team> GetNewestTeamAsync()
        {
            return await Task.FromResult(teams.LastOrDefault());
        }

    }
}
