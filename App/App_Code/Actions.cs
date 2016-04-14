using System;
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

    public static double getDistance(Vector2 pos1, Vector2 pos2)
    {
        var sLatitudeRadians = pos1.X * (Math.PI / 180.0);
        var sLongitudeRadians = pos1.Y * (Math.PI / 180.0);
        var eLatitudeRadians = pos2.X * (Math.PI / 180.0);
        var eLongitudeRadians = pos2.Y * (Math.PI / 180.0);

        var dLongitude = eLongitudeRadians - sLongitudeRadians;
        var dLatitude = eLatitudeRadians - sLatitudeRadians;

        var result1 = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                      Math.Cos(sLatitudeRadians) * Math.Cos(eLatitudeRadians) *
                      Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

        // Using 3956 as the number of miles around the earth
        var result2 = (int)(3956.0 * 2.0 *
                      Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1)) * 1000);

        return result2;
    }

    public static string FirstCharToUpper(string s)
    {
        // Check for empty string
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        // Return char and concat substring
        return char.ToUpper(s[0]) + s.Substring(1).ToLower();
    }
}