using EntityFrameworkCore;
using EntityFrameworkCore.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new ApplicationDbContext())
        {
            Category category = new Category
            {
                Name = "Test"
            };
            context.Categories.Add(category);

            context.SaveChanges();
        }
    }
}