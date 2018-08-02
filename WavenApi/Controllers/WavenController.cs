using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WavenApi.Responses;
using WavenApi.Services.NewFolder;

namespace WavenApi.Controllers
{
	[Route("/API-Waven/v1.0/")]
	public class WavenController : Controller
	{
		private readonly IWavenService _wavenService;

		public WavenController(IWavenService wavenService)
		{
			_wavenService = wavenService;
		}

		[HttpGet]
		[Route("test")]
		public async Task<IActionResult> Test(CancellationToken cancellationToken)
		{
			return Ok("TEST OK");
		}


		[HttpGet]
		[Route("News")]
		public virtual async Task<List<GetNewsResponse>> News(CancellationToken cancellationToken)
		{
			var responseApi = await _wavenService.News(cancellationToken);
			return responseApi;
		}


	}
}