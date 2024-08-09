using EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new ApplicationDBContext())
        {

            context.SaveChanges();
        }
    }
}