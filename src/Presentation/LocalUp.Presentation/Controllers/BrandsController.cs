using FluentValidation;
using LocalUp.Application.DTOs;
using LocalUp.Application.Features.Brands.Commands.Create;
using LocalUp.Application.Interfaces.Repository.Read;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocalUp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IBrandReadRepository _brandReadRepository;
    private readonly IValidator<CreateBrandCommand> _validator;

    public BrandsController(IMediator mediator, IBrandReadRepository brandReadRepository, IValidator<CreateBrandCommand> validator)
    {
        _mediator = mediator;
        _brandReadRepository = brandReadRepository;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetAll()
    {
        var brands = await _brandReadRepository.GetAll();
        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BrandDto>> Get(long id)
    {
        var brand = await _brandReadRepository.GetById(id);
        if (brand == null)
        {
            return NotFound();
        }
        return Ok(brand);
    }

    [HttpPost]
    public async Task<ActionResult<long>> Create([FromBody] CreateBrandCommand command)
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
    public async Task<ActionResult<BulkOperationResult>> BulkCreate([FromBody] List<CreateBrandCommand> commands)
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
                    var message = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                    result.Errors.Add(new BulkOperationError { Index = i, Message = message });
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