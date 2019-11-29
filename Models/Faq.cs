using System;
using System.Collections.Generic;
using RoleTOP_MVC.Enums;

namespace RoleTOP_MVC.Models {
    public class Faq {
        public uint Status {get;set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataDaMensagem { get; set; }
        public int NumeroMensagens {get;set;}

        public Faq () {
            this.DataDaMensagem = DateTime.Now;
            this.Status = (uint) StatusPerguntaEnum.NAO_LIDA;
        }
        public Faq (string Nome, string Email, string Mensagem) {
            this.Nome = Nome;
            this.Email = Email;
            this.Mensagem = Mensagem;
            this.DataDaMensagem = DateTime.Now;
            this.Status = (uint) StatusPerguntaEnum.NAO_LIDA;
        }
    }
}