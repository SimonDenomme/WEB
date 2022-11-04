namespace MiniStore.Domain
{
    public class Review
    {
        public int Id { get; set; }         // Pour la BD
        public string UserName { get; set; }// Pour l'affiche et une mesure de mémoire
        public byte Rating { get; set; }    // Pour l'affichage et le tri
        public string Text { get; set; }    // Pour les utilisateurs

        public int MiniId { get; set; }     // Foreign Key pour la table Mini
        public Mini Mini { get; set; }      // Navigation property pour la table Mini
    }
}
