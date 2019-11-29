using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class FaqController : AbstractController {
        FaqRepository faqRepository = new FaqRepository ();
        public IActionResult Index () {
            ErrosViewModel evm = new ErrosViewModel();

            var erro = TempData["Faq"] as string;
            if (!string.IsNullOrEmpty (erro)) {
                evm.NomeView = "Erro";
                evm.Mensagem.Add (erro);
            } else {
                evm.NomeView = "Faq";
            }

            evm.UsuarioEmail = ObterUsuarioSession ();
            evm.UsuarioNome = ObterUsuarioNomeSession ();
            evm.UsuarioTipo = ObterUsuarioTipoSession();
            return View (evm);
        }
        public IActionResult Registrar (IFormCollection form) {
            ViewData["Action"] = "Envio de mensagem";

            Faq faq = new Faq () {
                Nome = form["nome"],
                Email = form["email"],
                Mensagem = form["msg"]
            };
            if (faqRepository.Inserir (faq)) {
                return View ("_Sucesso", new RespostaViewModel () {
                    NomeView = "Faq",
                        UsuarioEmail = ObterUsuarioSession (),
                        UsuarioNome = ObterUsuarioNomeSession (),
                        UsuarioTipo = ObterUsuarioTipoSession(),
                        Mensagem = "Aguarde resposta dos administradores em seu Email."
                });
            } else {
                TempData["Faq"] = "Houve um erro no envio da mensagem. Tente novamente mais tarde.";
                return RedirectToAction("Index","Faq");
            }

        }
    }
}