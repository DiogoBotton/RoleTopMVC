using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;
using RoleTOP_MVC.Enums;

namespace RoleTOP_MVC.Controllers {
    public class AdministradorController : AbstractController {
        AgendamentoRepository pedidoRepository = new AgendamentoRepository ();
        FaqRepository faqRepository = new FaqRepository();
        public IActionResult Index () {
            DashboardViewModel dvm = new DashboardViewModel ();
            var agendamentos = pedidoRepository.ObterTodos ();
            foreach (var item in agendamentos) {
                switch (item.Status) {
                    case (uint) StatusAgendamentoEnum.APROVADO:
                    dvm.PedidosAprovados++;
                    break;
                    case (uint) StatusAgendamentoEnum.REPROVADO:
                    dvm.PedidosReprovados++;
                    break;
                    case (uint) StatusAgendamentoEnum.PENDENTE:
                    dvm.PedidosPendentes++;
                    dvm.Agendamentos.Add(item);
                    break;
                    default:
                    dvm.PedidosPendentes++; 
                    dvm.Agendamentos.Add(item);
                    break;
                }
            }

            var mensagens = faqRepository.ObterTodos();
            foreach (var item in mensagens)
            {
                switch (item.Status)
                {
                    case (uint) StatusPerguntaEnum.NAO_LIDA:
                    break;
                    case (uint) StatusPerguntaEnum.RESPONDIDA:
                    break;
                    default:
                    break;
                }
            }

            dvm.NomeView = "Dashboard";
            dvm.UsuarioEmail = ObterUsuarioSession();
            dvm.UsuarioNome = ObterUsuarioNomeSession();
            return View (dvm);
        }
    }
}