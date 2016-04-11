using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    public string query;
    public List<Street> results;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString != null && Request.QueryString.Count > 0)
        {
            if (Request.QueryString["q"] != null)
            {
                query = Request.QueryString["q"];
                
                results = Street.Find(query);
            }
        }
        else
        {
            // Redirect implementation if no search string was entered
            // Server.Transfer("Default.aspx", true);
        }
    }
}