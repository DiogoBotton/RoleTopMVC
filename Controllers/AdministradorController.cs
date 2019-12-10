using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Enums;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class AdministradorController : AbstractController {
        ClienteRepository clienteRepository = new ClienteRepository ();
        AgendamentoRepository pedidoRepository = new AgendamentoRepository ();
        FaqRepository faqRepository = new FaqRepository ();
        public IActionResult Index () {
            bool ninguemLogado = string.IsNullOrEmpty (ObterUsuarioTipoSession ());
            if (!ninguemLogado && (uint) TipoClienteEnum.ADMINISTRADOR == uint.Parse (ObterUsuarioTipoSession ())) {

                DashboardViewModel dvm = new DashboardViewModel ();
                var agendamentos = pedidoRepository.ObterTodos ();
                foreach (var item in agendamentos) {
                    switch (item.Status) {
                        case (uint) StatusAgendamentoEnum.APROVADO:
                            dvm.PedidosAprovados++;
                            break;
                        case (uint) StatusAgendamentoEnum.REPROVADO:
                            dvm.PedidosReprovados++;
                            break;
                        case (uint) StatusAgendamentoEnum.CANCELADO:
                            dvm.PedidosCancelados++;
                            break;
                        case (uint) StatusAgendamentoEnum.PENDENTE:
                            dvm.PedidosPendentes++;
                            dvm.Agendamentos.Add (item);
                            break;
                        default:
                            dvm.PedidosPendentes++;
                            dvm.Agendamentos.Add (item);
                            break;
                    }
                }

                var mensagens = faqRepository.ObterTodos ();
                foreach (var msg in mensagens) {
                    switch (msg.Status) {
                        case (uint) StatusPerguntaEnum.NAO_LIDA:
                            dvm.MensagemNaoLida++;
                            dvm.Perguntas.Add (msg);
                            break;
                        case (uint) StatusPerguntaEnum.RESPONDIDA:
                            dvm.MensagemRespondida++;
                            break;
                        default:
                            dvm.MensagemNaoLida++;
                            dvm.Perguntas.Add (msg);
                            break;
                    }
                }

                dvm.NomeView = "Dashboard";
                dvm.UsuarioEmail = ObterUsuarioSession ();
                dvm.UsuarioNome = ObterUsuarioNomeSession ();
                dvm.UsuarioTipo = ObterUsuarioTipoSession ();
                return View (dvm);
            } else {
                return RedirectToAction ("Index", "Home");
            }
        }
        public IActionResult ListaUsuarios () {
            DashboardViewModel dvm = new DashboardViewModel ();
            var clientes = clienteRepository.ObterTodos ();

            dvm.Clientes = clientes;
            dvm.NomeView = "Dashboard";
            dvm.UsuarioEmail = ObterUsuarioSession ();
            dvm.UsuarioNome = ObterUsuarioNomeSession ();
            dvm.UsuarioTipo = ObterUsuarioTipoSession ();
            return View("_ListaUsuarios", dvm);
        }
        public IActionResult VisualizarCliente(string email){
            DashboardViewModel dvm = new DashboardViewModel ();
            var cliente = clienteRepository.ObterPor(email);

            dvm.clienteEspecifico = cliente;
            dvm.NomeView = "Dashboard";
            dvm.UsuarioEmail = ObterUsuarioSession ();
            dvm.UsuarioNome = ObterUsuarioNomeSession ();
            dvm.UsuarioTipo = ObterUsuarioTipoSession ();
            return View("_ClienteEspecifico", dvm);
        }
        public IActionResult Logoff () {
            HttpContext.Session.Remove (SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove (SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult EnviarEmail (IFormCollection form) {

            string emailDestinatario = form["email"];
            string mensagem = form["resposta"];
            ulong idFaq = 99;

            bool converteu = ulong.TryParse (form["id"], out idFaq);
            if (converteu) {
                if (SendMail (emailDestinatario, mensagem)) {
                    var faq = faqRepository.ObterPor (idFaq);
                    if (faq != null) {
                        faq.Status = (uint) StatusPerguntaEnum.RESPONDIDA;
                        faqRepository.Atualizar (faq);
                        return RedirectToAction ("Index", "Administrador");
                    } else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine ("Objeto nulo, mensagem ID não encontrado.");
                        Console.ResetColor ();
                        return RedirectToAction ("Index", "Administrador");
                    }
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine ("Erro no envio para o EMAIL do destinatário.");
                    System.Console.WriteLine (idFaq);
                    System.Console.WriteLine (emailDestinatario);
                    Console.ResetColor ();
                    return RedirectToAction ("Index", "Administrador");
                }
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine ("Erro na captura ou conversão do ID do destinatário.");
                System.Console.WriteLine (idFaq);
                System.Console.WriteLine (emailDestinatario);
                Console.ResetColor ();
                return RedirectToAction ("Index", "Administrador");
            }
        }

        public IActionResult NotificacaoUsuarioEmail(SendEmail se){
            if(EnviarEmailEventoStatus(se.Email, se.Status)){
                return RedirectToAction ("Index", "Administrador");
            }
            else{
                return RedirectToAction ("Index", "Administrador");
            }
        }
        private bool EnviarEmailEventoStatus (string email, string status) {
            try {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage ();
                // Remetente
                _mailMessage.From = new MailAddress ("roletop.senai@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add (email); // Destinatário
                _mailMessage.Subject = "Situação do seu evento no salão Role TOP."; // Titulo
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = $"<b> Administração da empresa RoleTOP</b><p>Seu evento foi visualizado pelo ADMIN e foi {status}. Para mais informações / reclamações mande uma mensagem para o WhatsApp da empresa: (11) 91234-5678.</p>"; // Corpo / Mensagem

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient ("smtp.gmail.com", Convert.ToInt32 ("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential ("roletop.senai@gmail.com", "senai@132");
                // Usuario(roletop.senai@gmail.com) Senha(senai@132)
                _smtpClient.EnableSsl = true;

                //* CORRIGIDO: Erro no envio pois não havia servidor SmtpClient aberto.
                //* Apenas foi feito uma configuração da conta remetente para habilitar o envio de emails 
                _smtpClient.Send (_mailMessage);

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}