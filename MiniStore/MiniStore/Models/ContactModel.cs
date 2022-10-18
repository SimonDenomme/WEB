using System.Collections;
using System.Collections.Generic;

namespace MiniStore.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public IEnumerable<string> Sujet  = new List<string>()
        //                                        { "Passer ou Modifier une commande",
        //                                          "Marketing et collaboration",
        //                                          "Press/Media",
        //                                          "Other"};
        public string Message { get; set; }
        public string Sujet { get; set; }
    }
}
