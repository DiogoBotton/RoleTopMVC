using Microsoft.AspNetCore.Mvc;

namespace RoleTOP_MVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login(){
            return View();
        }
    }
}