using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Enums;
using RoleTOP_MVC.Models;
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
            evm.UsuarioTipo = ObterUsuarioTipoSession ();
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
                            switch (cliente.TipoUsuario) {
                                case (uint) TipoClienteEnum.ADMINISTRADOR:
                                    HttpContext.Session.SetString (SESSION_CLIENTE_EMAIL, usuario);
                                    HttpContext.Session.SetString (SESSION_CLIENTE_NOME, cliente.Nome);
                                    HttpContext.Session.SetString (SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString ());
                                    return RedirectToAction ("Index", "Administrador");
                                default:
                                    HttpContext.Session.SetString (SESSION_CLIENTE_EMAIL, usuario);
                                    HttpContext.Session.SetString (SESSION_CLIENTE_NOME, cliente.Nome);
                                    HttpContext.Session.SetString (SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString ());
                                    return RedirectToAction ("Usuario", "Cliente");
                            }
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
        public IActionResult Usuario () {
            bool ninguemLogado = string.IsNullOrEmpty (ObterUsuarioSession ());
            if (!ninguemLogado) {
                UsuarioViewModel uvm = new UsuarioViewModel ();
                var emailCliente = HttpContext.Session.GetString (SESSION_CLIENTE_EMAIL);
                var agendamentosCliente = agendamentoRepository.ObterTodosPorCliente (emailCliente);

                foreach (var item in agendamentosCliente) {
                    switch (item.Status) {
                        case (uint) StatusAgendamentoEnum.APROVADO:
                            uvm.PedidosAprovados++;
                            break;
                        case (uint) StatusAgendamentoEnum.REPROVADO:
                            uvm.PedidosReprovados++;
                            break;
                        case (uint) StatusAgendamentoEnum.CANCELADO:
                            uvm.PedidosCancelados++;
                            break;
                        case (uint) StatusAgendamentoEnum.PENDENTE:
                            uvm.PedidosPendentes++;
                            uvm.Agendamentos.Add (item);
                            break;
                        default:
                            uvm.PedidosPendentes++;
                            uvm.Agendamentos.Add (item);
                            break;
                    }
                }

                uvm.qtdAgendamentos = (uint) agendamentosCliente.Count;
                uvm.NomeView = "Usuario";
                uvm.UsuarioEmail = ObterUsuarioSession ();
                uvm.UsuarioNome = ObterUsuarioNomeSession ();
                uvm.UsuarioTipo = ObterUsuarioTipoSession ();
                return View (uvm);
            } else {
                return RedirectToAction ("Index", "Home");
            }
        }

        public IActionResult Visualizar (uint status) {
            UsuarioViewModel uvm = new UsuarioViewModel ();
            var emailCliente = ObterUsuarioSession ();
            var agendamentosCliente = agendamentoRepository.ObterTodosPorCliente (emailCliente);
            foreach (var item in agendamentosCliente) {
                if (item.Status == (uint) status) {
                    uvm.Agendamentos.Add (item);
                }
            }

            uvm.UsuarioEmail = ObterUsuarioSession ();
            uvm.UsuarioNome = ObterUsuarioNomeSession ();
            uvm.UsuarioTipo = ObterUsuarioTipoSession ();
            return View ("_AgendamentosUsuario", uvm);
        }

        public IActionResult Logoff () {
            HttpContext.Session.Remove (SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove (SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult ExcluirConta () {
            if (clienteRepository.Remover (ObterUsuarioSession ())) {
                HttpContext.Session.Remove (SESSION_CLIENTE_EMAIL);
                HttpContext.Session.Remove (SESSION_CLIENTE_NOME);
                HttpContext.Session.Clear ();
                return RedirectToAction ("Index", "Home");
            } else {
                TempData["Usuario"] = "Não foi possível excluir sua conta. Tente novamente mais tarde";
                return RedirectToAction ("Usuario", "Cliente");
            }
        }
    }
}