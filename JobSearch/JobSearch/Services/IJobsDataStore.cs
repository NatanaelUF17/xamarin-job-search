using JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Services
{
    public interface IJobsDataStore : IDataStore<Job>
    {
        Task<Job> GetNewestJobAsync();
        List<TeamJob> GetTeamJobs();
        TeamJob GetTeamJobFromJob(Job job);
    }
}
