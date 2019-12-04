using System.Collections.Generic;
using System.IO;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.Repositories {
    public class FormaPagamentoRepository {
        private const string PATH = "Database/FormasPagamento.csv";

        public FormaPagamentoRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }

        public List<FormaPagamento> ObterTodos () {
            List<FormaPagamento> pgmt = new List<FormaPagamento> ();
            var registros = File.ReadAllLines (PATH);

            foreach (var linha in registros) {
                FormaPagamento fp = new FormaPagamento ();
                var formaPagamento = linha.Split (";");
                for (int i = 0; i < formaPagamento.Length; i++)
                {
                    fp.Nome = formaPagamento[0];
                    fp.classORdir = formaPagamento[1];
                }
                pgmt.Add(fp);
            }
        return pgmt;
        }
    }
}