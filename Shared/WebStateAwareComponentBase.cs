using Microsoft.AspNetCore.Components;

namespace Kernel.Shared;

public abstract class WebStateAwareComponentBase : ComponentBase, IDisposable
{
    [Inject]
    protected WebStateContainer AppState { get; private set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        AppState.OnChange += AppStateChanged;
    }

    protected abstract Boolean HandleAppStateChanged(String propertyName, WebStateContainer state);

    private async void AppStateChanged(String propertyName, WebStateContainer state)
    {
        Boolean changesOccured = HandleAppStateChanged(propertyName, state);
        if (changesOccured == true)
        {
            await InvokeAsync(StateHasChanged);
        }
    }

    public void Dispose()
    {
        AppState.OnChange -= AppStateChanged;
    }
}