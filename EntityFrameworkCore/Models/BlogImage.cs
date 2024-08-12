using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Models
{
    public class BlogImage
    {
        public int Id { get; set; }
        public string? Image { get; set; }

        [Required, MaxLength(250)]
        public string? Caption { get; set; }

        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
