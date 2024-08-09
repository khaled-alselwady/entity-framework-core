namespace EntityFrameworkCore.Models
{
    public class Book
    {
        // [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
    }
}
