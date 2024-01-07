using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibroHub.Infrastructure.Persistence;

namespace LibroHub.Infrastructure.Seeders
{
    public class LibroHubSeeder
    {
        private readonly LibroHubDbContext _dbContext;

        public LibroHubSeeder(LibroHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.LibroHub.Any())
                {
                    var panTadeusz = new Domain.Entities.LibroHub()
                    {
                        Name = "Pan Tadeusz",
                        Description = "Pan Tadeusz, czyli ostatni zajazd na Litwie",
                        BookDetails = new()
                        {
                            BookCategory = "Poemat epicki",
                            Author = "Adam Mickiewicz",
                            PageNumber = 245,
                            Rating = 9
                        }
                    };
                    panTadeusz.EncodeName();

                    _dbContext.LibroHub.Add(panTadeusz);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
