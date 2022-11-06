using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MiniStore.ViewModels.Adresse
{
    public class AdresseViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Street Number")]
        public int AddressNumber { get; set; }
        [Required]
        [Display(Name = "Street Name")]
        public string AddressStreet { get; set; }
        [Required]
        [Display(Name = "City")]
        public string AddressCity { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string AddressPostalCode { get; set; }
    }
}
