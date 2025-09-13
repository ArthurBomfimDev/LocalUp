using FluentValidation;
using LocalUp.Application.DTOs;
using LocalUp.Application.Features.Categories.Commands.Create;
using LocalUp.Application.Interfaces.Repository.Read;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocalUp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly IValidator<CreateCategoryCommand> _validator;

    public CategoriesController(IMediator mediator, ICategoryReadRepository categoryReadRepository, IValidator<CreateCategoryCommand> validator)
    {
        _mediator = mediator;
        _categoryReadRepository = categoryReadRepository;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var categories = await _categoryReadRepository.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> Get(long id)
    {
        var category = await _categoryReadRepository.GetById(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<long>> Create([FromBody] CreateCategoryCommand command)
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
    public async Task<ActionResult<BulkOperationResult>> BulkCreate([FromBody] List<CreateCategoryCommand> commands)
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