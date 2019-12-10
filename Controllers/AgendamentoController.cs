using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Enums;
using RoleTOP_MVC.Models;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class AgendamentoController : AbstractController {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository ();
        EventosRepository eventosRepository = new EventosRepository ();
        ServicosRepository servicosRepository = new ServicosRepository ();
        ClienteRepository clienteRepository = new ClienteRepository ();
        FormaPagamentoRepository pagamentoRepository = new FormaPagamentoRepository ();
        [HttpGet]
        public IActionResult Index () {
            AgendamentoViewModel avm = new AgendamentoViewModel ();
            avm.tipoEventos = eventosRepository.ObterTodos ();
            avm.servicos = servicosRepository.ObterTodos ();
            avm.formasPagamento = pagamentoRepository.ObterTodos ();

            var emailCliente = ObterUsuarioSession ();
            if (!string.IsNullOrEmpty (emailCliente)) {
                var usuario = clienteRepository.ObterPor (emailCliente);
                avm.Cliente = usuario;
            }

            //TempData vindo VAZIO.
            var erro = TempData["Agendamento"] as string;

            if (!string.IsNullOrEmpty (erro)) { //Se é nulo ou vazio, retorna booleano.
                List<string> erros = new List<string> ();
                erros.Add (erro);
                avm.Erros = erros;
                avm.NomeView = "Termos";
            } else {
                avm.NomeView = "Agendamento";
            }
            avm.UsuarioEmail = emailCliente;
            avm.UsuarioNome = ObterUsuarioNomeSession ();
            avm.UsuarioTipo = ObterUsuarioTipoSession ();
            return View (avm);
        }

        [HttpPost]
        public IActionResult Registrar (IFormCollection form) {
            //Conversão int para ENUM.
            //TODO o que acontece quando tenta converter numero ENUM que não existe.
            int privacidadeEnum;
            bool converteu = int.TryParse (form["privacidade"], out privacidadeEnum);
            PrivacidadeEnum privacidade;
            //Método mais pratico (fazer com dicionário)
            if (converteu) {
                switch (privacidadeEnum) {
                    case 0:
                        privacidade = (PrivacidadeEnum) PrivacidadeEnum.PRIVADO;
                        break;
                    case 1:
                        privacidade = (PrivacidadeEnum) PrivacidadeEnum.PUBLICO;
                        break;
                    default:
                        TempData["Agendamento"] = "Houve um erro na efetuação do Agendamento.";
                        return RedirectToAction ("Index", "Agendamento");
                }
            } else {
                privacidade = (PrivacidadeEnum) PrivacidadeEnum.PRIVADO; //Padrão PRIVADO.
            }

            Cliente c = new Cliente () {
                Nome = form["nome"],
                Email = form["email"],
                CEP = form["cep"],
                CPF = form["cpf"],
                Tel = form["telefone"]
            };

            string SvcAdicionais = form["sv-adc"];
            double SvcPreco = servicosRepository.ObterPrecoTotal (SvcAdicionais);
            if (string.IsNullOrEmpty (SvcAdicionais)) {
                SvcAdicionais = "NENHUM";
            }
            bool PagamentoValido = pagamentoRepository.VerificarMetodoPagamento (form["pagamento"]);
            if (!PagamentoValido) {
                TempData["Agendamento"] = "Método de pagamento inválido, tente novamente.";
                return RedirectToAction ("Index", "Agendamento");
            }
            Agendamento a = new Agendamento ();
            a.Cliente = c;
            a.NomeEvento = form["nome-evento"];
            a.TipoEvento = form["evento"];
            a.Privacidade = privacidade.ToString ();
            a.QtdConvidados = form["qtd-convidados"];
            a.DataDoEvento = Convert.ToDateTime (form["data-evento"]);
            a.DataDoAgendamento = DateTime.Now.ToShortDateString ();
            a.SvcAdicionais = SvcAdicionais;
            a.DescricaoEvento = form["descricao-evento"];
            a.FormaPagamento = form["pagamento"];
            a.PrecoTotal = SvcPreco;
            a.StatusString = StatusAgendamentoEnum.PENDENTE.ToString ();
            //TODO FEITO: BANNER (IMG) \/

            if (form.Files.Any ()) {
                var agendamentoID = agendamentoRepository.ObterNextID ();
                string urlBanner = $"wwwroot\\{PATH_BANNER}\\{c.Email}\\{agendamentoID}\\";
                GravarImagem (form.Files, urlBanner);
                a.bannerURL = urlBanner;
            } else {
                a.bannerURL = $"wwwroot\\{PATH_BANNER}\\banner_padrao\\";
            }

            bool termos = form["termos"] == "1";
            if (termos) {

                if (agendamentoRepository.Inserir (a)) {
                    // Manda para uma outra página específica com informações (Resumo) da compra.
                    return View ("_AgendamentoRealizado", new ResumoAgendamentoViewModel (a.DataDoEvento, a.SvcAdicionais, a.PrecoTotal) {
                        NomeView = "Agendamento",
                            UsuarioEmail = ObterUsuarioSession (),
                            UsuarioNome = ObterUsuarioNomeSession (),
                            UsuarioTipo = ObterUsuarioTipoSession ()
                    });
                } else {
                    TempData["Agendamento"] = "Houve um erro na efetuação do agendamento. Tente novamente mais tarde.";
                    return RedirectToAction ("Index", "Agendamento");
                }
            } else {
                TempData["Agendamento"] = "Você precisa aceitar os termos de uso.";
                return RedirectToAction ("Index", "Agendamento");
            }
        }

        private async void GravarImagem (IFormFileCollection arquivos, string urlImagem) { //Métodos async fazem com que o programa não precise de esperar este método terminar de ser executado para dar continuidade a execução do programa.
            foreach (var img in arquivos) {
                System.IO.Directory.CreateDirectory (urlImagem).Create ();
                var file = System.IO.File.Create (urlImagem + img.FileName); // caminho: urlImagem\\Nome do arquivo.
                await img.CopyToAsync (file);
                file.Close ();
            }
        }

        public IActionResult Visualizar (ulong id) {
            InfoEventoViewModel ivm = new InfoEventoViewModel ();
            var agendamento = agendamentoRepository.ObterPor (id);
            if (agendamento != null) {
                var urlBanner = Directory.GetFiles (agendamento.bannerURL).FirstOrDefault ();
                var urlBannerTratado = urlBanner.Replace ("\\", "/").Replace ("wwwroot", "");

                ivm.url_banner = urlBannerTratado;
                ivm.evento = agendamento;
                ivm.UsuarioEmail = ObterUsuarioSession ();
                ivm.UsuarioNome = ObterUsuarioNomeSession ();
                ivm.UsuarioTipo = ObterUsuarioTipoSession ();
                return View ("_InfoEvento", ivm);
            }
            return RedirectToAction ("Index", "Administrador");
        }
        public IActionResult Aprovar (ulong id) {
            var agendamento = agendamentoRepository.ObterPor (id);
            agendamento.Status = (uint) StatusAgendamentoEnum.APROVADO;
            agendamento.StatusString = StatusAgendamentoEnum.APROVADO.ToString ();

            if (agendamentoRepository.Atualizar (agendamento)) {
                SendEmail se = new SendEmail ();
                se.Email = agendamento.Cliente.Email;
                se.Status = agendamento.StatusString;
                return RedirectToAction ("NotificacaoUsuarioEmail", "Administrador", se);
            }
            return RedirectToAction ("Index", "Administrador");
        }
        public IActionResult Recusar (ulong id) {
            var agendamento = agendamentoRepository.ObterPor (id);
            agendamento.Status = (uint) StatusAgendamentoEnum.REPROVADO;
            agendamento.StatusString = StatusAgendamentoEnum.REPROVADO.ToString ();

            if (agendamentoRepository.Atualizar (agendamento)) {
                SendEmail se = new SendEmail ();
                se.Email = agendamento.Cliente.Email;
                se.Status = agendamento.StatusString;
                return RedirectToAction ("NotificacaoUsuarioEmail", "Administrador", se);
            }
            return RedirectToAction ("Index", "Administrador");
        }
        public IActionResult Cancelar (ulong id) {
            var agendamento = agendamentoRepository.ObterPor (id);
            agendamento.Status = (uint) StatusAgendamentoEnum.CANCELADO;
            agendamento.StatusString = StatusAgendamentoEnum.CANCELADO.ToString ();

            if (agendamentoRepository.Atualizar (agendamento)) {
                return RedirectToAction ("Usuario", "Cliente");
            }
            return RedirectToAction ("Usuario", "Cliente");
        }
    }
}