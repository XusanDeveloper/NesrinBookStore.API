using Microsoft.EntityFrameworkCore;
using NesrinBooks.API.DataAccess.Entities;

namespace NesrinBookStore.Data.Contexts
{
    public class NesrinDbContext : DbContext
    {
        public NesrinDbContext(DbContextOptions<NesrinDbContext> options)
            : base(options)
        {

        }

        public DbSet<Books> books { get; set; }
    }
}
