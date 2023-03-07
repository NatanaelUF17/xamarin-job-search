using JobSearch.Helpers;
using System.Collections.Generic;

namespace JobSearch.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }

        public List<string> Tags { get; set; }

        public string FormattedTags
        {
            get
            {
                if (Tags == null)
                {
                    return string.Empty;
                }
                return string.Join(", ", Tags);
            }
        }

        public Job()
        {
            Id = Helper.GetRandomGUID();
        }
    }
}
