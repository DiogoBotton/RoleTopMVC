using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;
using RoleTOP_MVC.Enums;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class AgendamentoController : Controller {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository ();
        EventosRepository eventosRepository = new EventosRepository ();
        ServicosAdicionaisRepository servicosRepository = new ServicosAdicionaisRepository ();
        [HttpGet]
        public IActionResult Index () {
            AgendamentoViewModel avm = new AgendamentoViewModel ();
            avm.tipoEventos = eventosRepository.ObterTodos ();
            avm.servicos = servicosRepository.ObterTodos ();
            return View (avm);
        }

        [HttpPost]
        public IActionResult Registrar (IFormCollection form) {
            //Conversão int para ENUM.
            int privacidadeEnum;
            int.TryParse (form["privacidade"], out privacidadeEnum);
            PrivacidadeEnum privacidade = (PrivacidadeEnum) privacidadeEnum;

            Agendamento agendamento = new Agendamento () {
                NomeEvento = form["nome-evento"],
                TipoEvento = form["evento"],
                Privacidade = privacidade.ToString (),
                QtdConvidados = form["qtd-convidados"],
                DataDoEvento = Convert.ToDateTime (form["data-evento"]),
                DataDoAgendamento = DateTime.Now,
                SvcAdicionais = form["sv-adc"],
                DescricaoEvento = form["descricao-evento"],
                FormaPagamento = form["pagamento"]
                //TODO BANNER (IMG)
                //TODO Como irá mandar como parametro um CLIENTE "logado".
            };
            if (form["termos"] == "1") {
                agendamentoRepository.Inserir (agendamento);

                // Manda para uma outra página específica com informações (Resumo) da compra.
                return View ("_AgendamentoRealizado",agendamento);
            } else {
                ViewData["ActionAgendamento"] = "Termos";
                AgendamentoViewModel avm = new AgendamentoViewModel ();
                avm.tipoEventos = eventosRepository.ObterTodos ();
                avm.servicos = servicosRepository.ObterTodos ();
                return View ("Index",avm);
            }

        }
    }
}