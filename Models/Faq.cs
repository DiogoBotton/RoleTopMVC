namespace RoleTopMVC.Models
{
    public class Faq
    {
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Mensagem {get;set;}

        public Faq(){

        }
        public Faq(string Nome, string Email, string Mensagem){
            this.Nome = Nome;
            this.Email = Email;
            this.Mensagem = Mensagem;
        } 
    }
}