using BrickStructure.Business.Managers;
using BrickStructure.Client.BusinessLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BrickStructure.Endpoints.Web.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly WeatherManager _weatherManager;
        private readonly WeatherExtendedManager _weatherExtendedManager;

        public WeatherController(
            ILogger<WeatherController> logger,
            WeatherManager weatherManager,
            WeatherExtendedManager weatherExtendedManager)
        {
            _logger = logger;
            _weatherManager = weatherManager;
            _weatherExtendedManager = weatherExtendedManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllCore()
        {
            var items = await _weatherManager.GetAll(false).OrderByDescending(o => o.Id).Take(20).ToListAsync().ConfigureAwait(false);
            return new JsonResult(items);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllExtended()
        {
            var items = await _weatherExtendedManager.GetAll(false).OrderByDescending(o => o.Id).Take(20).ToListAsync().ConfigureAwait(false);
            return new JsonResult(items);
        }
    }
}
