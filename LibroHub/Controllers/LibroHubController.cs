using AutoMapper;
using LibroHub.Application.LibroHub.Commands.CreateLibroHub;
using LibroHub.Application.LibroHub.Commands.EditLibroHub;
using LibroHub.Application.LibroHub.Queries.GetLibroHubByEncodedName;
using LibroHub.Application.LibroHub.Quires.GetAllLibroHubQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibroHub.MVC.Controllers
{
    public class LibroHubController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LibroHubController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //wyświetlanie wszystkich książek
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var libroHubs = await _mediator.Send(new GetAllLibroHubsQuery());

            return View(libroHubs);
        }

        //szczegóły
        [Authorize]
        [Route("LibroHub/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetLibroHubByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("LibroHub/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetLibroHubByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");

            }

            EditLibroHubCommand model = _mapper.Map<EditLibroHubCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("LibroHub/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditLibroHubCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);

            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateLibroHubCommand command)
        {
            //jesli walidacja formularza jest błędna nie przechodź dalej
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); //zwraca do listy książek
        }
    }
}
