using System.ComponentModel.DataAnnotations;

namespace DTN.Models
{
    public class Forum
    {
        public int ForumId { get; set; }
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}