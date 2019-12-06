using System.Collections.Generic;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public List<Agendamento> Programacao {get;set;}

        public HomeViewModel (){
            this.Programacao = new List<Agendamento>();
        }
    }
}