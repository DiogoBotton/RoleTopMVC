using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTOP_MVC.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Login(){
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form){
            return View();
        }
    }
}