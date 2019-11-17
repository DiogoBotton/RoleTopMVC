using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;

namespace RoleTopMVC.Controllers
{
    public class FaqController : Controller
    {
        FaqRepository faqRepository = new FaqRepository();
        public IActionResult Index(){
            return View();
        }
        public IActionResult Registrar(IFormCollection form){
            try
            {
            Faq faq = new Faq(){
                Nome = form["nome"],
                Email = form["email"],
                Mensagem = form["msg"]
            };
            faqRepository.Inserir(faq);
            return View("_PerguntaEnviada");
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Index");
            }
        }
    }
}