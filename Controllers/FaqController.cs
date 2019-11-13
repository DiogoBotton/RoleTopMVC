using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}