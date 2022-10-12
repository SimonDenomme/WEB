using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
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
            //var contactForm = await _context.Where(c => c.ContactFormId == 1).FirstOrDefaultAsync();
            return View();
        }
    }
}
