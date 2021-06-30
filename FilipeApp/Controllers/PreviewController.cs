using Microsoft.AspNetCore.Mvc;

namespace FilipeApp.Controllers
{
    public class PreviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}