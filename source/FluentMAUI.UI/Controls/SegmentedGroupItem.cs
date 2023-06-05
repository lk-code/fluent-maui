using System.ComponentModel;

namespace FluentMAUI.UI.Controls;

public class SegmentedGroupItem : View
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        "Text",
        typeof(string),
        typeof(SegmentedGroupItem),
        null);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty ItemProperty = BindableProperty.Create(
        "Item",
        typeof(object),
        typeof(SegmentedGroupItem),
        null,
        propertyChanged: OnItemPropertyChanged);

    public object Item
    {
        get => (object)GetValue(ItemProperty);
        set => SetValue(ItemProperty, value);
    }

    public static readonly BindableProperty TextPropertyNameProperty = BindableProperty.Create(
        "TextPropertyName",
        typeof(string),
        typeof(SegmentedGroupItem),
        null);

    public string TextPropertyName
    {
        get => (string)GetValue(TextPropertyNameProperty);
        set => SetValue(TextPropertyNameProperty, value);
    }

    private static void OnItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        SegmentedGroupItem control = (SegmentedGroupItem)bindable;

        control.OnItemChanged(oldValue, newValue);
    }

    private void OnItemChanged(object value, object newValue)
    {
        if (value is INotifyPropertyChanged mutableItem)
        {
            mutableItem.PropertyChanged -= OnItemPropertyChanged;
        }

        if (newValue is INotifyPropertyChanged newMutableItem)
        {
            newMutableItem.PropertyChanged += OnItemPropertyChanged;
        }
    }

    private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == TextPropertyName)
        {
            this.SetTextFromItemProperty();
        }
    }

    private void SetTextFromItemProperty()
    {
        if (this.Item is not null
            && this.TextPropertyName is not null)
        {
            this.Text = this.Item.GetType().GetProperty(TextPropertyName)?.GetValue(Item)?.ToString();
        }
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(Item)
            || propertyName == nameof(TextPropertyName))
        {
            this.SetTextFromItemProperty();
        }
    }
}