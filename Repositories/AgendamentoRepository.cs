using System.IO;

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
    }
}