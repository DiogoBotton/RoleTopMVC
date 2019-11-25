using System.Collections.Generic;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.Cache
{
    public class MemoriaCache
    {
        public static Dictionary<string,Agendamento> memoriaAgendamento = new Dictionary<string, Agendamento>();
        public static Dictionary<string,Cliente> memoriaCliente = new Dictionary<string, Cliente>();
    }
}