using MediatR;

namespace LocalUp.Application.Features.Categories.Commands.Update
{
    public record UpdateCategoryCommand(
        long Id,
        string Name,
        string Description,
        long? ParentCategoryId) : IRequest<bool>;
}