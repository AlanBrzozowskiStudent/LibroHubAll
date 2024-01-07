using AutoMapper;
using LibroHub.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroHub.Application.LibroHub.Queries.GetLibroHubByEncodedName
{
    public class GetLibroHubByEncodedNameQueryHandler : IRequestHandler<GetLibroHubByEncodedNameQuery, LibroHubDto>
    {
        private readonly ILibroHubRepository _libroHubRepository;
        private readonly IMapper _mapper;

        public GetLibroHubByEncodedNameQueryHandler(ILibroHubRepository libroHubRepository, IMapper mapper)
        {
            _libroHubRepository = libroHubRepository;
            _mapper = mapper;
        }
        public async Task<LibroHubDto> Handle(GetLibroHubByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var libroHub = await _libroHubRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<LibroHubDto>(libroHub);

            return dto;
        }
    }
}
