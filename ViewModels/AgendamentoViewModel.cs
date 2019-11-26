using System.Collections.Generic;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public List<string> tipoEventos {get;set;}
        public Dictionary<string,double> servicos {get;set;}
        public List<string> Erros {get;set;}
        public Cliente Cliente {get;set;}

        public AgendamentoViewModel(){
            this.tipoEventos = new List<string>();
            this.servicos = new Dictionary<string, double>();
            this.Erros = new List<string>();
            this.Cliente = new Cliente();
        }
    }
}