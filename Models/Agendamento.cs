using System;

namespace RoleTOP_MVC.Models
{
    public class Agendamento
    {
        public Cliente cliente {get;set;}
        public string NomeEvento {get;set;}
        public int QtdConvidados {get;set;}
        
        public DateTime DataDoPedido {get;set;}
        public double PrecoTotal {get;set;}
    }
}