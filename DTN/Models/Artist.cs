namespace DTN.Models
{
    public class Artist
    {
        public int ArtistId { get; set; } // Primary Key
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}

