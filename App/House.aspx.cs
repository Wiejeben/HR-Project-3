using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class House : System.Web.UI.Page
{
    // Variables
    protected int houseId;
    protected string houseName;
    protected string houseIntro;
    protected string houseContent;
    protected float houseLat;
    protected float houseLong;
    protected int houseExists;
    protected string houseTimespan;

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

            houseName = "Lorem ipsum";
            houseIntro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus et placerat diam. Sed sed velit fringilla, commodo odio vel, viverra lectus.";
            houseContent = "Fusce aliquam accumsan elit, a fringilla lorem interdum tincidunt. Duis vel suscipit dolor, in laoreet tellus. In laoreet massa et fringilla facilisis. Donec sed magna ligula. Nunc varius efficitur dapibus. Vivamus a elit sollicitudin, feugiat odio id, dapibus ex. Cras eu lacus eget justo consequat commodo non non arcu. Vestibulum tempus elementum pulvinar. Ut sit amet nulla mi.";
        }
        else
        {
            // Redirect implementation
            // Server.Transfer("Default.aspx", true);
        }
    }
}