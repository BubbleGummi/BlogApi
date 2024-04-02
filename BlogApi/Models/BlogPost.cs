using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }

        public DateTime CreatedDate { get; set;}

    }
}
