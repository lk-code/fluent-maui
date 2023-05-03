namespace FluentMAUI.Samples.UI.Models;

public class PageItem
{
    public string Title { get; set; }
    public string Route { get; set; }

    public PageItem(string title,
        string route)
    {
        Title = title;
        Route = route;
    }
}
