using LibroHub.Domain.Interfaces;
using LibroHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibroHub.Infrastructure.Repositories
{
    internal class LibroHubRepository : ILibroHubRepository
    {
        private readonly LibroHubDbContext _dbContext;

        public LibroHubRepository(LibroHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //edycja książki
        public Task Commit()
         => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.LibroHub libroHub)
        {
            _dbContext.Add(libroHub);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.LibroHub>> GetAll()
            => await _dbContext.LibroHub.ToListAsync();

        public async Task<Domain.Entities.LibroHub> GetByEncodedName(string encodedName)
            => await _dbContext.LibroHub.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.LibroHub?> GetByName(string name)
            => _dbContext.LibroHub.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

        public async Task Delete(Domain.Entities.LibroHub libroHub)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.remove?view=efcore-8.0
            _dbContext.LibroHub.Remove(libroHub);
            await _dbContext.SaveChangesAsync();
        }
    }
}
