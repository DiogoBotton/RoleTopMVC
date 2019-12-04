using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTOP_MVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
        protected const string SESSION_CLIENTE_TIPO = "cliente_tipo";
        protected const string PATH_BANNER = "images\\banner";


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
    }
}