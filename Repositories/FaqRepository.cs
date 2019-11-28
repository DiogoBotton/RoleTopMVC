using System;
using System.Collections.Generic;
using System.IO;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.Repositories {
    public class FaqRepository : BaseRepository {
        private const string PATH = "Database/DuvidasFAQ.csv";

        public FaqRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }
        public bool Inserir (Faq faq) {
            try {
                string[] registros = { PrepararRegistroCSV (faq) };
                File.AppendAllLines (PATH, registros);
                return true;
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return false;
            }
        }

        public List<Faq> ObterTodosPorEmail(string email){
            var mensagens = ObterTodos();
            List<Faq> perguntasUsuario = new List<Faq>();
            foreach (var msg in mensagens)
            {
                if(msg.Email.Equals(email)){
                    perguntasUsuario.Add(msg);
                }
            }
            return perguntasUsuario;
        }
        public List<Faq> ObterTodos () {
            string[] registros = File.ReadAllLines (PATH);
            List<Faq> mensagens = new List<Faq> ();
            foreach (var linha in registros) {
                Faq msg = new Faq ();
                msg.Nome = ExtrairValorDoCampo ("nome", linha);
                msg.Email = ExtrairValorDoCampo ("email", linha);
                msg.Mensagem = ExtrairValorDoCampo ("mensagem", linha);
                msg.DataDaMensagem = Convert.ToDateTime (ExtrairValorDoCampo ("data_mensagem", linha));
                msg.Status = uint.Parse (ExtrairValorDoCampo ("status_pergunta", linha));

                mensagens.Add (msg);
            }
            return mensagens;
        }

        private string PrepararRegistroCSV (Faq faq) {
            return $"nome={faq.Nome};email={faq.Email};mensagem={faq.Mensagem}data_mensagem={faq.DataDaMensagem};status_pergunta={faq.Status}";
        }
    }
}