using System;
namespace JobSearch.Helpers
{
	public static class Helper
	{
		public static string GetRandomGUID()
		{
            string guidResult = Guid.NewGuid().ToString();

			guidResult = guidResult.Replace("-", string.Empty).ToUpper();

			return guidResult;
        }
	}
}

