using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MiniStore.Data;

namespace MiniStore.ViewComponents
{
    public class ContactForm : ViewComponent
    {
        private readonly MiniStoreContext _context;
        

        public ContactForm(MiniStoreContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
