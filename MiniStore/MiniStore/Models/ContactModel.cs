using System;

namespace MiniStore.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Sujet { get; set; }
    }
}
