using Microsoft.EntityFrameworkCore;

public class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; } = null!;
}