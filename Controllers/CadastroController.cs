using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Enums;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class CadastroController : AbstractController {
        ClienteRepository clienteRepository = new ClienteRepository ();
        [HttpGet]
        public IActionResult Index () {
            ErrosViewModel evm = new ErrosViewModel ();

            //TODO ARRUMAR: Lista vindo NULA ou VAZIA.
            var erros = TempData["Cadastro"] as List<string>;
            if (erros != null) {
                evm.NomeView = "Erros";
                evm.Mensagem = erros;
            } else {
                evm.NomeView = "Cadastro";
            }
            evm.UsuarioEmail = ObterUsuarioSession ();
            evm.UsuarioNome = ObterUsuarioNomeSession ();
            evm.UsuarioTipo = ObterUsuarioTipoSession ();
            return View (evm);
        }

        [HttpPost]
        public IActionResult Cadastrar (IFormCollection form) {
            ViewData["Action"] = "Cadastro";

            Cliente cliente = new Cliente ();

            cliente.Nome = form["nome"];
            cliente.Email = form["email"];
            cliente.CEP = form["cep"];
            cliente.CPF = form["cpf"];
            cliente.Tel = form["telefone"];
            cliente.TipoUsuario = (uint) TipoClienteEnum.USUARIO;

            List<string> erros = new List<string> ();
            //Verificação de email's já existentes.
            var email = clienteRepository.ObterPor (cliente.Email);
            if (email != null) {
                erros.Add ($"Email {cliente.Email} já existe.");
                TempData["Cadastro"] = erros;
                return RedirectToAction ("Index", "Cadastro");
            }

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
            switch (codErro) {
                case 0:
                    string senha = form["senha"];
                    cliente.Senha = senha;
                    if (clienteRepository.Inserir (cliente)) {
                        return View ("_Sucesso", new RespostaViewModel ("Seu cadastro foi realizado com sucesso! Seja Bem Vindo!") {
                            NomeView = "Cadastro",
                                UsuarioEmail = ObterUsuarioSession (),
                                UsuarioNome = ObterUsuarioNomeSession (),
                                UsuarioTipo = ObterUsuarioTipoSession ()
                        });
                    } else {
                        erros.Add ("Houve um erro na efetuação do cadastro. Tente novamente mais tarde.");
                        TempData["Cadastro"] = erros;
                        return RedirectToAction ("Index", "Cadastro");
                    }
                case 1:
                    erros.Add ("Você precisa aceitar os termos de uso.");
                    TempData["Cadastro"] = erros;
                    return RedirectToAction ("Index", "Cadastro");
                case 2:
                    erros.Add ("Confirmação de senha incorreta.");
                    TempData["Cadastro"] = erros;
                    return RedirectToAction ("Index", "Cadastro");
                case 3:
                    erros.Add ("Você precisa aceitar os termos de uso.");
                    erros.Add ("Confirmação de senha incorreta.");
                    TempData["Cadastro"] = erros;
                    TempData.Keep("Cadastro");
                    return RedirectToAction ("Index", "Cadastro");
                default:
                    return View ("Index");
            }
        }
    }
}