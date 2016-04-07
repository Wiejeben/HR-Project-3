using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    public string query;
    public List<int> results = new List<int>(new int[]{ 1,2,3,4,5 });
    protected void Page_Load(object sender, EventArgs e)
    {
        // Hebben we een parameter ontvangen?
        if (Request.QueryString != null && Request.QueryString.Count > 0)
        {
            // Is het wel de juiste parameter?
            if (Request.QueryString["q"] != null)
            {
                query = Request.QueryString["q"];
                // Hier doen we een query uitvoeren om te checken of het bestaat.
            }
        }
        else
        {
            // Redirect implementation
            // Server.Transfer("Default.aspx", true);
        }
    }
}