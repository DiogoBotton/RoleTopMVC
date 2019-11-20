using System.Collections.Generic;

namespace RoleTOP_MVC.ViewModels
{
    public class RespostaViewModel
    {
        public List<string> Mensagem {get;set;}

        public RespostaViewModel(List<string> Mensagem){
            this.Mensagem = Mensagem;
        }
    }
}