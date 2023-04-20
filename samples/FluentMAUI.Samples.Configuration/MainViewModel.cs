using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace FluentMAUI.Samples.Configuration;

public class MainViewModel : ObservableObject
{
    [ObservableProperty] string titleMessage = string.Empty;

    public MainViewModel()
	{
	}
}

