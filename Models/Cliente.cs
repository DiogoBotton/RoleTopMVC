using RoleTOP_MVC.Enums;
namespace RoleTOP_MVC.Models
{
    public class Cliente
    {
        public ulong ID;
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public string CEP {get;set;}
        public string CPF_CNPJ {get;set;}
        public string Tel {get;set;}
        public uint TipoCliente {get;set;}

        public Cliente(){
        
        }

    }
}