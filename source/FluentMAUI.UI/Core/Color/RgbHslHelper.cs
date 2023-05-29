namespace FluentMAUI.UI.Core.Color;

public static class RgbHslHelper
{
    public static HSL ToHSL(this RGB rgb)
    {
        HSL hsl = new HSL();

        float red = (rgb.R / 255.0f);
        float green = (rgb.G / 255.0f);
        float blue = (rgb.B / 255.0f);

        float minValue = Math.Min(Math.Min(red, green), blue);
        float maxValue = Math.Max(Math.Max(red, green), blue);
        float delta = maxValue - minValue;

        hsl.L = (maxValue + minValue) / 2;

        if (delta == 0)
        {
            hsl.H = 0;
            hsl.S = 0.0f;
        }
        else
        {
            hsl.S = (hsl.L <= 0.5) ? (delta / (maxValue + minValue)) : (delta / (2 - maxValue - minValue));

            float hueValue = 0;

            if (red == maxValue)
            {
                hueValue = ((green - blue) / 6) / delta;
            }
            else if (green == maxValue)
            {
                hueValue = (1.0f / 3) + ((blue - red) / 6) / delta;
            }
            else
            {
                hueValue = (2.0f / 3) + ((red - green) / 6) / delta;
            }

            if (hueValue < 0)
            {
                hueValue += 1;
            }

            if (hueValue > 1)
            {
                hueValue -= 1;
            }

            hsl.H = (int)(hueValue * 360);
        }
        
        hsl.S = (hsl.S * 100);
        hsl.L = Convert.ToSingle(Math.Round(Convert.ToDouble(hsl.L * 100), 0, MidpointRounding.ToZero));

        return hsl;
    }

    public static RGB ToRGB(this HSL hsl)
    {
        float h = hsl.H / 360.0f;
        float s = hsl.S / 100.0f;
        float l = hsl.L / 100.0f;

        float r, g, b;

        if (s == 0)
        {
            r = g = b = l;
        }
        else
        {
            float q = l < 0.5f ? l * (1.0f + s) : l + s - l * s;
            float p = 2.0f * l - q;

            r = HueToRGB(p, q, h + 1.0f / 3.0f);
            g = HueToRGB(p, q, h);
            b = HueToRGB(p, q, h - 1.0f / 3.0f);
        }

        byte red = (byte)(r * 255.0f + 0.5f);
        byte green = (byte)(g * 255.0f + 0.5f);
        byte blue = (byte)(b * 255.0f + 0.5f);

        return new RGB(red, green, blue);
    }

    private static float HueToRGB(float p, float q, float t)
    {
        if (t < 0)
            t += 1;
        if (t > 1)
            t -= 1;

        if (t < 1.0f / 6.0f)
            return p + (q - p) * 6 * t;
        if (t < 1.0f / 2.0f)
            return q;
        if (t < 2.0f / 3.0f)
            return p + (q - p) * (2.0f / 3.0f - t) * 6;

        return p;
    }
}