using MediatR;

namespace LocalUp.Application.Features.Brands.Commands.Create
{
    public record CreateBrandCommand(string Name, string Description) : IRequest<long>;
}
