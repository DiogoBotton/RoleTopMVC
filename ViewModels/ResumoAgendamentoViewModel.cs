using System;

namespace RoleTOP_MVC.ViewModels
{
    public class ResumoAgendamentoViewModel
    {
        public DateTime DataDoEvento {get;set;}
        public string SvcAdicionais {get;set;}
        public double PrecoTotal {get;set;}

        public ResumoAgendamentoViewModel(){

        }
        public ResumoAgendamentoViewModel(DateTime DataDoEvento, string SvcAdicionais, double PrecoTotal){
            this.DataDoEvento = DataDoEvento;
            this.SvcAdicionais = SvcAdicionais;
            this.PrecoTotal = PrecoTotal;
        }
    }
}