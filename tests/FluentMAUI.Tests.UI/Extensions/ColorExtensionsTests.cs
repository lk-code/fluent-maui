using FluentAssertions;
using FluentMAUI.Core.Color;
using FluentMAUI.Core.Extensions;
using Microsoft.Maui.Graphics;

namespace FluentMAUI.Tests.UI.Extensions;

[TestClass]
public class ColorExtensionsTests
{
    [TestInitialize]
    public void SetUp()
    {
    }
    
    [TestMethod]
    public void ToColor_WithRed_ReturnsExpected()
    {
        RGB rgb = new RGB(255, 0, 0);
        Color color = rgb.ToColor();
        
        color.Red.Should().Be(1);
        color.Green.Should().Be(0);
        color.Blue.Should().Be(0);
    }
    
    [TestMethod]
    public void ToColor_WithWhite_ReturnsExpected()
    {
        RGB rgb = new RGB(255, 255, 255);
        Color color = rgb.ToColor();
        
        color.Red.Should().Be(1);
        color.Green.Should().Be(1);
        color.Blue.Should().Be(1);
    }
    
    [TestMethod]
    public void ToRGB_WithRed_ReturnsExpected()
    {
        Color color = new Color(1f, 0f, 0f);
        RGB rgb = color.ToRGB();
        
        rgb.R.Should().Be(255);
        rgb.G.Should().Be(0);
        rgb.B.Should().Be(0);
    }
    
    [TestMethod]
    public void ToRGB_WithWhite_ReturnsExpected()
    {
        Color color = new Color(1f, 1f, 1f);
        RGB rgb = color.ToRGB();
        
        rgb.R.Should().Be(255);
        rgb.G.Should().Be(255);
        rgb.B.Should().Be(255);
    }
    
    [TestMethod]
    public void ToRGB_WithSpecificRGB_ReturnsExpected()
    {
        Color color = new Color(0.5f, 0.33f, 0f);
        RGB rgb = color.ToRGB();
        
        rgb.R.Should().Be(127);
        rgb.G.Should().Be(84);
        rgb.B.Should().Be(0);
    }
    
    [TestMethod]
    public void Darken_WithPureBlueRgbAndTenPercent_ReturnsExpected()
    {
        RGB rgb = new RGB(0, 0, 255);
        Color color = rgb.ToColor();

        var darkedColor = color.Darken(10);
        var darkedRgb = darkedColor.ToRGB();
        
        darkedRgb.R.Should().Be(0);
        darkedRgb.G.Should().Be(0);
        darkedRgb.B.Should().Be(230);
    }
    
    [TestMethod]
    public void Darken_WithBlueRgbAndTenPercent_ReturnsExpected()
    {
        RGB rgb = new RGB(15, 15, 255);
        Color color = rgb.ToColor();

        var darkedColor = color.Darken(10);
        var darkedRgb = darkedColor.ToRGB();
        
        darkedRgb.R.Should().Be(0);
        darkedRgb.G.Should().Be(0);
        darkedRgb.B.Should().Be(239);
    }
    
    [TestMethod]
    public void Lighten_WithBlueRgbAndTenPercent_ReturnsExpected()
    {
        RGB rgb = new RGB(0, 0, 232);
        Color color = rgb.ToColor();

        var lightedColor = color.Lighten(10);
        var lightedRgb = lightedColor.ToRGB();
        
        lightedRgb.R.Should().Be(0);
        lightedRgb.G.Should().Be(0);
        lightedRgb.B.Should().Be(252);
    }
    
    [TestMethod]
    public void Lighten_WithPureBlueRgbAndTenPercent_ReturnsExpected()
    {
        RGB rgb = new RGB(0, 0, 255);
        Color color = rgb.ToColor();

        var lightedColor = color.Lighten(10);
        var lightedRgb = lightedColor.ToRGB();
        
        lightedRgb.R.Should().Be(26);
        lightedRgb.G.Should().Be(26);
        lightedRgb.B.Should().Be(255);
    }
}