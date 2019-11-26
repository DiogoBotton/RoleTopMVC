using System.Collections.Generic;

namespace RoleTOP_MVC.ViewModels
{
    public class ErrosViewModel : BaseViewModel
    {
        public List<string> Mensagem {get;set;}

        public ErrosViewModel(List<string> Mensagem){
            this.Mensagem = Mensagem;
        }
        public ErrosViewModel(){
            this.Mensagem = new List<string>();
        }
    }
}