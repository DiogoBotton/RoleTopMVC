using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTOP_MVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
        protected const string SESSION_CLIENTE_TIPO = "cliente_tipo";
        protected const string PATH_BANNER = "Img\\banner";


        protected string ObterUsuarioSession () {
            var emailCliente = HttpContext.Session.GetString (SESSION_CLIENTE_EMAIL);
            if (!string.IsNullOrEmpty (emailCliente)) {
                return emailCliente;
            }
            return "";
        }
        protected string ObterUsuarioTipoSession () {
            var TipoUsuario = HttpContext.Session.GetString (SESSION_CLIENTE_TIPO);
            if (!string.IsNullOrEmpty (TipoUsuario)) {
                return TipoUsuario;
            }
            return "";
        }
        protected string ObterUsuarioNomeSession () {
            var nomeCliente = HttpContext.Session.GetString (SESSION_CLIENTE_NOME);
            if (!string.IsNullOrEmpty (nomeCliente)) {
                return nomeCliente;
            }
            return "";
        }
        protected bool SendMail (string email, string mensagem) {
            try {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage ();
                // Remetente
                _mailMessage.From = new MailAddress ("roletop.senai@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add (email); // Destinatário
                _mailMessage.Subject = "Resposta Administração RoleTop."; // Titulo
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = $"<b> Administração da empresa RoleTOP</b><p>{mensagem}</p>"; // Corpo / Mensagem

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

            //TODO À PARTE: TempData retornando todas as informações digitadas do usuario caso dê algum erro (no cadastro e agendamento)
            //TODO Validação de formas de pagamento e Tipos de eventos.
            //TODO Tela de programação (mostrar apenas agendamentos aprovados e públicos)
        }
    }
}