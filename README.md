# fluent-maui
a lot of useful components for .NET MAUI projects

Fluent MAUI consists of several nuget libraries. Each library contains components for a specific purpose.

## FluentMaui.Configuration
An easy way to load appsettings into your .NET MAUI app.

Also, besides the primary appsettings.json, there is an option to load appsettings per platform and environment (e.g. **appsettings.android.json**, **appsettings.Development.json** or **appsettings.ios.Release.json**, etc.).

The filename pattern is as follows: **appsettings.{platform}.{environment}.json** (platform and environment are both optional)