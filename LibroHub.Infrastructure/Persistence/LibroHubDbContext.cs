using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibroHub.Infrastructure.Persistence
{
    public class LibroHubDbContext : IdentityDbContext
    {
        public LibroHubDbContext(DbContextOptions<LibroHubDbContext> options) : base(options)
        {

        }
        public DbSet<Domain.Entities.LibroHub> LibroHub { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.LibroHub>()
                .OwnsOne(c => c.BookDetails);
        }
    }
}
