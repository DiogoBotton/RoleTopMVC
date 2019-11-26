using System.Collections.Generic;
using System.IO;
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
            return View (new BaseViewModel () {
                NomeView = "Cliente",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
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
                            List<string> erros = new List<string> ();
                            erros.Add ("Senha Incorreta.");
                            return View ("Index", new BaseViewModel () {
                                Mensagem = erros,
                                    NomeView = "Erro",
                                    UsuarioEmail = ObterUsuarioSession (),
                                    UsuarioNome = ObterUsuarioNomeSession ()
                            });
                        }
                    } else {
                        List<string> erros = new List<string> ();
                        erros.Add ($"Usuario {usuario} não existe.");
                        return View ("Index", new BaseViewModel () {
                            Mensagem = erros,
                                NomeView = "Erro",
                                UsuarioEmail = ObterUsuarioSession (),
                                UsuarioNome = ObterUsuarioNomeSession ()
                        });
                    }
                } else {
                    List<string> erros = new List<string> ();
                    erros.Add ("Complete os campos nome e senha corretamente");
                    return View ("Index", new BaseViewModel () {
                        Mensagem = erros,
                            NomeView = "Erro",
                            UsuarioEmail = ObterUsuarioSession (),
                            UsuarioNome = ObterUsuarioNomeSession ()
                    });
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
    }
}