using RoleTOP_MVC.Models;
using System.IO;
namespace RoleTOP_MVC.Repositories
{
    public class ClienteRepository
    {
        public const string PATH = "Database/Cliente.csv"; //PATH: Caminho (diretório do arquivo).

        public ClienteRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Cliente cliente){
            try
            {
                string[] dadosCliente = {PrepararRegistroCSV(cliente)};
                File.AppendAllLines(PATH,dadosCliente);
                return true;
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        private string PrepararRegistroCSV(Cliente cliente){
            return $"nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};cep={cliente.CEP};cpf-cnpj={cliente.CPF_CNPJ};telefone={cliente.Tel};";
        }
    }
}