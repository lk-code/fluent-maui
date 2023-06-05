using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace FluentMAUI.UI.Controls;

[DesignTimeVisible(true)]
[ContentProperty(nameof(Children))]
public class SlideContentView : ContentView, IViewContainer<SlideContentPage>
{
    private StackLayout _tabBarStackLayout;
    private ScrollView _tabBarScrollView;
    private CarouselView _contentCarouselView;
    private Grid _mainViewGrid;

    public static readonly BindableProperty ChildrenProperty = BindableProperty.Create(
        "Children",
        typeof(IList<SlideContentPage>),
        typeof(SlideContentView),
        default(IList<SlideContentPage>),
        propertyChanged: OnChildrenChanged);

    public IList<SlideContentPage> Children
    {
        get => (IList<SlideContentPage>)GetValue(ChildrenProperty);
        set => SetValue(ChildrenProperty, value);
    }

    public SlideContentView()
    {
        this.Children = new List<SlideContentPage>();

        this.CreateUILayout();
        this.RenderUI();
    }

    private void CreateUILayout()
    {
        // Content Container => StackLayout
        this._tabBarStackLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };

        // ScrollView
        this._tabBarScrollView = new ScrollView
        {
            Orientation = ScrollOrientation.Horizontal,
            Margin = new Thickness(0, 8, 0, 8),
            HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
            VerticalScrollBarVisibility = ScrollBarVisibility.Never,
            Content = this._tabBarStackLayout
        };

        // Content CarousselView
        this._contentCarouselView = new CarouselView()
        {
            ItemTemplate = new DataTemplate(() =>
            {
                var contentPresenter = new ContentPresenter();
                contentPresenter.SetBinding(ContentPresenter.ContentProperty, ".");

                return contentPresenter;
            })
        };

        // Main View Grid
        this._mainViewGrid = new Grid();
        this._mainViewGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        this._mainViewGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

        this._mainViewGrid.Add(this._tabBarScrollView, 0, 0);
        this._mainViewGrid.Add(this._contentCarouselView, 0, 1);

        this.Content = this._mainViewGrid;
    }

    private void RenderUI()
    {
        IList<View> items = new List<View>();
        foreach (SlideContentPage item in this.Children)
        {
            Button tabBarButton = (item as Button);
            tabBarButton.Clicked += ChangeSelectedTab;
            this._tabBarStackLayout.Children.Add(tabBarButton);

            items.Add(item.TabContent);
        }

        this._contentCarouselView.ItemsSource = items;
    }

    private void ChangeSelectedTab(object sender, System.EventArgs e)
    {
        SlideContentPage selected = (sender as SlideContentPage);
        this._contentCarouselView.CurrentItem = selected.TabContent;
    }

    private static void OnChildrenChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SlideContentView slideContentView
            && newValue is IList<SlideContentPage> slideContentPages
            && slideContentView.Children is not null)
        {
            // render delta
            int i = 0;
        }
    }
}