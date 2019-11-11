using System;
using RoleTOP_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Cadastro(){
            return View();
        }
        public IActionResult Cadastro(IFormCollection form){
            try{
                Cliente cliente = new Cliente();

                cliente.Nome = form["nome"];
                //TODO Fazer com todas as propriedades da classe cliente.

                return View("_CadastroRealizado"); 
            }catch(Exception e){
                return View();
            }
        }
    }
}