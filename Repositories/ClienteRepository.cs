using System.IO;
using RoleTOP_MVC.Models;
using RoleTopMVC.Repositories;

namespace RoleTOP_MVC.Repositories {
    public class ClienteRepository : BaseRepository {
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
        private string PrepararRegistroCSV (Cliente cliente) {
            return $"nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};cep={cliente.CEP};cpf-cnpj={cliente.CPF_CNPJ};telefone={cliente.Tel}";
        }
    }
}