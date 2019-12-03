using System;
using System.Collections.Generic;
using System.IO;

namespace RoleTOP_MVC.Repositories {
    public class ServicosRepository {
        public const string PATH = "Database/ServicosAdicionais.csv";
        public const string PATH_ORCAMENTO = "Database/OrcamentoPadrao.csv";

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
        public double ObterPrecoTotal (string SvcAdicionais) {
            var servicos = ObterTodos ();
            string[] precoOrcamento = File.ReadAllLines (PATH_ORCAMENTO);
            double valor = 0;

            if (!string.IsNullOrEmpty (SvcAdicionais)) {
                string[] servico = SvcAdicionais.Split (",");

                for (int i = 0; i < servico.Length; i++) {
                    string svc = servico[i];
                    if (servicos.ContainsKey (svc)) {
                        valor += servicos[svc];
                    }
                }
            }
            double Orcamento = 0;
            bool converteu = double.TryParse (precoOrcamento[0], out Orcamento);
            if (converteu) {
                valor += Orcamento;
            }
            else{
                valor += 10000;
            }
            return valor;
        }
    }
}