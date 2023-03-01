using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Ocupaciones> Ocupaciones { get; set; }
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
}