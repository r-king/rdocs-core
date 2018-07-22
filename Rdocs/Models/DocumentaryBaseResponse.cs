using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Rdocs.Models
{
	/// <summary>
	/// response from reddit request
	/// </summary>
	[DataContract]
	public class DocumentaryBaseResponse
	{
		[DataMember]
		public DocumentaryResponse Data { get; set; }

		[DataMember]
		public string Kind { get; set; }
	}


	public class DocumentaryResponse
	{
		/// <summary>
		/// last post id in response, used as id to fetch next reponse
		/// </summary>
		public string After { get; set; }

		/// <summary>
		/// post id of previous response
		/// </summary>
		public string Before { get; set; }

		/// <summary>
		/// collection of posts
		/// </summary>
		public List<DocumentaryItem> Children { get; set; }

	}

	public class DocumentaryItem
	{
		/// <summary>
		/// 
		/// </summary>
		public Documentary Data { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Kind { get; set; }
	}

	public class Documentary
	{
		/// <summary>
		/// unique identifier of post
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// title of reddit post
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// number of upvotes
		/// </summary>
		public int Ups { get; set; }

		/// <summary>
		/// number of downvotes
		/// </summary>
		public int Downs { get; set; }

		/// <summary>
		/// overall score
		/// </summary>
		public int Score { get; set; }

		/// <summary>
		/// media url
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// embedded media
		/// </summary>
		public SecureMedia Secure_Media { get; set; }
	}

	public class SecureMedia
	{
		/// <summary>
		/// media type
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// embedded media details
		/// </summary>
		public Oembed Oembed { get; set; }
	}

	public class Oembed
	{
		/// <summary>
		/// title of media
		/// </summary>
		public string Title;

		/// <summary>
		/// media thumnail url
		/// </summary>
		public string Thumbnail_Url;
	}
}
