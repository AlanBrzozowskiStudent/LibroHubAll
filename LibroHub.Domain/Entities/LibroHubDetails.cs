using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroHub.Domain.Entities
{
    public class LibroHubDetails
    {
        public string? BookCategory { get; set; }
        public string? Author { get; set; }
        public int? PageNumber { get; set; }
        public int? Rating { get; set; }
    }
}
