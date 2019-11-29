using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;
using RoleTOP_MVC.Enums;

namespace RoleTOP_MVC.Controllers {
    public class AdministradorController : AbstractController {
        AgendamentoRepository pedidoRepository = new AgendamentoRepository ();
        FaqRepository faqRepository = new FaqRepository();
        public IActionResult Index () {
            bool ninguemLogado = string.IsNullOrEmpty(ObterUsuarioTipoSession());
            if(!ninguemLogado && (uint) TipoClienteEnum.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession())){

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
            foreach (var msg in mensagens)
            {
                switch (msg.Status)
                {
                    case (uint) StatusPerguntaEnum.NAO_LIDA:
                    dvm.MensagemNaoLida++;
                    dvm.Perguntas.Add(msg);
                    break;
                    case (uint) StatusPerguntaEnum.RESPONDIDA:
                    dvm.MensagemRespondida++;
                    break;
                    default:
                    dvm.MensagemNaoLida++;
                    dvm.Perguntas.Add(msg);
                    break;
                }
            }

            dvm.NomeView = "Dashboard";
            dvm.UsuarioEmail = ObterUsuarioSession();
            dvm.UsuarioNome = ObterUsuarioNomeSession();
            dvm.UsuarioTipo = ObterUsuarioTipoSession();
            return View (dvm);
            }
            else{
                return RedirectToAction("Index","Home");
            }
        }
        public IActionResult Logoff (){
            HttpContext.Session.Remove (SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove (SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "Home");
        }
        //TODO Métodos aprovar e reprovar
        //TODO Arrumar CSS botão aceitar e recusar InfoEventos
        //TODO Verificar por que StringStatus esta vindo vazia na lista de eventos (DASHBOARD)
        //TODO Mensagens de usuarios (FAQ) Fazer mesmo processo de metodos aprovar e reprovar eventos


        //TODO À PARTE: TempData retornando todas as informações digitadas do usuario caso dê algum erro (no cadastro e agendamento)
        //Todo Verificar por que tempdata vem vazio quando recebe uma Lista de Strings
    }
}