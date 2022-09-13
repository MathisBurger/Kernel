namespace Kernel.Models.Shared;

public class SidebarElement
{
    public string Label { get; set; }
    public string Route { get; set; }

    public SidebarElement(string label, string route)
    {
        Label = label;
        Route = route;
    }
}