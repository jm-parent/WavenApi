using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using HtmlAgilityPack;
using Newtonsoft.Json;
using WavenApi.Models;
using WavenApi.Responses;
using WavenApi.Services.NewFolder;

namespace WavenApi.Services
{
	public class WavenService : IWavenService
	{
		public async Task<List<GetNewsResponse>> News(CancellationToken cancellationToken)
		{
			var feed = FeedReader.Read("https://waven-game.com/feed/");


			var articleImagesUrl = new List<string>();
			List<FeedItem> articles = new List<FeedItem>();

			foreach (var item in feed.Items)
			{
				ArticleFeedModel article = new ArticleFeedModel();
				article.InitByFeedItem(item);

				string html2;
				using (WebClient client = new WebClient())
				{
					html2 = client.DownloadString(item.Link);
				}
				HtmlDocument doc = new HtmlDocument();
				doc.LoadHtml(html2);
				foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img"))
				{
					var articleImageEnteteUrl = img.GetAttributeValue("src", null);
					if (!articleImageEnteteUrl.Contains("logo"))
					{

						article.EnteteUrl = articleImageEnteteUrl;
						articles.Add(article);
						break;
					}
				}

			}
			var json = JsonConvert.SerializeObject(articles);
			var newsResponse = GetNewsResponse.FromJson(json);

			return newsResponse;
		}


	}
}