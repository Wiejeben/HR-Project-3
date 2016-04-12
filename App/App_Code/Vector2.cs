using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Vector2
{
    double _x;
    double _y;

    public Vector2(double posx, double posy)
    {
        this._x = posx;
        this._y = posy;
    }

    public double X()
    {
        return this._x;
    }

    public double Y()
    {
        return this._y;
    }
}