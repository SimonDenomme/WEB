namespace MiniStore.Entity
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte Rating { get; set; }
        public string Text { get; set; }

        public Mini Mini { get; set; }
        public int MiniId { get; set; }
    }
}
