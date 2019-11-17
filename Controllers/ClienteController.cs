using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace RoleTOP_MVC.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form){
            try
            {
                var usuario = form["email"];
                var senha = form["senha"];
                return View();
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View();
            }
        }
        //TODO método para o menu do Usuario
    }
}