using System.IO;
using RoleTOP_MVC.Models;
namespace RoleTOP_MVC.Repositories {
    public class ClienteRepository {
        public const string PATH = "Database/Cliente.csv"; //PATH: Caminho (diretório do arquivo).

        public ClienteRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }

        public bool Inserir (Cliente cliente) {
            try {
                string[] dadosCliente = { PrepararRegistroCSV (cliente) };
                File.AppendAllLines (PATH, dadosCliente);
                return true;
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return false;
            }
        }

        public Cliente ObterPor (string email) {
            string[] linhas = File.ReadAllLines (PATH);

            foreach (var linha in linhas) {
                if (ExtrairValorDoCampo ("email", linha).Equals (email)) {
                    Cliente c = new Cliente ();

                    c.Nome = ExtrairValorDoCampo ("nome", linha);
                    c.Email = ExtrairValorDoCampo ("email", linha);
                    c.Senha = ExtrairValorDoCampo ("senha", linha);
                    c.CEP = ExtrairValorDoCampo ("cep", linha);
                    c.Tel = ExtrairValorDoCampo ("telefone", linha);
                    c.CPF_CNPJ = ExtrairValorDoCampo ("cpf-cnpj", linha);
                    return c;
                }
            }
            return null;
        }
        private string ExtrairValorDoCampo (string nomeCampo, string linha) {
            var chave = nomeCampo;

            var indiceChave = linha.IndexOf (chave);
            var indiceTerminal = linha.IndexOf (";", indiceChave); //IndexOf sempre retorna o indice do ultimo caracter da string.

            var valor = "";
            //IndexOf retorna -1 caso não encontre o valor de string.
            if (indiceTerminal != -1) { //Caso for diferente de -1, primeiro parametro startIndex, segundo EndIndex.
                valor = linha.Substring (indiceChave, indiceTerminal - indiceChave);
            } else {
                valor = linha.Substring (indiceChave); //caso for igual á -1, unico parametro startIndex até o final da string.
            }
            System.Console.WriteLine ($"Campo {nomeCampo} e valor {valor}");
            return valor.Replace (nomeCampo + "=", "");
        }

        private string PrepararRegistroCSV (Cliente cliente) {
            return $"nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};cep={cliente.CEP};cpf-cnpj={cliente.CPF_CNPJ};telefone={cliente.Tel}";
        }
    }
}