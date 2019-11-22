using System;
using System.Collections.Generic;
using System.IO;

namespace RoleTOP_MVC.Repositories {
    public class ServicosAdicionaisRepository {
        public const string PATH = "Database/ServicosAdicionais.csv";

        public Dictionary<string, double> ObterTodos () {
            Dictionary<string, double> servicos = new Dictionary<string, double> ();
            string[] dados = File.ReadAllLines (PATH);

            foreach (string servico in dados) {
                string[] registro = servico.Split (";");
                string svc = registro[0];
                double preco = Convert.ToDouble (registro[1]);
                servicos.Add (svc, preco);
            }
            return servicos;
        }
        public double ObterPreco (string SvcAdicionais) {
            var servicos = ObterTodos ();
            double valor = 0;

            if (!string.IsNullOrEmpty (SvcAdicionais)) {
                string[] servico = new string[2];
                servico = SvcAdicionais.Split (",");
                string svc1 = servico[0];
                string svc2 = servico[1];

                if (servicos.ContainsKey (svc1)) {
                    valor += servicos[svc1];
                }
                if (servicos.ContainsKey (svc2)) {
                    valor += servicos[svc2];
                }
            }
            return valor;
        }
    }
}