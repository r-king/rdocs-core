using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rdocs.Models;
using Rdocs.Repositories;
using Rdocs.Services;
using Rdocs.Utilities;

namespace Rdocs.Controllers
{
	public class HomeController : Controller
	{

		private readonly IDocumentaryRepository _documentaryRepository;
		private readonly IViewRenderService _viewRenderService;

		public HomeController(IViewRenderService viewRenderService)
		{
			_documentaryRepository = new DocumentaryRepository();
			_viewRenderService = viewRenderService;
		}
		[Route("")]
		public async Task<IActionResult> Hot()
		{
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetHotDocumentaries();
			return View(await documentaries);
		}

		[Route("Rising")]
		public async Task<IActionResult> Rising()
		{
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetRisingDocumentaries();
			return View(await documentaries);
		}

		[Route("Top")]
		public async Task<IActionResult> Top()
		{
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetTopDocumentaries();
			return View(await documentaries);
		}

		public async Task<JsonResult> HotNext(string after)
		{
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetNextHotDocumentaries(after);
			var result = await documentaries;
			return new JsonResult(new { view = _viewRenderService.RenderToStringAsync("_VideoList", result), after = result.Data.After });
		}

		public async Task<JsonResult> RisingNext(string after)
		{
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetNextRisingDocumentaries(after);
			var result = await documentaries;
			return new JsonResult(new { view = _viewRenderService.RenderToStringAsync("_VideoList", result), after = result.Data.After });
		}

		public async Task<JsonResult> TopNext(string after)
		{
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetNextTopDocumentaries(after);
			var result = await documentaries;
			return new JsonResult(new { view = _viewRenderService.RenderToStringAsync("_VideoList", result), after = result.Data.After });
		}

		[Route("Search")]
		public async Task<IActionResult> Search(string searchString)
		{
			ViewData["SearchString"] = searchString;
			Debug.WriteLine(searchString);
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetSearchResults(searchString);
			return View(await documentaries);
		}

		public async Task<JsonResult> SearchNext(string after, string searchString)
		{
			Task<DocumentaryBaseResponse> documentaries = _documentaryRepository.GetNextSearchResults(after, searchString);
			var result = await documentaries;
			return new JsonResult(new { view = _viewRenderService.RenderToStringAsync("_VideoList", result), after = result.Data.After });
		}

		public JsonResult GetYoutubeIframe(string url)
		{
			string iframe = YoutubeUtil.GetYouTubeIframe(url);
			return new JsonResult(new { value = iframe });
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
