using System;
using JobSearch.Helpers;

namespace JobSearch.Models
{
	public class Team
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string ContactName { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string ImageUrl { get; set; }
		public string BackgroundColor { get; set; }
		public string LabelColor { get; set; }
		public string TextColor { get; set; }

		public Team()
		{
			Id = Helper.GetRandomGUID();
			TextColor = "#000000";
			LabelColor = "#0010EF";
		}
	}
}

