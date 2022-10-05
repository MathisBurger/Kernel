using Kernel.Models.Database;

namespace Kernel.Shared;

public class WebStateContainer
{

    private User? currentUser = null;

    public User? CurrentUser
    {
        get => currentUser;
        set
        {
            currentUser = value;
            OnChange?.Invoke(nameof(CurrentUser), this);
        }
    }

    public event WebStateChangedHandler? OnChange;

}