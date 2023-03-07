using JobSearch.Models;
using System.Threading.Tasks;

namespace JobSearch.Services
{
    public interface ITeamsDataStore : IDataStore<Team>
    {
        Task<Team> GetNewestTeamAsync();
    }
}
