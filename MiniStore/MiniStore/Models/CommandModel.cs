using MiniStore.Domain;

namespace MiniStore.Models
{
    public class CommandModel
    {
        public int Id { get; set; }

        public Cart Cart { get; set; }
        //public CartViewModel CVM { get; set; }
    }
}
