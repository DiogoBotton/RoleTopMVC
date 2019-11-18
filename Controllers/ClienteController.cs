using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;

namespace RoleTOP_MVC.Controllers {
    public class ClienteController : Controller {
        ClienteRepository clienteRepository = new ClienteRepository ();
        [HttpGet]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form) {
            try {
                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor (usuario);
                if (cliente != null) {

                    if (cliente.Senha.Equals (senha) && cliente.Email.Equals (usuario)) {
                        return View ();
                    } else {
                        return View ();
                    }
                }
                return View ();
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return View ();
            }
        }
        //TODO método para o menu do Usuario
    }
}