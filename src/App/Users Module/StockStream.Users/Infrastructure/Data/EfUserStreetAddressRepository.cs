using Microsoft.EntityFrameworkCore;
using StockStream.Users.Domain;
using StockStream.Users.Interfaces;

namespace StockStream.Users.Infrastructure.Data;

internal class EfUserStreetAddressRepository : IReadOnlyUserStreetAddressRepository
{
  private readonly UsersDbContext _dbContext;

  public EfUserStreetAddressRepository(UsersDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public Task<UserStreetAddress?> GetById(Guid userStreetAddressId)
  {
    return _dbContext.UserStreetAddresses
      .SingleOrDefaultAsync(a => a.Id == userStreetAddressId);
  }
}
