namespace DTN.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int Duration { get; set; } // Duration in seconds

        // Navigation properties
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public Genre Genre { get; set; }


    }
}
