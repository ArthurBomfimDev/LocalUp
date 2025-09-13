using FluentValidation;
using LocalUp.Application.DTOs;
using LocalUp.Application.Features.Products.Commands.Create;
using LocalUp.Application.Interfaces.Repository.Read;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocalUp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IValidator<CreateProductCommand> _validator;

    public ProductsController(IMediator mediator, IProductReadRepository productReadRepository, IValidator<CreateProductCommand> validator)
    {
        _mediator = mediator;
        _productReadRepository = productReadRepository;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _productReadRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(long id)
    {
        var product = await _productReadRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<long>> Create([FromBody] CreateProductCommand command)
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
    public async Task<ActionResult<BulkOperationResult>> BulkCreate([FromBody] List<CreateProductCommand> commands)
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