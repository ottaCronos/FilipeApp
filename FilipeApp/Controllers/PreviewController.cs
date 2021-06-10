using Microsoft.AspNetCore.Mvc;

namespace FilipeApp.Controllers
{
    public class PreviewController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}