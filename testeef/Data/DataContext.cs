using testeef.Models;
using Microsoft.EntityFrameworkCore;


namespace testeef.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> categories{get; set;}
        public DbSet<Produto> produtos{get; set;}
    }
}