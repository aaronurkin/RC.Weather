using RC.Weather.ThirdParty.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services
{
	public interface IThirdPartyCityService
	{
		Task<List<ThirdPartyCityApiResponse>> SearchAsync(string term);
	}
}
