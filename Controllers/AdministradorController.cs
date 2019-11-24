using Microsoft.AspNetCore.Mvc;

namespace RoleTOP_MVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        public IActionResult Index(){
            return View();
        }
    }
}