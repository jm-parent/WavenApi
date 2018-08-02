using CodeHollow.FeedReader;
using Newtonsoft.Json;

namespace WavenApi.Models
{
	public class ArticleFeedModel : FeedItem
	{


		[JsonProperty("enteteUrl")]
		public string EnteteUrl { get; set; }

		public void InitByFeedItem(FeedItem item)
		{

			Author = item.Author;
			Categories = item.Categories;
			Content = string.Empty;  //item.Content; //Content pas nécessaire
			Description = item.Description;
			Id = item.Id;
			PublishingDate = item.PublishingDate;
			PublishingDateString = item.PublishingDateString;

		}

	}
}