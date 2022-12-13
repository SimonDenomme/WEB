using System;

namespace MiniStore.Domain
{
    public class Bill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CreditCard { get; set; }
        public DateTime Date { get; set; }
        public Guid CommandId { get; set; }
    }
}
