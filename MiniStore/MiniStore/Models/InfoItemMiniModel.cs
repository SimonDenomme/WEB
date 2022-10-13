using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniStore.Entity;

namespace MiniStore.Models
{
    public record MinisDetails(int Id, string Description, 
                List<Review> Reviews, int StatisId, 
                ProduitDetails Minis);
    public record MinisNotList(params MinisDetails[] MinisDetails);
    public class InfoItemMiniModel
    {
        public int Id { get; set; }
        public string Description { get; set; }     // Données d'affichage et une forme de recherche pour le filtre par la SearchBar (SI ON A LE TEMPS!!)
        public List<Review> Reviews { get; set; }   // Tous les notes qui sont données au mini en particulier
        public int StatusId { get; set; }           // Foreign Key pour la table des status possible pour la mini


        public ProduitDetails Minis { get; set; }
    }
}
