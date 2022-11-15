using System.Collections.Generic;

namespace MiniStore.Domain
{
    public class Category
    {
        // C'EST TECHNIQUEMENT UN ENUM MODIFIABLE
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Mini> Minis { get; set; }   // Navigation Property pour la table Mini
    }
}
