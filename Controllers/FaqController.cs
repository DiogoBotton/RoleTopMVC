using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Faq(){
            return View();
        }
    }
}