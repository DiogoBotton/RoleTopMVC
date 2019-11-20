using System;
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

        public Agendamento ObterPor (string email) {
            string[] linhas = File.ReadAllLines (PATH);

            foreach (var linha in linhas) {
                if (ExtrairValorDoCampo ("email", linha).Equals (email)) {
                    Agendamento a = new Agendamento ();

                    a.NomeEvento = ExtrairValorDoCampo ("nome-evento", linha);
                    a.TipoEvento = ExtrairValorDoCampo ("tipo-evento", linha);
                    a.Privacidade = ExtrairValorDoCampo ("privacidade", linha);
                    a.QtdConvidados = ExtrairValorDoCampo ("qtd-convidados", linha);
                    a.DataDoEvento = Convert.ToDateTime(ExtrairValorDoCampo ("data-evento", linha));
                    a.DataDoAgendamento = Convert.ToDateTime(ExtrairValorDoCampo ("data-agendamento", linha));
                    a.DescricaoEvento = ExtrairValorDoCampo ("descricao-evento", linha);
                    a.SvcAdicionais = ExtrairValorDoCampo ("servicos-adicionais", linha);
                    a.FormaPagamento = ExtrairValorDoCampo ("forma-pagamento", linha);
                    a.PrecoTotal = Convert.ToDouble(ExtrairValorDoCampo ("preco-total", linha));
                    return a;
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
        public string PrepararRegistroCSV(Agendamento agendamento){
            return $"nome-evento={agendamento.NomeEvento};tipo-evento={agendamento.TipoEvento};privacidade={agendamento.Privacidade};qtd-convidados={agendamento.QtdConvidados};data-evento={agendamento.DataDoEvento};data-agendamento={agendamento.DataDoAgendamento};descricao-evento={agendamento.DescricaoEvento};servicos-adicionais={agendamento.SvcAdicionais};forma-pagamento={agendamento.FormaPagamento};preco-total={agendamento.PrecoTotal}";
        }
    }
}