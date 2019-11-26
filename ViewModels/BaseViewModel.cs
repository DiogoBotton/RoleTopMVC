using System.Collections.Generic;

namespace RoleTOP_MVC.ViewModels
{
    public class BaseViewModel
    {
        public string NomeView {get;set;}
        public string UsuarioEmail {get;set;}
        public string UsuarioNome {get;set;}
        public List<string> Mensagem {get;set;}

        public BaseViewModel(){
            this.Mensagem = new List<string>();
        }
    }
}