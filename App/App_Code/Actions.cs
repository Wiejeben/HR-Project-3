﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Actions
{
    public static List<Location> inRadius(List<Location> locations, Vector2 center, int radius)
    {
        //unfinished
        return new List<Location>();
    }
    public static int getDistance(Location pos1, Location pos2) {
        {
            //unfinished
            return 69;
        }
    }
    public static double ParseDouble(string input)
    {
        input = input.Replace(',', '.');

        double output;
        if (!double.TryParse(input, out output))
        {
            output = 0.0;
        }

        return output;
    }
}