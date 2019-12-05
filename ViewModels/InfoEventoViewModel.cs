using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class InfoEventoViewModel : BaseViewModel
    {
        public Agendamento evento {get;set;}
        public string url_banner {get;set;}
        public InfoEventoViewModel(){
            this.evento = new Agendamento();
        }
    }
}