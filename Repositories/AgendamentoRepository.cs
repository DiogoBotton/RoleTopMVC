using System;
using System.Collections.Generic;
using System.IO;
using RoleTOP_MVC.Enums;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.Repositories {
    public class AgendamentoRepository : BaseRepository {
        private const string PATH = "Database/Agendamento.csv";

        public AgendamentoRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }
        public ulong ObterNextID () {
            var numPedidos = File.ReadAllLines (PATH).Length;
            ulong ID = (ulong) numPedidos++;
            return ID;
        }
        public bool Inserir (Agendamento agendamento) {
            try {
                var numPedidos = File.ReadAllLines (PATH).Length; //Ao inserir um pedido, é dado o tamanho do array +1 para o agendamento, que seria o seu ID.
                agendamento.ID = (ulong) numPedidos++;

                string[] registros = { PrepararRegistroCSV (agendamento) };
                File.AppendAllLines (PATH, registros);
                return true;
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return false;
            }
        }
        public List<Agendamento> ObterTodosPorCliente (string emailCliente) {
            string[] linhas = File.ReadAllLines (PATH);
            List<Agendamento> agendamentosCliente = new List<Agendamento> ();
            var pedidos = ObterTodos ();
            foreach (var pedido in pedidos) {
                if (pedido.Cliente.Email.Equals (emailCliente)) {
                    agendamentosCliente.Add (pedido);
                }
            }
            return agendamentosCliente;
        }
        public bool Atualizar (Agendamento agendamento) {
            var registros = File.ReadAllLines (PATH);
            var AgendamentoCSV = PrepararRegistroCSV (agendamento);
            int indice = -1;
            bool idEncontrado = false;

            for (int i = 0; i < registros.Length; i++) {
                var idConvertido = ulong.Parse (ExtrairValorDoCampo ("id", registros[i]));
                if (agendamento.ID.Equals (idConvertido)) {
                    indice = i;
                    idEncontrado = true;
                    break;
                }
            }

            if (idEncontrado) {
                registros[indice] = AgendamentoCSV;
                File.WriteAllLines (PATH, registros);
                return true;
            }
            return false;
        }
        public Agendamento ObterPor (ulong id) {
            var eventos = ObterTodos ();
            foreach (var evento in eventos) {
                if (evento.ID.Equals (id)) {
                    return evento;
                }
            }
            return null;
        }
        public List<Agendamento> ObterPorStatusAprovado(){
            var lista = ObterTodos();
            List<Agendamento> aprovados = new List<Agendamento>();
            foreach (var item in lista)
            {
                if(item.Status.Equals((uint) StatusAgendamentoEnum.APROVADO) && item.Privacidade.Equals(PrivacidadeEnum.PUBLICO.ToString())){
                    aprovados.Add(item);
                }
            }
        return aprovados;
        }
        public List<Agendamento> ObterTodos () {
            string[] linhas = File.ReadAllLines (PATH);
            List<Agendamento> agendamentos = new List<Agendamento> ();
            foreach (var linha in linhas) {
                Agendamento a = new Agendamento ();

                a.ID = ulong.Parse (ExtrairValorDoCampo ("id", linha));
                a.Status = uint.Parse (ExtrairValorDoCampo ("status_agendamento", linha));
                a.StatusString = ExtrairValorDoCampo ("status_string", linha);
                a.Cliente.Nome = ExtrairValorDoCampo ("cliente_nome", linha);
                a.Cliente.Email = ExtrairValorDoCampo ("cliente_email", linha);
                a.Cliente.CEP = ExtrairValorDoCampo ("cliente_cep", linha);
                a.Cliente.CPF = ExtrairValorDoCampo ("cliente_cpf", linha);
                a.Cliente.Tel = ExtrairValorDoCampo ("cliente_telefone", linha);
                a.NomeEvento = ExtrairValorDoCampo ("nome-evento", linha);
                a.TipoEvento = ExtrairValorDoCampo ("tipo-evento", linha);
                a.Privacidade = ExtrairValorDoCampo ("privacidade", linha);
                a.QtdConvidados = ExtrairValorDoCampo ("qtd-convidados", linha);
                a.DataDoEvento = Convert.ToDateTime (ExtrairValorDoCampo ("data-evento", linha));
                a.bannerURL = ExtrairValorDoCampo ("banner-url", linha);
                a.DataDoAgendamento = ExtrairValorDoCampo ("data-agendamento", linha);
                a.DescricaoEvento = ExtrairValorDoCampo ("descricao-evento", linha);
                a.SvcAdicionais = ExtrairValorDoCampo ("servicos-adicionais", linha);
                a.FormaPagamento = ExtrairValorDoCampo ("forma-pagamento", linha);
                a.PrecoTotal = Convert.ToDouble (ExtrairValorDoCampo ("preco-total", linha));
                agendamentos.Add (a);
            }
            return agendamentos;
        }
        private string PrepararRegistroCSV (Agendamento agendamento) {
            Cliente c = agendamento.Cliente;
            return $"id={agendamento.ID};status_agendamento={agendamento.Status};status_string={agendamento.StatusString};cliente_nome={c.Nome};cliente_email={c.Email};cliente_cep={c.CEP};cliente_cpf={c.CPF};cliente_telefone={c.Tel};nome-evento={agendamento.NomeEvento};tipo-evento={agendamento.TipoEvento};privacidade={agendamento.Privacidade};qtd-convidados={agendamento.QtdConvidados};data-evento={agendamento.DataDoEvento};data-agendamento={agendamento.DataDoAgendamento};descricao-evento={agendamento.DescricaoEvento};banner-url={agendamento.bannerURL};servicos-adicionais={agendamento.SvcAdicionais};forma-pagamento={agendamento.FormaPagamento};preco-total={agendamento.PrecoTotal}";
        }
    }
}