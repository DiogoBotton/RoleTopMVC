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
                var numPerguntas = File.ReadAllLines(PATH).Length;
                faq.ID = (ulong) numPerguntas++;

                string[] registros = { PrepararRegistroCSV (faq) };
                File.AppendAllLines (PATH, registros);
                return true;
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return false;
            }
        }
        public Faq ObterPor(ulong id){
            var mensagens = ObterTodos();
            foreach (var msg in mensagens)
            {
                if(msg.ID.Equals(id)){
                    return msg;
                }
            }
            return null;
        }
        public bool Atualizar(Faq faq){
            var registros = File.ReadAllLines(PATH);
            var FaqCSV = PrepararRegistroCSV(faq);
            int indice = -1;
            bool idEncontrado = false;

            for (int i = 0; i < registros.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("id",registros[i]));
                if(faq.ID.Equals(idConvertido)){
                    indice = i;
                    idEncontrado = true;
                    break;
                }
            }

            if(idEncontrado){
                registros[indice] = FaqCSV;
                File.WriteAllLines(PATH, registros);
                return true;
            }
            return false;
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
                msg.ID = ulong.Parse(ExtrairValorDoCampo ("id", linha));
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
            return $"id={faq.ID};nome={faq.Nome};email={faq.Email};mensagem={faq.Mensagem};data_mensagem={faq.DataDaMensagem};status_pergunta={faq.Status}";
        }
    }
}