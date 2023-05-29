using FluentMAUI.UI.Core.Color;

namespace FluentMAUI.UI.Extensions;

public static class ColorExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static RGB ToRGB(this Color color)
    {
        var red = color.Red.ToByte();
        var green = color.Green.ToByte();
        var blue = color.Blue.ToByte();

        return new RGB(red, green, blue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rgb"></param>
    /// <returns></returns>
    public static Color ToColor(this RGB rgb)
    {
        return new Color(rgb.R, rgb.G, rgb.B);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public static Color Darken(this Color color, double percentage)
    {
        HSL hsl = color.ToRGB().ToHSL();
        double lightness = hsl.L;

        double newLightness = lightness - (lightness * percentage / 100);
        newLightness = Math.Max(newLightness, 0);
        newLightness = Math.Min(newLightness, 100);

        HSL newColor = new HSL(hsl.H, hsl.S, Convert.ToSingle(newLightness));
        return newColor.ToRGB().ToColor();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public static Color Lighten(this Color color, double percentage)
    {
        HSL hsl = color.ToRGB().ToHSL();
        double lightness = hsl.L;

        double newLightness = lightness + (lightness * percentage / 100);
        newLightness = Math.Max(newLightness, 0);
        newLightness = Math.Min(newLightness, 100);

        HSL newColor = new HSL(hsl.H, hsl.S, Convert.ToSingle(newLightness));
        return newColor.ToRGB().ToColor();
    }
}