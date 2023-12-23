using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers
{
    [Route("[controller]")]
    public class NoteController : Controller
    {
        private readonly ILogger<NoteController> _logger;

        public NoteController(ILogger<NoteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}