using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace FluentMAUI.UI.Controls;

public class SlideContentView : ContentView
{
    private StackLayout _tabBarStackLayout;
    private ScrollView _tabBarScrollView;
    private CarouselView _contentCarouselView;
    private Grid _mainViewGrid;
    private IList<View> _items;

    public SlideContentView()
    {
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
            BackgroundColor = Colors.Yellow,
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
        // Tab Bar
        for (int i = 0; i < 5; i++)
        {
            SlideContentPage tabBarButton = new SlideContentPage()
            {
                Text = $"Tab {(i + 1)}",
                Margin = new Thickness(8, 0, 8, 0),
                Padding = new Thickness(16, 0, 16, 0),
                TabContent = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                        new Label { Text = $"Content Page {i}" },
                        new Button() { Text = "Click" }
                    },
                    Padding = new Thickness(8, 0, 8, 0)
                }
            };
            tabBarButton.Clicked += ChangeSelectedTab;
            this._tabBarStackLayout.Children.Add(tabBarButton);
        }

        // Content
        this._items = new List<View>();
        for (int i = 1; i <= 5; i++)
        {
            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Label { Text = $"Content Page {i}" },
                    new Button() { Text = "Click" }
                },
                Padding = new Thickness(8, 0, 8, 0)
            };
            this._items.Add(stackLayout);
        }

        this._contentCarouselView.ItemsSource = this._items;
    }

    private void ChangeSelectedTab(object sender, System.EventArgs e)
    {
        
    }
}