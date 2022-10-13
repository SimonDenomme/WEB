using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MiniStore.Entity;

namespace MiniStore.Models
{
    public class Minis
    {
        [ForeignKey("Mini")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double NormalPrice { get; set; }
        public double ReducedPrice { get; set; }

        public Mini Mini { get; set; }
    }
}
