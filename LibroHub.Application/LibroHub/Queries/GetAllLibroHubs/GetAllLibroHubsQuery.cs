using MediatR;

namespace LibroHub.Application.LibroHub.Quires.GetAllLibroHubQuery
{
    //zwraca liste obiektów typu LibroHubDto
    public class GetAllLibroHubsQuery : IRequest<IEnumerable<LibroHubDto>>
    {

    }
}
