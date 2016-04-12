using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Vector2
{
    public double X { get; }
    public double Y { get; }

    public Vector2(double posx, double posy)
    {
        this.X = posx;
        this.Y = posy;
    }
}