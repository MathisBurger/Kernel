using Kernel.Modules;
using Kernel.Repository;

namespace Kernel.Shared;

public class DbAccess
{
    public readonly DatabaseContext DatabaseContext;
    public readonly UserRepository UserRepository;

    public DbAccess(DatabaseContext ctx, IPasswordHasher hasher)
    {
        DatabaseContext = ctx;
        UserRepository = new UserRepository(ctx, hasher);
    }

}