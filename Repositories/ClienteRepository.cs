using System.Collections.Generic;
using System.IO;
using RoleTOP_MVC.Models;
using System.Linq;
using RoleTOP_MVC.Enums;

namespace RoleTOP_MVC.Repositories {
    public class ClienteRepository : BaseRepository {
        public const string PATH = "Database/Cliente.csv"; //PATH: Caminho (diretório do arquivo).

        public ClienteRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
                Cliente c = new Cliente(){
                    TipoUsuario = (uint) TipoClienteEnum.ADMINISTRADOR,
                    Nome = "Admin",
                    Email = "admin@email.com",
                    Senha = "admin",
                };
                Inserir(c);
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

        public bool Remover(string email){
            string[] registros = File.ReadAllLines(PATH);

            List<string> clientes = registros.OfType<string>().ToList(); //Converte vetor de string para uma LISTA de string.
            bool removeu = true;
            foreach (var linha in clientes)
            {
                if(ExtrairValorDoCampo("email", linha).Equals(email)){
                    clientes.Remove(linha);
                    removeu = true;
                    break;
                }
                else{
                    removeu = false;
                }
            }
            File.WriteAllLines(PATH,clientes);
            return removeu;
        }
        public Cliente ObterPor (string email) {
            string[] linhas = File.ReadAllLines (PATH);

            foreach (var linha in linhas) {
                if (ExtrairValorDoCampo ("email", linha).Equals (email)) {
                    Cliente c = new Cliente ();
                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_cliente",linha));
                    c.Nome = ExtrairValorDoCampo ("nome", linha);
                    c.Email = ExtrairValorDoCampo ("email", linha);
                    c.Senha = ExtrairValorDoCampo ("senha", linha);
                    c.CEP = ExtrairValorDoCampo ("cep", linha);
                    c.Tel = ExtrairValorDoCampo ("telefone", linha);
                    c.CPF = ExtrairValorDoCampo ("cpf", linha);
                    return c;
                }
            }
            return null;
        }
        private string PrepararRegistroCSV (Cliente cliente) {
            return $"tipo_cliente={cliente.TipoUsuario};nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};cep={cliente.CEP};cpf={cliente.CPF};telefone={cliente.Tel}";
        }
    }
}