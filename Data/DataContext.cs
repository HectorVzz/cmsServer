using back.Models;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<NavData> NavData { get; set; }
    public DbSet<BodyData> BodyData { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
  }
}