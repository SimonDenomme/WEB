using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Models
{
    public enum _OrderBy { AtoZ, ZtoA, PriceUp, PriceDown }
    public class indexViewModel
    {
        public bool IsPainted { get; set; }
        public bool IsLuminous { get; set; }
        public double MinPrice { get; set; } = 0D;
        public double MaxPrice { get; set; } = 1000D;
        public int StatusId { get; set; } = 1;
        public bool IsFiltered { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 30;
        public int PageIndex { get; set; } = 1;
        public _OrderBy OrderBy { get; set; }
    }
}
