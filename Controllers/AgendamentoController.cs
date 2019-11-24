using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Enums;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;
using System.Collections.Generic;

namespace RoleTOP_MVC.Controllers {
    public class AgendamentoController : AbstractController {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository ();
        EventosRepository eventosRepository = new EventosRepository ();
        ServicosRepository servicosRepository = new ServicosRepository ();
        ClienteRepository clienteRepository = new ClienteRepository();
        [HttpGet]
        public IActionResult Index () {
            AgendamentoViewModel avm = new AgendamentoViewModel ();
            avm.tipoEventos = eventosRepository.ObterTodos ();
            avm.servicos = servicosRepository.ObterTodos ();
            
            var emailCliente = ObterUsuarioSession();
            if(!string.IsNullOrEmpty(emailCliente)){
                var usuario = clienteRepository.ObterPor(emailCliente);
                avm.Cliente = usuario;
            }
            
            //TempData vindo VAZIO.
            var erro = (string) TempData["Erros"];

            if(!string.IsNullOrEmpty(erro)){ //Se é nulo ou vazio, retorna booleano.
                ViewData["ActionAgendamento"] = "Termos";
                List<string> erros = new List<string>();
                erros.Add(erro);
                avm.Erros = erros;
            }
            return View (avm);
        }

        [HttpPost]
        public IActionResult Registrar (IFormCollection form) {
            //Conversão int para ENUM.
            //TODO o que acontece quando tenta converter numero ENUM que não existe.
            int privacidadeEnum;
            bool converteu = int.TryParse (form["privacidade"], out privacidadeEnum);
            PrivacidadeEnum privacidade;
            if(converteu){
            privacidade = (PrivacidadeEnum) privacidadeEnum;
            }
            else{
            privacidade = (PrivacidadeEnum) 0; //Padrão PRIVADO.
            }

            Cliente c = new Cliente(){
                Nome = form["nome"],
                Email = form["email"],
                CEP = form["cep"],
                CPF = form["cpf"],
                Tel = form["telefone"]
            };

            string SvcAdicionais = form["sv-adc"];
            double SvcPreco = servicosRepository.ObterPrecoTotal(SvcAdicionais);

            Agendamento agendamento = new Agendamento () {
                Cliente = c,
                NomeEvento = form["nome-evento"],
                TipoEvento = form["evento"],
                Privacidade = privacidade.ToString (),
                QtdConvidados = form["qtd-convidados"],
                DataDoEvento = Convert.ToDateTime (form["data-evento"]),
                DataDoAgendamento = DateTime.Now,
                SvcAdicionais = form["sv-adc"],
                DescricaoEvento = form["descricao-evento"],
                FormaPagamento = form["pagamento"],
                PrecoTotal = SvcPreco
                //TODO BANNER (IMG)
            };
            
            bool termos = form["termos"] == "1";
            if (termos) {

                if(agendamentoRepository.Inserir (agendamento)){
                // Manda para uma outra página específica com informações (Resumo) da compra.
                    return View ("_AgendamentoRealizado", new ResumoAgendamentoViewModel(agendamento.DataDoEvento, agendamento.SvcAdicionais, agendamento.PrecoTotal));
                }
                else{
                    TempData["Erros"] = "Houve um erro na efetuação do agendamento. Tente novamente mais tarde.";
                    return RedirectToAction("Index","Agendamento");
                }
            } else {
                TempData["Erros"] = "Você precisa aceitar os termos de uso.";
                return RedirectToAction("Index","Agendamento");
            }

        }
    }
}