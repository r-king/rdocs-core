using System;
using System.Linq;
using System.Web;

namespace Rdocs.Utilities
{
	public class YoutubeUtil
    {
		/// <summary>
		/// Returns youtube iframe html component
		/// </summary>
		/// <param name="url">url of youtube video</param>
		/// <returns></returns>
		public static string GetYouTubeIframe(string url)
		{
			return "<iframe src=\"" + ConvertYouTubeUrl(url) + "\" class=\"videoFrame\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen=\"\"></iframe>";
		}

		/// <summary>
		/// Converts youtube url into iframe src url
		/// </summary>
		/// <param name="url">url of youtube video</param>
		/// <returns></returns>
		private static string ConvertYouTubeUrl(string url)
		{
			var uri = new Uri(url);

			var query = HttpUtility.ParseQueryString(uri.Query);

			var videoId = string.Empty;

			if (query.AllKeys.Contains("v"))
			{
				videoId = query["v"];
			}
			else
			{
				videoId = uri.Segments.Last();
			}

			string youtubeUrl = "https://www.youtube.com/embed/" + videoId + "?feature=oembed&amp;enablejsapi=1&amp;showinfo=0&amp;rel=0&amp;autoplay=1";

			return youtubeUrl;
		}
	}
}
