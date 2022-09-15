using Kernel.Modules;
using Kernel.Repository;

namespace Kernel.Shared;

public class DbAccess
{
    public readonly DatabaseContext Database;
    public readonly UserRepository UserRepository;
    public readonly ModuleRepository ModuleRepository;

    public DbAccess(DatabaseContext ctx, IPasswordHasher hasher)
    {
        Database = ctx;
        UserRepository = new UserRepository(ctx, hasher);
        ModuleRepository = new ModuleRepository(ctx);
    }

}