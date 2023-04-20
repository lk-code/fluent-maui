namespace FluentMAUI.Samples.Configuration;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}