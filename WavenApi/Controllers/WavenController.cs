using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using WavenApi.Models;
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

		#region TableStorage

		[HttpGet]
		[Route("GetSingle")]
		public ActionResult GetSingle()
		{
			CloudStorageAccount storageAccount = new CloudStorageAccount(
				new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
					"storagewavenapi",
					"QujHppFNj4lf8NEjn+k/mU9AaGR/78BmPhow2Ml+SuFL6I37An2KpNDz8LLdJtxjSVyZw98qehQt5fGyxQlc3Q=="), true);
			CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
			CloudTable table = tableClient.GetTableReference("Heroes");

			// Define the additional columns we want, and pass them into Retrieve
			var columns = new List<string>() { "Name"};
			var retrieve = TableOperation.Retrieve<HeroEntity>("Hero","1", columns);
			var returnedObject = table.ExecuteAsync(retrieve).Result.Result;

// The cast succeeds
			var myThing = (HeroEntity)returnedObject;


			return Ok(myThing);
		}

		#endregion
	}
}