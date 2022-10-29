using Microsoft.EntityFrameworkCore;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.Domain.Configuration;

namespace NesrinBookStore.Data.Contexts
{
    public class NesrinDbContext : DbContext
    {
        public NesrinDbContext(DbContextOptions<NesrinDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }

        public DbSet<Books> books { get; set; }
    }
}
