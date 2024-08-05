using EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new ApplicationDBContext())
        {
            Employee employee = new Employee
            {
                Name = "Khaled"
            };
            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }
}