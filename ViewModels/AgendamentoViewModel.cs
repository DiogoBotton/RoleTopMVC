using System.Collections.Generic;

namespace RoleTOP_MVC.ViewModels
{
    public class AgendamentoViewModel
    {
        public List<string> tipoEventos {get;set;}

        public AgendamentoViewModel(){
            this.tipoEventos = new List<string>();
        }
    }
}