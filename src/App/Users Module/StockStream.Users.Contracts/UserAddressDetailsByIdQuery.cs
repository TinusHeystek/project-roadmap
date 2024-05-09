using Ardalis.Result;
using MediatR;

namespace StockStream.Users.Contracts;

public record UserAddressDetailsByIdQuery(Guid AddressId) : 
  IRequest<Result<UserAddressDetails>>;
