using System;
using System.IO;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.Repositories
{
    public class FaqRepository
    {
        private const string PATH = "Database/DuvidasFAQ.csv";

        public FaqRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }
        public bool Inserir(Faq faq){
            try
            {
                string[] registros = {PrepararRegistroCSV(faq)};
                File.AppendAllLines(PATH,registros);
                return true;
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        private string PrepararRegistroCSV(Faq faq)
        {
            return $"nome={faq.Nome};email={faq.Email};mensagem={faq.Mensagem}";
        }
    }
}