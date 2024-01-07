using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroHub.Domain.Interfaces
{
    public interface ILibroHubRepository
    {
        Task Create(Domain.Entities.LibroHub libroHub);
        Task<Domain.Entities.LibroHub?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.LibroHub>> GetAll();
        Task<Domain.Entities.LibroHub> GetByEncodedName(string encodedName);
        Task Commit();
    }
}
