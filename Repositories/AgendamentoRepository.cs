using System.IO;
using RoleTOP_MVC.Models;

namespace RoleTopMVC.Repositories
{
    public class AgendamentoRepository
    {
        private const string PATH = "Database/Agendamento.csv";

        public AgendamentoRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }
        public bool Inserir(Agendamento agendamento){
            try
            {
                string[] registros = {PrepararRegistroCSV(agendamento)};
                File.AppendAllLines(PATH,registros);
                return true;
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return false;
            }
        }
        public string PrepararRegistroCSV(Agendamento agendamento){
            return $"nome-evento={agendamento.NomeEvento};tipo-evento={agendamento.TipoEvento};privacidade={agendamento.Privacidade};qtd-convidados={agendamento.QtdConvidados};data-evento={agendamento.DataDoEvento};descricao-evento={agendamento.DescricaoEvento};servicos-adicionais={agendamento.SvcAdicionais};forma-pagamento={agendamento.FormaPagamento};preco-total={agendamento.PrecoTotal};";
        }
    }
}