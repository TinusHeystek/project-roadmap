using Ardalis.Result;
using MediatR;

namespace StockStream.Users.Contracts;

public record UserDetailsByIdQuery(Guid UserId) :
  IRequest<Result<UserDetails>>;
