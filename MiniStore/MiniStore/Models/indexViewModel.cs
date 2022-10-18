using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniStore.Entity;

namespace MiniStore.Models
{
    public enum _OrderBy { AtoZ, ZtoA, PriceUp, PriceDown }
    //public enum _FilterBy { All, Painted, Luminous, Status, Research }
    public class indexViewModel
    {
        public bool IsPainted { get; set; } = false;
        public bool IsLuminous { get; set; } = false;
        public bool FiltreA { get; set; } = false;

        public double MinPrice { get; set; } = 0D;
        public double MaxPrice { get; set; } = 1000D;
        public bool FiltreB { get; set; } = false;

        public _OrderBy OrderBy { get; set; }

        public int StatusId { get; set; } = 1;
        public bool FiltreC { get; set; } = false;

        public bool IsFiltered { get; set; } = false;

        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 30;
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public virtual Status Status { get; set; }

        //public _FilterBy filtres { get; set; }
        public string Filtre { get; set; }              // Filtre avec l'élément passé, donne une genre de recherche avancé (#luminous, #painted, #status, Mini 1)
    }
}
