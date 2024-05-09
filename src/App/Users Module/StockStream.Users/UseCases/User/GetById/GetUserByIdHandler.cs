using Ardalis.Result;
using MediatR;
using StockStream.Users.Interfaces;

namespace StockStream.Users.UseCases.User.GetById;

internal class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
  private readonly IApplicationUserRepository _userRepository;

  public GetUserByIdHandler(IApplicationUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserByIdAsync(request.UserId);

    if (user is null)
    {
      return Result.NotFound();
    }

    return new UserDto(Guid.Parse(user!.Id), user.Email!);
  }
}

