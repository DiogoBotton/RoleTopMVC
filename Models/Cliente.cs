using System;
using RoleTOP_MVC.Enums;
namespace RoleTOP_MVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public string CEP {get;set;}
        public string CPF_CNPJ {get;set;}
        public string Tel {get;set;}
        
        public Cliente(){
        
        }
        
        public Cliente(string nome, string email, string senha, string cep, string cpf_cnpj, string tel){
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.CEP = cep;
            this.CPF_CNPJ = cpf_cnpj;
            this.Tel = tel;
        }

    }
}