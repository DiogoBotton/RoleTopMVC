using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class ProgramacaoController : AbstractController {
        public IActionResult Index () {
            return View (new BaseViewModel () {
                NomeView = "Programacao",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
        }
    }
}