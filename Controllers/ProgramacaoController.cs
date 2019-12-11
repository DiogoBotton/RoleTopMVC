using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class ProgramacaoController : AbstractController {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        EventosRepository eventosRepository = new EventosRepository();
        public IActionResult Index () {
            var proxEventos = agendamentoRepository.ObterPorStatusAprovado();
            var tiposEventos = eventosRepository.ObterTodos();
            foreach (var evento in proxEventos)
            {
                var url_Banner = Directory.GetFiles(evento.bannerURL).FirstOrDefault();
                var url_BannerTratado = url_Banner.Replace("\\","/").Replace("wwwroot","");
                evento.bannerURL = url_BannerTratado;
            }
            return View (new EventosViewModel () {
                NomeView = "Programacao",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession (),
                    UsuarioTipo = ObterUsuarioTipoSession(),
                    Programacao = proxEventos,
                    tiposEventos = tiposEventos
            });
        }
    }
}