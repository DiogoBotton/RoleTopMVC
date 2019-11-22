using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTOP_MVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";

        protected string ObterUsuarioSession () {
            var emailCliente = HttpContext.Session.GetString (SESSION_CLIENTE_EMAIL);
            if (!string.IsNullOrEmpty (emailCliente)) {
                return emailCliente;
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
    }
}