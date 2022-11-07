namespace MiniStore.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string UserId { get; set; }
    }
}
