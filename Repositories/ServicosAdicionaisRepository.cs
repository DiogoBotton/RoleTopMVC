using System.Collections.Generic;
using System.IO;
using System;

namespace RoleTopMVC.Repositories {
    public class ServicosAdicionaisRepository {
        public const string PATH = "Database/ServicosAdicionais.csv";

        public Dictionary<string, double> ObterTodos () {
            Dictionary<string,double> servicos = new Dictionary<string, double>();
            string[] dados = File.ReadAllLines (PATH);

            foreach (string servico in dados) {
                string[] registro = servico.Split (";");
                string svc = registro[0];
                double preco = Convert.ToDouble(registro[1]);
                servicos.Add(svc,preco);
            }
            return servicos;
        }
    }
}