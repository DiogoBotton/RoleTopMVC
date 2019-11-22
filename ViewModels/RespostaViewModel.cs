namespace RoleTOP_MVC.ViewModels
{
    public class RespostaViewModel
    {
        public string Mensagem {get;set;}

        public RespostaViewModel(){

        }
        public RespostaViewModel(string Mensagem){
            this.Mensagem = Mensagem;
        }
    }
}