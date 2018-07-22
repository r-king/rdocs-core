using System.Threading.Tasks;

namespace Rdocs.Services
{
	public interface IViewRenderService
	{
		Task<string> RenderToStringAsync(string viewName, object model);
	}
}
