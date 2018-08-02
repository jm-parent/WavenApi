using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WavenApi.Responses;

namespace WavenApi.Services.NewFolder
{
	public interface IWavenService
	{
		Task<List<GetNewsResponse>> News(CancellationToken cancellationToken);

	}
}