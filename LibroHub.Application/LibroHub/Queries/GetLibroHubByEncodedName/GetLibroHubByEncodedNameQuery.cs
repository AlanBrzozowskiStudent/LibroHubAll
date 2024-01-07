using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroHub.Application.LibroHub.Queries.GetLibroHubByEncodedName
{
    public class GetLibroHubByEncodedNameQuery : IRequest<LibroHubDto>
    {
        public string EncodedName { get; set; }

        public GetLibroHubByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
