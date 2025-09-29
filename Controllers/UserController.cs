using Microsoft.AspNetCore.Mvc;

namespace SocialNetworkV1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
