using System;

namespace RoleTOP_MVC.Models
{
    public class Agendamento
    {
        public Cliente Cliente {get;set;}
        public string NomeEvento {get;set;}
        public string TipoEvento {get;set;}
        public string Privacidade {get;set;}
        public string QtdConvidados {get;set;}
        public DateTime DataDoEvento {get;set;}
        public DateTime DataDoAgendamento {get;set;}
        public string DescricaoEvento {get;set;}
        public string SvcAdicionais {get;set;}
        public string FormaPagamento {get;set;}
        public double PrecoTotal {get;set;}
        //TODO Forma para armazenar imagem (banner do evento)

        public Agendamento(){
            this.Cliente = new Cliente();
        }
        public Agendamento(Cliente cliente, string NomeEvento, string TipoEvento, string Privacidade, string QtdConvidados, DateTime DataDoEvento, string DescricaoEvento, string SvcAdicionais, string FormaPagamento){
            this.Cliente = cliente;
            this.NomeEvento = NomeEvento;
            this.TipoEvento = TipoEvento;
            this.Privacidade = Privacidade;
            this.QtdConvidados = QtdConvidados;
            this.DataDoEvento = DataDoEvento;
            this.DescricaoEvento = DescricaoEvento;
            this.SvcAdicionais = SvcAdicionais;
            this.FormaPagamento = FormaPagamento;
        }
    }
}