using System;
namespace RoleTOP_MVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public string CEP {get;set;}
        public string CPF {get;set;}
        public string Tel {get;set;}
        
        public Cliente(){
        
        }
        
        public Cliente(string nome, string email, string senha, string cep, string cpf, string tel){
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.CEP = cep;
            this.CPF = cpf;
            this.Tel = tel;
        }

    }
}