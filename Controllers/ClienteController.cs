using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTOP_MVC.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form){
            return View();
        }
    }
}