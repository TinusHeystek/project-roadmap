using Ardalis.Result;
using MediatR;

namespace StockStream.Users.UseCases.User.Create;
internal record CreateUserCommand(string Email, string Password) : IRequest<Result>;
