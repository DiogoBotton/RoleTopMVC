using System.Collections.Generic;
using System.IO;

namespace RoleTOP_MVC.Repositories
{
    public class EventosRepository
    {
        public const string PATH = "Database/Eventos.csv";

        public List<string> ObterTodos(){
            List<string> listaEventos = new List<string>();
            string[] dados = File.ReadAllLines(PATH);
            foreach (string evento in dados)
            {
                listaEventos.Add(evento);
            }
            return listaEventos;
        }
    }
}