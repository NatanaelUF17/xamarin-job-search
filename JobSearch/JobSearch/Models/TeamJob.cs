using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearch.Models
{
    public class TeamJob : Job
    {
        public Team Team { get; set; }

        public string BackgroundColor
        {
            get
            {
                return Team?.BackgroundColor;
            }
        }

        public TeamJob(Team team) : base()
        {
            Team = team;
        }

        public TeamJob(Job job, Team team) : base()
        {
            Id = job.Id;
            Description = job.Description;
            Requirements = job.Requirements;
            Title = job.Title;
            TeamId = job.TeamId;
            Team = team;
            Tags = job.Tags.GetRange(0, job.Tags.Count);
        }
    }
}
