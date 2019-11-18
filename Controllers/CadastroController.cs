using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;

namespace RoleTopMVC.Controllers {
    public class CadastroController : Controller {
        ClienteRepository clienteRepository = new ClienteRepository ();
        [HttpGet]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        public IActionResult Cadastrar (IFormCollection form) {
            try {
                Cliente cliente = new Cliente ();

                cliente.Nome = form["nome"];
                cliente.Email = form["email"];
                cliente.CEP = form["cep"];
                cliente.CPF_CNPJ = form["cpf-cnpj"];
                cliente.Tel = form["telefone"];

                
                //método lógico de exibição de erro se termos não forem aceitos ou validação de senha caso diferentes. 

                int codErro = 0;

                bool termos = form["termos"] == "1";
                if (!termos) {
                    codErro = 1;
                }

                bool senhaValidacao = form["senha"] == form["confirmar-senha"];
                if (!senhaValidacao) {
                    codErro = codErro + 2;
                }

                switch (codErro) {
                    case 0:
                        string senha = form["senha"];
                        cliente.Senha = senha;
                        clienteRepository.Inserir (cliente);
                        return View ("_CadastroRealizado");
                    case 1:
                        ViewData["ActionCadastro"] = "Termos";
                        return View ("Index");

                    case 2:
                        ViewData["ActionCadastro"] = "Senha";
                        return View ("Index");

                    case 3:
                        ViewData["ActionCadastro"] = "TermoseSenha";
                        return View ("Index");
                    default:
                        return View("Index");
                }

                //if (codErro == 0) {
                //    clienteRepository.Inserir (cliente);
                //    return View ("_CadastroRealizado");
                //}

            } catch (Exception e) {
                System.Console.WriteLine (e.StackTrace);
                return View ();
            }
        }
    }
}