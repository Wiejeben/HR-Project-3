using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string query;
    public string abc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {
            // There's only one element, so the index is 0.
            query = Request.Form[0];

            // If it isn't empty / null.
            if(!string.IsNullOrWhiteSpace(query))
            {
                Response.Redirect("Search.aspx?q=" + query);
            }
            
        }
    }
}