using Kernel.Models.Request;

namespace Kernel.Shared;

public class InitialDataLoader
{
    private DbAccess Db;

    public InitialDataLoader(DbAccess dbAccess)
    {
        Db = dbAccess;
    }

    public async Task LoadInitials()
    {
        if (!(await CheckAdminUserExists()))
        {
            CreateAdminUser();
        }
        Console.WriteLine("Loaded initials");
    }

    private async Task<bool> CheckAdminUserExists()
    {
        var user = await Db.UserRepository.FindUserByUsername("Admin");
        return user != null;
    }

    private async void CreateAdminUser()
    {
        var data = new RegisterRequest("Admin", "123");
        await Db.UserRepository.RegisterUser(data);
    }
}