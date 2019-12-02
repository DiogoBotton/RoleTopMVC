using System.Collections.Generic;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Agendamento> Agendamentos {get;set;}
        public List<Faq> Perguntas {get;set;}
        public uint PedidosAprovados {get;set;}
        public uint PedidosReprovados {get;set;}
        public uint PedidosPendentes {get;set;}
        public uint PedidosCancelados {get;set;}
        public uint MensagemRespondida {get;set;}
        public uint MensagemNaoLida {get;set;}

        public DashboardViewModel(){
            this.Agendamentos = new List<Agendamento>();
            this.Perguntas = new List<Faq>();
        }
    }
}