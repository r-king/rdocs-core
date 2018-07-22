using Rdocs.Models;
using System.Threading.Tasks;

namespace Rdocs.Repositories
{
	interface IDocumentaryRepository
    {
		Task<DocumentaryBaseResponse> GetTopDocumentaries();

		Task<DocumentaryBaseResponse> GetHotDocumentaries();

		Task<DocumentaryBaseResponse> GetRisingDocumentaries();

		Task<DocumentaryBaseResponse> GetNextHotDocumentaries(string after);

		Task<DocumentaryBaseResponse> GetNextRisingDocumentaries(string after);

		Task<DocumentaryBaseResponse> GetNextTopDocumentaries(string after);

		Task<DocumentaryBaseResponse> GetSearchResults(string search);

		Task<DocumentaryBaseResponse> GetNextSearchResults(string after, string search);
	}
}
