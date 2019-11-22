using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers
{
    public class FaqController : Controller
    {
        FaqRepository faqRepository = new FaqRepository();
        public IActionResult Index(){
            return View();
        }
        public IActionResult Registrar(IFormCollection form){
            ViewData["Action"] = "Envio de mensagem";
            try
            {
            Faq faq = new Faq(){
                Nome = form["nome"],
                Email = form["email"],
                Mensagem = form["msg"]
            };
            faqRepository.Inserir(faq);
            return View("_Sucesso", new RespostaViewModel("Aguarde resposta dos administradores no seu Email."));
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Index");
            }
        }
    }
}