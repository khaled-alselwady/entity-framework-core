using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Models
{
    public class Blog
    {
        public int Id { get; set; }

        // [Column("BlogUrl")]
        // [Column(TypeName = "nvarchar(200)")]
        // [Comment("The url of the blog")]
        [MaxLength(200)]
        public string? Url { get; set; }

        // [Column(TypeName = "decimal(5,2)")]
        // [NotMapped]
        public decimal Rating { get; set; }

        // [NotMapped]
        public DateTime AddedOn { get; set; }

        // [NotMapped]
        public List<Post>? Posts { get; set; }
    }
}
