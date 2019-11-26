using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        public IActionResult Index(){
            return View(new BaseViewModel(){
                NomeView = "Admin",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}