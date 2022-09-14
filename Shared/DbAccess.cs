using Kernel.Modules;
using Kernel.Repository;

namespace Kernel.Shared;

public class DbAccess
{
    public readonly UserRepository UserRepository;

    public DbAccess(DatabaseContext ctx, IPasswordHasher hasher)
    {
        UserRepository = new UserRepository(ctx, hasher);
    }

}