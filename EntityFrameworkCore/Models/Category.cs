using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Models
{
    public class Category
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
