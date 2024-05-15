using Microsoft.AspNetCore.Mvc;

namespace WebAPI.DN5.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/DN5Test")]
        public IActionResult DN5Test()
        {
            return Ok();
        }
    }
}
