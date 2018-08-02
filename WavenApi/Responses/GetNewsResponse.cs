using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WavenApi.Responses
{
	public class GetNewsResponse
	{
		[JsonProperty("enteteUrl")]
		public string EnteteUrl { get; set; }

		[JsonProperty("Title")]
		public string Title { get; set; }

		[JsonProperty("Link")]
		public string Link { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("PublishingDateString")]
		public string PublishingDateString { get; set; }

		[JsonProperty("PublishingDate")]
		public string PublishingDate { get; set; }

		[JsonProperty("Author")]
		public string Author { get; set; }

		[JsonProperty("Id")]
		public string Id { get; set; }

		[JsonProperty("Categories")]
		public List<string> Categories { get; set; }

		[JsonProperty("Content")]
		public string Content { get; set; }

		[JsonProperty("SpecificItem")]
		public object SpecificItem { get; set; }

		public static List<GetNewsResponse> FromJson(string json) =>
			JsonConvert.DeserializeObject<List<GetNewsResponse>>(json, Converter.Settings);

		public static string ToJson(List<GetNewsResponse> self) => JsonConvert.SerializeObject(self, Converter.Settings);

		internal static class Converter
		{
			public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
			{
				MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
				DateParseHandling = DateParseHandling.None,
				Converters =
				{
					new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
				},
			};
		}
	}
}