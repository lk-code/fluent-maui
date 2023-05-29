namespace FluentMAUI.UI.Extensions;

public static class NumericExtensions
{
    public static byte ToByte(this float value)
    {
        return (byte) (value * 255);
    }
}