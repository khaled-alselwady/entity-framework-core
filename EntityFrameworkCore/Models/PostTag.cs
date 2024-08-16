namespace EntityFrameworkCore.Models
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Posts { get; set; }
        public int TagId { get; set; }
        public Tag Tags { get; set; }
        public DateOnly CreateAt { get; set; }
    }
}
