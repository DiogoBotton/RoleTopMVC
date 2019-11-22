using System.Collections.Generic;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class UsuarioViewModel
    {
        public List<Agendamento> Agendamentos {get;set;}
        public Cliente cliente {get;set;}

        // public UsuarioViewModel(){
        //     this.Agendamentos = new List<Agendamento>();
        // }
        public UsuarioViewModel(List<Agendamento> Agendamentos){
            this.Agendamentos = Agendamentos;
        }
    }
}