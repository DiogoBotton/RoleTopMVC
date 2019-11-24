using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class FaqController : Controller {
        FaqRepository faqRepository = new FaqRepository ();
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Registrar (IFormCollection form) {
            ViewData["Action"] = "Envio de mensagem";

            Faq faq = new Faq () {
                Nome = form["nome"],
                Email = form["email"],
                Mensagem = form["msg"]
            };
            if (faqRepository.Inserir (faq)) {
                return View ("_Sucesso", new RespostaViewModel ("Aguarde resposta dos administradores no seu Email."));
            } else {
                ViewData["Action"] = "Erro";
                List<string> erros = new List<string> ();
                erros.Add ("Houve um erro no envio da mensagem. Tente novamente mais tarde.");
                return View ("Index", new ErrosViewModel (erros));
            }

        }
    }
}