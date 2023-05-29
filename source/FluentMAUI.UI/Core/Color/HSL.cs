namespace FluentMAUI.UI.Core.Color;

public struct HSL
{
    private int _h;
    private float _s;
    private float _l;

    public HSL(int h, float s, float l)
    {
        this._h = h;
        this._s = s;
        this._l = l;
    }

    public int H
    {
        get { return this._h; }
        set { this._h = value; }
    }

    public float S
    {
        get { return this._s; }
        set { this._s = value; }
    }

    public float L
    {
        get { return this._l; }
        set { this._l = value; }
    }

    public bool Equals(HSL hsl)
    {
        return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
    }
    
    public override string ToString()
    {
        return $"H: {H}, S: {S}, L: {L}";
    }
}