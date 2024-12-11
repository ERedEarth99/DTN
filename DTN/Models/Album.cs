namespace DTN.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Foreign Key for Artist
        public int ArtistId { get; set; }

        // Navigation Property
        public Artist Artist { get; set; }
        public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }

}
