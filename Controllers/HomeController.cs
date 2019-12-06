﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Repositories;
using RoleTOP_MVC.ViewModels;

namespace RoleTOP_MVC.Controllers {
    public class HomeController : AbstractController {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        public IActionResult Index () {
            //ViewData["NomeView"] = "Home";
            var proxEventos = agendamentoRepository.ObterPorStatusAprovado();
            foreach (var evento in proxEventos)
            {
                var url_Banner = Directory.GetFiles(evento.bannerURL).FirstOrDefault();
                var url_BannerTratado = url_Banner.Replace("\\","/").Replace("wwwroot","");

                evento.bannerURL = url_BannerTratado;
            }
            return View (new HomeViewModel() {
                NomeView = "Home",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession (),
                    UsuarioTipo = ObterUsuarioTipoSession(),
                    Programacao = proxEventos
            });
        }
        public IActionResult Visualizar(ulong id){
            var evento = agendamentoRepository.ObterPor(id);
            //TODO Fazer pagina de evento publico.
            return View();
        }
        public IActionResult Estrutura () {
            return View (new BaseViewModel () {
                NomeView = "Estrutura",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession (),
                    UsuarioTipo = ObterUsuarioTipoSession()
            });
        }
    }
}