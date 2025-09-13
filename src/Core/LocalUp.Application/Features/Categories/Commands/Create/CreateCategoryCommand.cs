using MediatR;

namespace LocalUp.Application.Features.Categories.Commands.Create
{
    public record CreateCategoryCommand(string Name, string Description, long? ParentCategoryId) : IRequest<long>;
}
