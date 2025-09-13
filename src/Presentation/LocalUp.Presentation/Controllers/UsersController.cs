using FluentValidation;
using LocalUp.Application.DTOs;
using LocalUp.Application.Features.Users.Commands.Create;
using LocalUp.Application.Interfaces.Repository.Read;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocalUp.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IValidator<CreateUserCommand> _validator;

        public UsersController(IMediator mediator, IUserReadRepository userReadRepository, IValidator<CreateUserCommand> validator)
        {
            _mediator = mediator;
            _userReadRepository = userReadRepository;
            _validator = validator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userReadRepository.GetAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(long id)
        {
            var user = await _userReadRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateUserCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ValidationProblem(ModelState);
            }
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<BulkOperationResult>> BulkCreate([FromBody] List<CreateUserCommand> commands)
        {
            var result = new BulkOperationResult();
            if (commands == null)
            {
                return BadRequest("Lista de comandos não pode ser nula");
            }
            for (int i = 0; i < commands.Count; i++)
            {
                var cmd = commands[i];
                try
                {
                    var validation = await _validator.ValidateAsync(cmd);
                    if (!validation.IsValid)
                    {
                        var errorMessage = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                        result.Errors.Add(new BulkOperationError { Index = i, Message = errorMessage });
                        continue;
                    }
                    var id = await _mediator.Send(cmd);
                    result.CreatedIds.Add(id);
                }
                catch (Exception ex)
                {
                    result.Errors.Add(new BulkOperationError { Index = i, Message = ex.Message });
                }
            }
            return Ok(result);
        }
    }
}