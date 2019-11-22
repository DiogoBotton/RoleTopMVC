using System.Collections.Generic;

namespace RoleTOP_MVC.ViewModels
{
    public class ErrosViewModel
    {
        public List<string> Mensagem {get;set;}

        public ErrosViewModel(List<string> Mensagem){
            this.Mensagem = Mensagem;
        }
    }
}