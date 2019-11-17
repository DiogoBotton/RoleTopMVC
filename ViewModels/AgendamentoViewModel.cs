using System.Collections.Generic;

namespace RoleTOP_MVC.ViewModels
{
    public class AgendamentoViewModel
    {
        public List<string> tipoEventos {get;set;}
        public Dictionary<string,double> servicos {get;set;}

        public AgendamentoViewModel(){
            this.tipoEventos = new List<string>();
            this.servicos = new Dictionary<string, double>();
        }
    }
}