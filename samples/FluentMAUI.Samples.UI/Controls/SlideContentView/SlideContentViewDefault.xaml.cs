using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMAUI.Samples.UI.Controls.SlideContentView;

public partial class SlideContentViewDefault : ContentPage
{
    private readonly SlideContentViewDefaultVM _viewModel;

    public SlideContentViewDefault(SlideContentViewDefaultVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}