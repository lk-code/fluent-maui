namespace FluentMAUI.UI.Core.Color;

public struct RGB
{
    private byte _r;
    private byte _g;
    private byte _b;

    public RGB(byte r, byte g, byte b)
    {
        this._r = r;
        this._g = g;
        this._b = b;
    }

    public byte R
    {
        get { return this._r; }
        set { this._r = value; }
    }

    public byte G
    {
        get { return this._g; }
        set { this._g = value; }
    }

    public byte B
    {
        get { return this._b; }
        set { this._b = value; }
    }

    public bool Equals(RGB rgb)
    {
        return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
    }

    public override string ToString()
    {
        return $"R: {R}, G: {G}, B: {B}";
    }
}