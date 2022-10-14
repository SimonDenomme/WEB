using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Models
{
    public class indexViewModel
    {
        public bool IsPainted { get; set; }
        public bool IsLuminous { get; set; }
        public bool IsFiltered { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 30;
        public int PageIndex { get; set; } = 1;
        public string OrderBy { get; set; }
    }
}
