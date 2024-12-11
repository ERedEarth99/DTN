namespace DTN.Models
{
    public class Genre
    {
        public int GenreId { get; set; } // Primary Key
        public string Name { get; set; }

        // Navigation Property
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
