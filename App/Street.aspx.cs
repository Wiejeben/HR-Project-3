using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StreetLocation : System.Web.UI.Page
{
    // Variables
    protected int Id;
    protected string Name;
    protected string Intro;
    protected string Content;
    protected float Lat;
    protected float Long;
    protected int Exists;
    protected string Timespan;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Hebben we een parameter ontvangen?
        if (Request.QueryString != null && Request.QueryString.Count > 0)
        {
            // Is het wel de juiste parameter?
            if (Request.QueryString["hid"] != null)
            {
                // Hier doen we een query uitvoeren om te checken of het bestaat.
            }

            Name = "Lorem ipsum";
            Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus et placerat diam. Sed sed velit fringilla, commodo odio vel, viverra lectus.";
            Content = "Fusce aliquam accumsan elit, a fringilla lorem interdum tincidunt. Duis vel suscipit dolor, in laoreet tellus. In laoreet massa et fringilla facilisis. Donec sed magna ligula. Nunc varius efficitur dapibus. Vivamus a elit sollicitudin, feugiat odio id, dapibus ex. Cras eu lacus eget justo consequat commodo non non arcu. Vestibulum tempus elementum pulvinar. Ut sit amet nulla mi.";
        }
        else
        {
            // Redirect implementation
            // Server.Transfer("Default.aspx", true);
        }
    }
}