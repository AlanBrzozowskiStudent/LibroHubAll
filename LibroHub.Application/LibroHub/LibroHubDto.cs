using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroHub.Application.LibroHub
{
    public class LibroHubDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? About {  get; set; }
        public string? Author { get; set; }
        public string? BookCategory { get; set; }
        public int? PageNumber { get; set; }
        public int? Rating { get; set; }
        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }

    }
}
