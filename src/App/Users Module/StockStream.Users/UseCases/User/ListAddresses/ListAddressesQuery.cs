using Ardalis.Result;
using MediatR;
using StockStream.Users.UserEndpoints;

namespace StockStream.Users.UseCases.User.ListAddresses;
internal record ListAddressesQuery(string EmailAddress) :
  IRequest<Result<List<UserAddressDto>>>;
