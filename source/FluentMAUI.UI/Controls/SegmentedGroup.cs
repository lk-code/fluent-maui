using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using FluentMAUI.UI.EventArgs;

namespace FluentMAUI.UI.Controls;

[DesignTimeVisible(true)]
[ContentProperty(nameof(Children))]
public class SegmentedGroup : View, IViewContainer<SegmentedGroupItem>
{
    public event EventHandler<SegmentGroupChildrenChangingEventArgs> OnSegmentedGroupChildrenChanging;
    public event EventHandler<SegmentSelectedEventArgs> OnSegmentSelected;

    public static readonly BindableProperty ChildrenProperty = BindableProperty.Create(
        "Children",
        typeof(IList<SegmentedGroupItem>),
        typeof(SegmentedGroup),
        default(IList<SegmentedGroupItem>),
        propertyChanging: OnChildrenChanging);

    public IList<SegmentedGroupItem> Children
    {
        get => (IList<SegmentedGroupItem>)GetValue(ChildrenProperty);
        set => SetValue(ChildrenProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        "ItemsSource",
        typeof(IEnumerable),
        typeof(SegmentedGroup),
        null);

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty TextPropertyNameProperty = BindableProperty.Create(
        "TextPropertyName",
        typeof(string),
        typeof(SegmentedGroup),
        null);

    public string TextPropertyName
    {
        get => (string)GetValue(TextPropertyNameProperty);
        set => SetValue(TextPropertyNameProperty, value);
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        "SelectedItem",
        typeof(object),
        typeof(SegmentedGroup),
        0);

    public object SelectedItem
    {
        get => (object)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public static readonly BindableProperty SelectedSegmentProperty = BindableProperty.Create(
        "SelectedSegment",
        typeof(int),
        typeof(SegmentedGroup),
        null,
        defaultBindingMode: BindingMode.TwoWay);

    public int SelectedSegment
    {
        get => (int)GetValue(SelectedSegmentProperty);
        set => SetValue(SelectedSegmentProperty, value);
    }

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: "TextColor",
        returnType: typeof(Color),
        declaringType: typeof(SegmentedGroup),
        Color.FromRgb(0, 0, 0));

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
        nameof(TintColor),
        typeof(Color),
        typeof(SegmentedGroup),
        Color.FromRgb(81, 43, 212));

    public Color TintColor
    {
        get => (Color)GetValue(TintColorProperty);
        set => SetValue(TintColorProperty, value);
    }

    public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(
        propertyName: "SelectedTextColor",
        returnType: typeof(Color),
        declaringType: typeof(SegmentedGroup),
        Color.FromRgb(255, 255, 255));

    public Color SelectedTextColor
    {
        get => (Color)GetValue(SelectedTextColorProperty);
        set => SetValue(SelectedTextColorProperty, value);
    }

    public static readonly BindableProperty DisabledColorProperty = BindableProperty.Create(
        propertyName: "DisabledColor",
        typeof(Color),
        typeof(SegmentedGroup),
        Color.FromRgb(145, 145, 145));

    public Color DisabledColor
    {
        get => (Color)GetValue(DisabledColorProperty);
        set => SetValue(DisabledColorProperty, value);
    }

    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
        propertyName: "BorderColor",
        typeof(Color),
        typeof(SegmentedGroup),
        defaultValueCreator: (bindable) =>
        {
            SegmentedGroup control = (SegmentedGroup)bindable;

            return control.TintColor;
        });

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
        propertyName: "BorderWidth",
        typeof(double),
        typeof(SegmentedGroup)
        // defaultValueCreator: (bindable) =>
        // {
        //     if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        //     {
        //         return 1.0;
        //     }
        //     
        //     double width = DeviceInfo.Current.Platform switch
        //     {
        //         DevicePlatform.iOS => 1.0,
        //         DevicePlatform.macOS => 1.0,
        //         DevicePlatform.MacCatalyst => 1.0,
        //         DevicePlatform.Android => 1.0,
        //         DevicePlatform.Tizen => 1.0,
        //         DevicePlatform.tvOS => 1.0,
        //         DevicePlatform.UWP => 1.0,
        //         DevicePlatform.watchOS => 1.0,
        //         DevicePlatform.WinUI => 1.0,
        //         DevicePlatform.Unknown => 1.0,
        //         _ => 1.0
        //     };
        //
        //     return width;
        // }
    );

    public double BorderWidth
    {
        get => (double)GetValue(BorderWidthProperty);
        set => SetValue(BorderWidthProperty, value);
    }

    public static readonly BindableProperty SegmentSelectedCommandProperty = BindableProperty.Create(
        nameof(SegmentSelectedCommand),
        typeof(ICommand),
        typeof(SegmentedGroup));

    public ICommand SegmentSelectedCommand
    {
        get => (ICommand)GetValue(SegmentSelectedCommandProperty);
        set => SetValue(SegmentSelectedCommandProperty, value);
    }

    public static readonly BindableProperty SegmentSelectedCommandParameterProperty = BindableProperty.Create(
        nameof(SegmentSelectedCommandParameter),
        typeof(object),
        typeof(SegmentedGroup));

    public object SegmentSelectedCommandParameter
    {
        get => GetValue(SegmentSelectedCommandParameterProperty);
        set => SetValue(SegmentSelectedCommandParameterProperty, value);
    }

    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
        nameof(FontSize),
        typeof(double),
        typeof(SegmentedGroup));

    [TypeConverter(typeof(FontSizeConverter))]
    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
        nameof(FontFamily),
        typeof(string),
        typeof(SegmentedGroup));

    public string FontFamily
    {
        get => (string)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    public SegmentedGroup()
    {
        this.Children = new List<SegmentedGroupItem>();
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(this.ItemsSource)
            || propertyName == nameof(this.TextPropertyName))
        {
            this.OnItemsSourceChanged();
        }
        else if (propertyName == nameof(this.SelectedItem))
        {
            this.OnSelectedItemChanged();
        }
        else if (propertyName == nameof(this.SelectedSegment))
        {
            this.OnSelectedSegmentChanged();
        }
    }

    private static void OnChildrenChanging(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SegmentedGroup segmentedControl
            && newValue is IList<SegmentedGroupItem> newItemsList
            && segmentedControl.Children is not null)
        {
            segmentedControl.OnSegmentedGroupChildrenChanging?.Invoke(segmentedControl,
                new SegmentGroupChildrenChangingEventArgs((IList<SegmentedGroupItem>)oldValue, newItemsList));
            segmentedControl.Children.Clear();

            foreach (SegmentedGroupItem newSegment in newItemsList)
            {
                newSegment.BindingContext = segmentedControl.BindingContext;
                segmentedControl.Children.Add(newSegment);
            }
        }
    }

    private void OnItemsSourceChanged()
    {
        IEnumerable itemsSource = ItemsSource;
        IList items = itemsSource as IList;
        if (items is null
            && itemsSource is IEnumerable list)
        {
            items = list.Cast<object>().ToList();
        }

        if (items != null)
        {
            IEnumerable<string>? textValues = items as IEnumerable<string>;
            if (textValues is null
                && items.Count > 0
                && items[0] is string)
            {
                textValues = items.Cast<string>();
            }

            if (textValues is not null)
            {
                this.Children = new List<SegmentedGroupItem>(textValues.Select(child =>
                    new SegmentedGroupItem { Text = child }));
                this.OnSelectedItemChanged(true);
            }
            else
            {
                string? textPropertyName = this.TextPropertyName;

                if (textPropertyName != null)
                {
                    List<SegmentedGroupItem> newChildren = new List<SegmentedGroupItem>();
                    foreach (object? item in items)
                    {
                        newChildren.Add(new SegmentedGroupItem
                        {
                            Item = item,
                            TextPropertyName = textPropertyName
                        });
                    }

                    this.Children = newChildren;
                    this.OnSelectedItemChanged(true);
                }
            }
        }
    }

    private void OnSelectedItemChanged(bool forceUpdateSelectedSegment = false)
    {
        if (this.TextPropertyName != null)
        {
            SegmentedGroupItem selectedItem = (this.SelectedItem as SegmentedGroupItem);
            int selectedIndex = this.Children.IndexOf(selectedItem);

            if (selectedIndex == -1)
            {
                selectedIndex = this.SelectedSegment;

                if (selectedIndex < 0
                    || selectedIndex >= Children.Count)
                {
                    this.SelectedSegment = 0;
                }
                else if (this.SelectedSegment != selectedIndex)
                {
                    this.SelectedSegment = selectedIndex;
                }
                else if (forceUpdateSelectedSegment)
                {
                    this.OnSelectedSegmentChanged();
                }
            }
            else if (selectedIndex != this.SelectedSegment)
            {
                this.SelectedSegment = selectedIndex;
            }
        }
    }

    private void OnSelectedSegmentChanged()
    {
        int segmentIndex = this.SelectedSegment;
        if (segmentIndex >= 0
            && segmentIndex < this.Children.Count
            && this.SelectedItem != this.Children[segmentIndex].Item)
        {
            this.SelectedItem = this.Children[segmentIndex].Item;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void RaiseSelectionChanged()
    {
        this.OnSegmentSelected?.Invoke(this, new SegmentSelectedEventArgs { NewValue = this.SelectedSegment });

        if (!(this.SegmentSelectedCommand is null)
            && this.SegmentSelectedCommand.CanExecute(this.SegmentSelectedCommandParameter))
        {
            this.SegmentSelectedCommand.Execute(this.SegmentSelectedCommandParameter);
        }
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (this.Children is not null)
        {
            foreach (var segment in Children)
            {
                segment.BindingContext = this.BindingContext;
            }
        }
    }
}