using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using System.Threading.Tasks;

namespace MiniStore.ViewComponents
{
    public class ListeProduitsVedettes : ViewComponent
    {
        private readonly MiniStoreContext _context;

        public ListeProduitsVedettes(MiniStoreContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
