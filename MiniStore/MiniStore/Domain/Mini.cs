using System.Collections.Generic;

namespace MiniStore.Domain
{
    public class Mini
    {
        public int Id { get; set; }                 // Pour la BD
        public string Name { get; set; }            // Données d'affichage et de recherche pour le filtre par SearchBar
        public string Description { get; set; }     // Données d'affichage et une forme de recherche pour le filtre par la SearchBar (SI ON A LE TEMPS!!)
        public string ImagePath { get; set; }       // Données vital pour l'affichage
        public bool IsPainted { get; set; }         // Paramètre de tri et de filtre sur l'item
        public bool IsLuminous { get; set; }        // Paramètre de tri et de filtre sur l'item
        public int QtyInventory { get; set; }       // Permet la gestion des Statuts par le site

        public double NormalPrice { get; set; }     // Prix d'origine de vente avant rabais
        public double ReducedPrice { get; set; }    // Va permettre de jouer avec les prix un tout peit peu

        public bool IsFrontPage { get; set; }       // Va permettre de le mettre sur la page d'acceuil en un seul clic et généralisera son affichage
        public int QtySold { get; set; }            // Va permettre d'avoir le most sold comme tri, et aussi de savoir si un produit est en rupture de stock

        public int CategoryId { get; set; }         // Foreign Key pour la table Category
        public Category Category { get; set; }      // Navigation property de la table Category
        public int SizeId { get; set; }             // Id de la table de size
        public Size Size { get; set; }              // Va permettre d'avoir une données en string sans que ce soit en des termes variables
        public List<Review> Reviews { get; set; }   // Tous les notes qui sont données au mini en particulier
        public int StatusId { get; set; }           // Foreign Key pour la table des status possible pour la mini
        public Status Status { get; set; }          // Navigation property pour la table des status
    }
}
