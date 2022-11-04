namespace MiniStore.Domain
{
    public class Message
    {
        public int Id { get; set; }         // Pour la BD
        public string Name { get; set; }    // Le nom de la personne à contacter
        public string Email { get; set; }   // L'adresse courriel de la personne à contacter
        public string Text { get; set; }    // Le message de la personne à contacter
    }
}
