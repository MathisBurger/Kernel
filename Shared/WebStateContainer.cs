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
            NotifyStateChanged();
        }
    }
    
    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}