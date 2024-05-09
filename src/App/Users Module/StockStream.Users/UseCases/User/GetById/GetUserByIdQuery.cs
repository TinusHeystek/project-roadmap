using Ardalis.Result;
using MediatR;

namespace StockStream.Users.UseCases.User.GetById;
internal record GetUserByIdQuery(Guid UserId) : IRequest<Result<UserDto>>;

