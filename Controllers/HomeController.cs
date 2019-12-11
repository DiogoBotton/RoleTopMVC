using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class HomeController : AbstractController {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        public IActionResult Index () {
            var proxEventos = agendamentoRepository.ObterPorStatusAprovado();
            int count = 1;
            foreach (var evento in proxEventos)
            {
                var url_Banner = Directory.GetFiles(evento.bannerURL).FirstOrDefault();
                var url_BannerTratado = url_Banner.Replace("\\","/").Replace("wwwroot","");
                evento.bannerURL = url_BannerTratado;
                evento.ContadorEventos = count;
                count++;
            }
            return View (new EventosViewModel() {
                NomeView = "Home",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession (),
                    UsuarioTipo = ObterUsuarioTipoSession(),
                    Programacao = proxEventos
            });
        }
        public IActionResult Visualizar(ulong id){
            var evento = agendamentoRepository.ObterPor(id);

            var url_Banner = Directory.GetFiles(evento.bannerURL).FirstOrDefault();
            var url_BannerTratado = url_Banner.Replace("\\","/").Replace("wwwroot","");

            evento.bannerURL = url_BannerTratado;
            
            return View ("_EventoPublico", new InfoEventoViewModel() {
                NomeView = "Evento",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession (),
                    UsuarioTipo = ObterUsuarioTipoSession(),
                    evento = evento
            });
        }
        public IActionResult Estrutura () {
            return View (new BaseViewModel () {
                NomeView = "Estrutura",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession (),
                    UsuarioTipo = ObterUsuarioTipoSession()
            });
        }
    }
}