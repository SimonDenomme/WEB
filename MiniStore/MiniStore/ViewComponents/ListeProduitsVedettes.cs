using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //public async Task<IViewComponentResult> InvokeAsync(
        //    DateTime? dueBefore = null,
        //    bool showCompleted = true,
        //    int minPriority = 0)
        //{
        //    var toDos = await _context.Todos
        //        .Where(toDo => (showCompleted || !toDo.IsDone) &&
        //                                    toDo.Priority >= minPriority &&
        //                                    (dueBefore == null || toDo.DueDate <= dueBefore))
        //        .ToListAsync();

        //    return View(toDos);
        //}



    }
}
