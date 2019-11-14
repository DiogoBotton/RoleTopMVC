using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Enums;
using System;

namespace RoleTOP_MVC.Controllers
{
    public class AgendamentoController : Controller
    {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form){
            int eventoEnum;
            int.TryParse(form["evento"], out eventoEnum);
            TipoEventoEnum evento = (TipoEventoEnum) eventoEnum;
            //TODO Retornar valor numerico de Privacidade.
            //TODO Como irá mandar como parametro um CLIENTE.
            
            
            Agendamento agendamento = new Agendamento(){
                NomeEvento = form["nome-evento"],
                TipoEvento = evento.ToString(),

            };
            return View();
        }
    }
}