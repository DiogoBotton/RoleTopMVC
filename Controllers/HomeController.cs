using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class HomeController : AbstractController {
        public IActionResult Index () {
            //ViewData["NomeView"] = "Home";
            return View (new BaseViewModel () {
                NomeView = "Home",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
        }
        public IActionResult Estrutura () {
            return View (new BaseViewModel () {
                NomeView = "Estrutura",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
        }
    }
}