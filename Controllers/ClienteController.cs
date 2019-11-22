using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class ClienteController : AbstractController {
        ClienteRepository clienteRepository = new ClienteRepository ();
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
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

                    if (cliente.Senha.Equals (senha)) {
                        HttpContext.Session.SetString (SESSION_CLIENTE_EMAIL, usuario);
                        return RedirectToAction ("Usuario", "Cliente");
                    } else {
                        ViewData["Action"] = "Erro";
                        List<string> erros = new List<string> ();
                        erros.Add ("Senha Incorreta.");
                        return View ("Index", new ErrosViewModel (erros));
                    }
                } else {
                    ViewData["Action"] = "Erro";
                    List<string> erros = new List<string> ();
                    erros.Add ($"Usuario {usuario} não existe.");
                    return View ("Index", new ErrosViewModel (erros));
                }
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return View ();
            }
        }
        //TODO método para o menu do Usuario
        public IActionResult Usuario () {
            var emailCliente = HttpContext.Session.GetString (SESSION_CLIENTE_EMAIL);
            var agendamentosCliente = agendamentoRepository.ObterTodosPorCliente(emailCliente);

            return View(new UsuarioViewModel(agendamentosCliente));
        }
    }
}