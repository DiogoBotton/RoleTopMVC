using System.Collections.Generic;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        public List<Agendamento> Agendamentos {get;set;}
        public Cliente cliente {get;set;}
        public uint qtdAgendamentos {get;set;}
        public uint PedidosAprovados {get;set;}
        public uint PedidosReprovados {get;set;}
        public uint PedidosPendentes {get;set;}
        public uint PedidosCancelados {get;set;}



        public UsuarioViewModel(List<Agendamento> Agendamentos){
            this.Agendamentos = Agendamentos;
        }
        public UsuarioViewModel(){
            this.Agendamentos = new List<Agendamento>();
        }
    }
}