using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public string? DisplayName { get; set; }
    }
}
