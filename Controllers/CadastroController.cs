using System;
using RoleTOP_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : Controller
    {
        [HttpGet]
        public IActionResult Cadastro(){
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(IFormCollection form){
            try{
                Cliente cliente = new Cliente();

                cliente.Nome = form["nome"];
                cliente.Email = form["email"];
                cliente.Senha = form["senha"];
                cliente.CEP = form["cep"];
                cliente.CPF_CNPJ = form["cpf-cnpj"];
                cliente.Tel = form["telefone"];
                
                return View("_CadastroRealizado"); 
            }catch(Exception e){
                return View();
            }
        }
    }
}