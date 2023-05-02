namespace FluentMAUI.Samples.UI.Models;

public class PageItem
{
    public string Title { get; set; }
    public Type Page { get; set; }

    public PageItem(string title,
        Type page)
    {
        Title = title;
        Page = page;
    }
}
