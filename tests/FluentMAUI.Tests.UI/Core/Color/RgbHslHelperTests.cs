using FluentAssertions;
using FluentMAUI.UI.Core.Color;

namespace FluentMAUI.Tests.UI.Core.Color;

[TestClass]
public class RgbHslHelperTests
{
    [TestInitialize]
    public void SetUp()
    {
    }
    
    [TestMethod]
    public void ToHSL_WithSomeValues_ReturnsExpected()
    {
        // Arrange
        Dictionary<RGB, HSL> testValues = new()
        {
            { new RGB(255, 255, 255), new HSL(0, 0, 100) },
            { new RGB(0, 0, 0), new HSL(0, 0, 0) },
            { new RGB(255, 0, 0), new HSL(0, 100, 50) },
            { new RGB(0, 255, 0), new HSL(120, 100, 50) },
            { new RGB(0, 0, 255), new HSL(240, 100, 50) },
            { new RGB(255, 255, 0), new HSL(60, 100, 50) },
            { new RGB(255, 0, 255), new HSL(300, 100, 50) },
            { new RGB(0, 255, 255), new HSL(180, 100, 50) },
            { new RGB(128, 128, 128), new HSL(0, 0, 50) },
            { new RGB(128, 0, 0), new HSL(0, 100, 25) }
        };


        // Act
        int i = 0;
        foreach (var testValue in testValues)
        {
            var hslValue = testValue.Key.ToHSL();
            var rgbBackValue = hslValue.ToRGB();

            // Assert
            hslValue.Should().Be(testValue.Value);
            rgbBackValue.Should().Be(testValue.Key);
            i++;
        }
    }
}