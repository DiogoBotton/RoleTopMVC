using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class ClienteController : AbstractController {
        ClienteRepository clienteRepository = new ClienteRepository ();
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository ();
        [HttpGet]
        public IActionResult Index () {
            ErrosViewModel evm = new ErrosViewModel ();

            var erro = TempData["Cliente"] as string;
            if (!string.IsNullOrEmpty (erro)) {
                evm.NomeView = "Erro";
                evm.Mensagem.Add (erro);
            } else {
                evm.NomeView = "Cliente";
            }

            evm.UsuarioEmail = ObterUsuarioSession ();
            evm.UsuarioNome = ObterUsuarioNomeSession ();
            return View (evm);
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form) {
            try {
                var usuario = form["email"];
                var senha = form["senha"];

                if (!string.IsNullOrEmpty (usuario) && !string.IsNullOrEmpty (senha)) {
                    var cliente = clienteRepository.ObterPor (usuario);

                    if (cliente != null) {
                        if (cliente.Senha.Equals (senha)) {
                            HttpContext.Session.SetString (SESSION_CLIENTE_EMAIL, usuario);
                            HttpContext.Session.SetString (SESSION_CLIENTE_NOME, cliente.Nome);
                            return RedirectToAction ("Usuario", "Cliente");
                        } else {
                            TempData["Cliente"] = "Senha incorreta";
                            return RedirectToAction ("Index", "Cliente");
                        }
                    } else {
                        TempData["Cliente"] = $"Usuario {usuario} não existe.";
                        return RedirectToAction ("Index", "Cliente");
                    }
                } else {
                    TempData["Cliente"] = "Complete os campos nome e senha corretamente";
                    return RedirectToAction ("Index", "Cliente");
                }
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return View ();
            }
        }
        //TODO método para o menu do Usuario
        public IActionResult Usuario () {
            var emailCliente = HttpContext.Session.GetString (SESSION_CLIENTE_EMAIL);
            var agendamentosCliente = agendamentoRepository.ObterTodosPorCliente (emailCliente);

            return View (new UsuarioViewModel (agendamentosCliente) {
                NomeView = "Cliente",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
        }
        public IActionResult Logoff () {
            HttpContext.Session.Remove (SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove (SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "Home");
        }
    }
}