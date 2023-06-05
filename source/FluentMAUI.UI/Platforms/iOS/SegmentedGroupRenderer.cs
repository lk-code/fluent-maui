using System.ComponentModel;
using System.Runtime.InteropServices;
using FluentMAUI.UI.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
using UIKit;

[assembly: ExportRenderer(typeof(SegmentedGroup), typeof(FluentMAUI.UI.Ios.SegmentedGroupRenderer))]

namespace FluentMAUI.UI.Ios;

public class SegmentedGroupRenderer : ViewRenderer<SegmentedGroup, UISegmentedControl>
{
    private UISegmentedControl _nativeControl;

    protected override void OnElementChanged(ElementChangedEventArgs<SegmentedGroup> e)
    {
        base.OnElementChanged(e);

        if (Control is null
            && Element is not null)
        {
            _nativeControl = new UISegmentedControl
            {
                Enabled = Element.IsEnabled
            };

            SetNativeControlSegments(Element.Children);
            SetNativeControl(_nativeControl);
            SetEnabledStateColor();
            SetFont();
            SetSelectedTextColor();
            SetTextColor();
            SetBorder();
        }

        if (!(e.OldElement is null))
        {
            if (!(_nativeControl is null))
            {
                _nativeControl.ValueChanged -= NativeControl_SelectionChanged;
            }

            RemoveElementHandlers();
        }

        if (!(e.NewElement is null))
        {
            if (!(_nativeControl is null))
            {
                _nativeControl.ValueChanged += NativeControl_SelectionChanged;
            }

            AddElementHandlers(e.NewElement);
        }
    }

    private void SetNativeControlSegments(IList<SegmentedGroupItem> children)
    {
        if (!(_nativeControl is null))
        {
            if (_nativeControl.NumberOfSegments > 0)
            {
                _nativeControl.RemoveAllSegments();
            }

            foreach (var (child, i) in children.Select((child, i) => (child, i)))
            {
                _nativeControl.InsertSegment(child.Text, i, false);
                _nativeControl.SetEnabled(children[i].IsEnabled, i);

                if (children[i].WidthRequest > 0)
                    _nativeControl.SetWidth((NFloat)children[i].WidthRequest, i);
            }

            if (!(Element is null))
            {
                _nativeControl.SelectedSegment = Element.SelectedSegment;
            }
        }
    }

    private void AddElementHandlers(SegmentedGroup element, bool addChildHandlersOnly = false)
    {
        if (element is not null)
        {
            if (!addChildHandlersOnly)
            {
                element.OnSegmentedGroupChildrenChanging += OnElementChildrenChanging;
            }

            if (element.Children is not null)
            {
                foreach (var child in element.Children)
                {
                    child.PropertyChanged += SegmentPropertyChanged;
                }
            }
        }
    }

    private void RemoveElementHandlers(bool removeChildrenHandlersOnly = false)
    {
        if (!(Element is null))
        {
            if (!removeChildrenHandlersOnly)
            {
                Element.OnSegmentedGroupChildrenChanging -= OnElementChildrenChanging;
            }

            if (!(Element.Children is null))
            {
                foreach (var child in Element.Children)
                {
                    child.PropertyChanged -= SegmentPropertyChanged;
                }
            }
        }
    }

    private void OnElementChildrenChanging(object sender, System.EventArgs e)
    {
        RemoveElementHandlers(true);
    }

    private void SegmentPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (!(_nativeControl is null)
            && !(Element is null)
            && sender is SegmentedGroupItem option)
        {
            var index = Element.Children.IndexOf(option);

            switch (e.PropertyName)
            {
                case nameof(SegmentedGroupItem.Text):
                    _nativeControl.SetTitle(option.Text, index);
                    break;
                case nameof(SegmentedGroupItem.IsEnabled):
                    _nativeControl.SetEnabled(option.IsEnabled, index);
                    break;
            }
        }
    }

    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);

        if (e.PropertyName == "Renderer")
        {
            Element?.RaiseSelectionChanged();
            return;
        }

        if (_nativeControl is null
            || Element is null)
        {
            return;
        }

        switch (e.PropertyName)
        {
            case nameof(SegmentedGroup.SelectedSegment):
                _nativeControl.SelectedSegment = Element.SelectedSegment;
                Element.RaiseSelectionChanged();
                break;

            case nameof(SegmentedGroup.TintColor):
                SetEnabledStateColor();
                break;

            case nameof(SegmentedGroup.IsEnabled):
                _nativeControl.Enabled = Element.IsEnabled;
                SetEnabledStateColor();
                break;

            case nameof(SegmentedGroup.SelectedTextColor):
                SetSelectedTextColor();
                break;

            case nameof(SegmentedGroup.TextColor):
                SetTextColor();
                break;

            case nameof(SegmentedGroup.Children):
                if (!(Element.Children is null))
                {
                    SetNativeControlSegments(Element.Children);
                    AddElementHandlers(Element, true);
                }

                break;

            case nameof(SegmentedGroup.FontSize):
            case nameof(SegmentedGroup.FontFamily):
                SetFont();
                break;

            case nameof(SegmentedGroup.BorderWidth):
            case nameof(SegmentedGroup.BorderColor):
                SetBorder();
                break;
        }
    }

    private void SetEnabledStateColor()
    {
        if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
        {
            _nativeControl.SelectedSegmentTintColor = Element.IsEnabled
                ? Element.TintColor.ToPlatform()
                : Element.DisabledColor.ToPlatform();
        }
        else
        {
            _nativeControl.TintColor = Element.IsEnabled
                ? Element.TintColor.ToPlatform()
                : Element.DisabledColor.ToPlatform();
        }
    }

    private void SetFont()
    {
        var uiTextAttribute = _nativeControl.GetTitleTextAttributes(UIControlState.Normal);

        var font = string.IsNullOrEmpty(Element.FontFamily)
            ? UIFont.SystemFontOfSize((NFloat)Element.FontSize)
            : UIFont.FromName(Element.FontFamily, (NFloat)Element.FontSize);

        uiTextAttribute.Font = font;

        _nativeControl.SetTitleTextAttributes(uiTextAttribute, UIControlState.Normal);
    }

    private void SetTextColor()
    {
        var uiTextAttribute = _nativeControl.GetTitleTextAttributes(UIControlState.Normal);

        // uiTextAttribute.ForegroundColor = Element.TextColor.ToPlatform();
        //
        // _nativeControl.SetTitleTextAttributes(uiTextAttribute, UIControlState.Normal);

        UIStringAttributes uiStringAttributes = new UIStringAttributes();

        // UIColor selectedColor = Element.TextColor.ToPlatform();
        uiStringAttributes.ForegroundColor = UIColor.Red;

        _nativeControl.SetTitleTextAttributes(uiStringAttributes, UIControlState.Selected);
    }

    private void SetSelectedTextColor()
    {
        // UIStringAttributes? uiStringAttributes = _nativeControl.GetTitleTextAttributes(UIControlState.Normal);
        // if (uiStringAttributes is null)
        // {
        //     return;
        // }

        UIStringAttributes uiStringAttributes = new UIStringAttributes();

        // UIColor selectedColor = Element.SelectedTextColor.ToPlatform();
        uiStringAttributes.ForegroundColor = UIColor.Black;

        _nativeControl.SetTitleTextAttributes(uiStringAttributes, UIControlState.Selected);
    }

    private void SetBorder()
    {
        _nativeControl.Layer.BorderWidth = (NFloat)Element.BorderWidth;

        _nativeControl.Layer.BorderColor =
            Element.IsEnabled ? Element.BorderColor.ToCGColor() : Element.DisabledColor.ToCGColor();
    }

    private void NativeControl_SelectionChanged(object sender, System.EventArgs e)
    {
        Element.SelectedSegment = (int)_nativeControl.SelectedSegment;
    }

    protected override void Dispose(bool disposing)
    {
        if (!(_nativeControl is null))
        {
            _nativeControl.ValueChanged -= NativeControl_SelectionChanged;
            _nativeControl?.Dispose();
            _nativeControl = null;
        }

        RemoveElementHandlers();

        base.Dispose(disposing);
    }

    public static void Initialize()
    {
    }
}