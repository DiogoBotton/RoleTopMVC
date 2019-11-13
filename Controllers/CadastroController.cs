using System;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form){
            try{
                Cliente cliente = new Cliente();

                cliente.Nome = form["nome"];
                cliente.Email = form["email"];
                cliente.Senha = form["senha"];
                cliente.CEP = form["cep"];
                cliente.CPF_CNPJ = form["cpf-cnpj"];
                cliente.Tel = form["telefone"];

                if(form["termos"] == "1"){
                clienteRepository.Inserir(cliente);
                return View("_CadastroRealizado"); 
                }
                else{
                    ViewData["ActionCadastro"] = "Termos";
                    return View();
                }
            }catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View();
            }
        }
    }
}