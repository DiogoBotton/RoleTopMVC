using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class ProgramacaoController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}