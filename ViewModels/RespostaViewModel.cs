namespace RoleTOP_MVC.ViewModels
{
    public class RespostaViewModel : BaseViewModel
    {
        public string Mensagem {get;set;}

        public RespostaViewModel(){

        }
        public RespostaViewModel(string Mensagem){
            this.Mensagem = Mensagem;
        }
    }
}