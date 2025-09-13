using MediatR;

namespace LocalUp.Application.Features.Brands.Commands.Update
{
    public record UpdateBrandCommand(long Id, string Name, string Description) : IRequest<bool>;
}