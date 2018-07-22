using Newtonsoft.Json;
using Rdocs.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rdocs.Repositories
{
	public class DocumentaryRepository : IDocumentaryRepository
    {
		/// <summary>
		/// base reddit url
		/// </summary>
		private static readonly string baseUrl = "https://www.reddit.com/r/Documentaries/";

		/// <summary>
		/// Gets initial reponse for posts marked as hot
		/// </summary>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetHotDocumentaries()
		{
			var request = await GetStringAsync(baseUrl + "hot.json");
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}

		/// <summary>
		/// Gets next response for posts marked as hot
		/// </summary>
		/// <param name="after">id of post to search after</param>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetNextHotDocumentaries(string after)
		{
			var request = await GetStringAsync(baseUrl + "hot.json?after=" + after);
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}

		/// <summary>
		/// Gets initial reponse for posts marked as rising 
		/// </summary>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetRisingDocumentaries()
		{
			var request = await GetStringAsync(baseUrl + "rising.json");
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}

		/// <summary>
		/// Gets next response for posts marked as rising
		/// </summary>
		/// <param name="after">id of post to search after</param>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetNextRisingDocumentaries(string after)
		{
			var request = await GetStringAsync(baseUrl + "rising.json?after=" + after);
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}

		/// <summary>
		/// Gets initial reponse for posts marked as top 
		/// </summary>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetTopDocumentaries()
		{
			var request = await GetStringAsync(baseUrl + "top.json?sort=top&t=all");
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}

		/// <summary>
		/// Gets next response for posts marked as top
		/// </summary>
		/// <param name="after">id of post to search after</param>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetNextTopDocumentaries(string after)
		{
			var request = await GetStringAsync(baseUrl + "top.json?sort=top&t=all&after=" + after);
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}

		/// <summary>
		/// Gets initial reponse for posts from search
		/// </summary>
		/// <param name="search">search query</param>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetSearchResults(string search)
		{
			var request = await GetStringAsync(baseUrl + "search.json?q=" + search + "&restrict_sr=on&sort=relevance&t=all");
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}

		/// <summary>
		/// Gets next reponse for posts from search
		/// </summary>
		/// <param name="after">id of post to search after</param>
		/// <param name="search">search query</param>
		/// <returns></returns>
		public async Task<DocumentaryBaseResponse> GetNextSearchResults(string after, string search)
		{
			var request = await GetStringAsync(baseUrl + "search.json?q=" + search + "&restrict_sr=on&sort=relevance&t=all&after=" + after);
			var documentaries = JsonConvert.DeserializeObject<DocumentaryBaseResponse>(request);
			return documentaries;
		}


		private async Task<string> GetStringAsync(string url)
		{
			using (var httpClient = new HttpClient())
			{
				return await httpClient.GetStringAsync(url);
			}
		}
	}
}
