﻿using Kernel.Models.Database;
using Kernel.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Repository;

public class ModuleRepository
{
    private readonly DatabaseContext Database;

    public ModuleRepository(DatabaseContext ctx)
    {
        Database = ctx;
    }

    public async Task<Module?> GetTaskByKey(string key)
    {
        return await Database.Modules.FirstOrDefaultAsync(m => m.ModuleKey == key);
    }

    public async Task<Module?> GetModuleByName(string name)
    {
        return await Database.Modules.FirstOrDefaultAsync(m => m.ModuleName == name);
    }

    public async Task<Module[]> FindAll()
    {
        return await Database.Modules.ToArrayAsync();
    }
}