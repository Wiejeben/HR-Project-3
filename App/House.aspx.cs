using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class House : System.Web.UI.Page
{
    // Variables
    protected string houseName;
    protected string houseIntro;
    protected string houseContent;
    protected float houseLat;
    protected float houseLong;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Hebben we een
        if (Request.QueryString != null && Request.QueryString.Count > 0)
        {
            houseName = "Hi";
        }
        else
        {
            // Redirect implementation
            // Server.Transfer("Default.aspx", true);
        }
    }
}