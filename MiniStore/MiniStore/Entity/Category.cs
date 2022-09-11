using System.Collections.Generic;

namespace MiniStore.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Mini> Minis { get; set; }
    }
}
