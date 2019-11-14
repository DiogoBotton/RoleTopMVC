using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.ViewModels;
using RoleTOP_MVC.Enums;

namespace RoleTOP_MVC.Controllers
{
    public class AgendamentoController : Controller
    {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        EventosRepository eventosRepository = new EventosRepository();
        [HttpGet]
        public IActionResult Index(){
            AgendamentoViewModel avm = new AgendamentoViewModel();
            avm.tipoEventos = eventosRepository.ObterTodos();
            return View(avm);
        }
        [HttpPost]
        public IActionResult Registrar(IFormCollection form){
            //Conversão int para ENUM.
            int privacidadeEnum;
            int.TryParse(form["evento"], out privacidadeEnum);
            PrivacidadeEnum evento = (PrivacidadeEnum) privacidadeEnum;
            //TODO Como irá mandar como parametro um CLIENTE.
            
            
            Agendamento agendamento = new Agendamento(){
                NomeEvento = form["nome-evento"],
                TipoEvento = form["evento"],
                Privacidade = evento.ToString(),
                QtdConvidados = form["qtd-convidados"],
                DataDoEvento = Convert.ToDateTime(form["data-evento"]),
                //TODO serviços adicionais
                DescricaoEvento = form["descricao-evento"],
                //TODO visibilidade, BANNER, termos de uso e pagamento

    

            };
            return View();
        }
    }
}