using System.Collections.Generic;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class EventosViewModel : BaseViewModel
    {
        public List<Agendamento> Programacao {get;set;}
        public List<string> tiposEventos {get;set;}
        public EventosViewModel (){
            this.Programacao = new List<Agendamento>();
            this.tiposEventos = new List<string>();
        }
    }
}