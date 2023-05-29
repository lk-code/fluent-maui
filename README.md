# FluentMAUI

![FluentMAUI](https://raw.githubusercontent.com/lk-code/fluent-maui/main/resources/project-logo-128px.png)

a lot of useful components for .NET MAUI projects

Fluent MAUI consists of several nuget libraries. Each library contains components for a specific purpose.

## FluentMaui.UI

**For examples you can view the sample apps. this can be found at the /samples-directory**

First you need to initialize FluentMaui.UI in your MauiProgram.cs:

`builder.UseFluentUi(options =>`  
`{`   
`});`

### ToggleButton

`xmlns:fmcontrols="clr-namespace:FluentMAUI.UI.Controls;assembly=FluentMAUI.UI"`  
`...`   
`<fmcontrols:ToggleButton />`

#### access via Event

`<fmcontrols:ToggleButton Text="ToggleButton with Event"`   
` Toggled="ToggleButton_OnChecked" />`

#### access via Command

you can use the EventToCommandBehavior from .NET MAUI Community Toolkit

`<fmcontrols:ToggleButton.Behaviors>`   
`<toolkit:EventToCommandBehavior EventName="Toggled"`   
`Command="{Binding ToggleCommand}"`   
`EventArgsConverter="{StaticResource ToggledEventArgsConverter}" />`   
`</fmcontrols:ToggleButton.Behaviors>`

**notice:** you can find an example for the EventArgs-Converter (ToggledEventArgsConverter) in the samples-app.

#### ToggleButton Theming

* BackgroundColor: **Color**
* TextColor: **Color**
* CheckedBackgroundColor: **Color**
* CheckedTextColor: **Color**

### WidgetView

The WidgetView is based on the .NET MAUI Border control. You can use it to add any controls as child elements.

`xmlns:fmcontrols="clr-namespace:FluentMAUI.UI.Controls;assembly=FluentMAUI.UI"`  
`...`   
`<fmcontrols:WidgetView />`

#### WidgetView Theming

* BackgroundStyleType: **BackgroundStyleTypes** (Flat, Gradient) - If the Gradient property is used and the BackgroundColor property has been set, then a gradient is automatically generated as the background. The gradient is based on BackgroundColor and becomes darker towards the bottom (15% by default). Alternatively, the background can be set directly with a brush.

## FluentMaui.Configuration
An easy way to load appsettings into your .NET MAUI app.

Also, besides the primary appsettings.json, there is an option to load appsettings per platform and environment (e.g. **appsettings.android.json**, **appsettings.Debug.json** or **appsettings.ios.Release.json**, etc.).

The filename pattern is as follows: **appsettings.{platform}.{environment}.json** (platform and environment are both optional)

**platforms:**
* maccatalyst
* ios
* android
* winui

**environments:**
* Debug
* Release

### configure
`builder.UseFluentConfiguration(options =>`  
`{`  
`// LoadAppsettingsFrom-Assembly is optional for ios, macos, winui BUT REQUIRED on android`  
`options.LoadAppsettingsFrom = Assembly.GetExecutingAssembly();`  
`});`

* **LoadAppsettingsFrom:** Define the assembly where the appsettings are located as resource files (EmbeddedResource).