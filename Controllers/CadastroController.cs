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
        public IActionResult Cadastrar(IFormCollection form){
            try{
                Cliente cliente = new Cliente();

                cliente.Nome = form["nome"];
                cliente.Email = form["email"];
                cliente.Senha = form["senha"];
                cliente.CEP = form["cep"];
                cliente.CPF_CNPJ = form["cpf-cnpj"];
                cliente.Tel = form["telefone"];

                //TODO validação senha com confirmar senha
                //*melhorar método lógico de exibição de erro se termos não forem aceitos e validação de senha caso diferentes. 

                if(form["termos"] == "1"){
                clienteRepository.Inserir(cliente);
                return View("_CadastroRealizado"); 
                }
                else{
                    ViewData["ActionCadastro"] = "Termos";
                    return View("Index");
                }
            }catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View();
            }
        }
    }
}