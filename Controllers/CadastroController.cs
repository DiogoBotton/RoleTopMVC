using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers {
    public class CadastroController : Controller {
        ClienteRepository clienteRepository = new ClienteRepository ();
        [HttpGet]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        public IActionResult Cadastrar (IFormCollection form) {
            ViewData["Action"] = "Cadastro";
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

                //RespostaViewModel
                List<string> erros = new List<string>();
                switch (codErro) {
                    case 0:
                        string senha = form["senha"];
                        cliente.Senha = senha;
                        clienteRepository.Inserir (cliente);
                        return View ("_Sucesso", new RespostaViewModel("Seu cadastro foi realizado com sucesso! Seja Bem Vindo!"));
                    case 1:
                        ViewData["ActionCadastro"] = "Erros";
                        erros.Add("Você precisa aceitar os termos de uso.");
                        return View ("Index", new ErrosViewModel(erros));

                    case 2:
                        ViewData["ActionCadastro"] = "Erros";
                        erros.Add("Confirmação de senha incorreta.");
                        return View ("Index", new ErrosViewModel(erros));

                    case 3:
                        ViewData["ActionCadastro"] = "Erros";
                        erros.Add("Você precisa aceitar os termos de uso.");
                        erros.Add("Confirmação de senha incorreta.");
                        return View ("Index", new ErrosViewModel(erros));
                    default:
                        return View("Index");
                }

                //if (codErro == 0) {
                //    clienteRepository.Inserir (cliente);
                //    return View ("_CadastroRealizado");
                //}

            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return View ();
            }
        }
    }
}