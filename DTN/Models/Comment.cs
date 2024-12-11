namespace DTN.Models
{
    public class Comment
    {
        public int CommentId { get; set; } // Primary Key
        public string Content { get; set; }
        public int PostId { get; set; } // Foreign Key

        // Navigation Property
        public virtual Post Post { get; set; }
    }
}
