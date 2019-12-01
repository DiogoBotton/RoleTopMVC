using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.ViewModels
{
    public class SuporteAdminViewModel : BaseViewModel
    {
        public Faq Faq {get;set;}

        public SuporteAdminViewModel(){
            this.Faq = new Faq();
        }
    }
}