using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public partial class Search_Ajax : System.Web.UI.Page
{
    protected string JSONResponse;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["q"] != null)
        {
            string query = Request.QueryString["q"];
            List<dynamic> streets = new List<dynamic>();

            // Only give names
            foreach (Street street in Street.Find(query, 10))
            {
                dynamic result = new { ID = street.ID, Name = street.Name };

                streets.Add(result);
            }

            // JSON parser
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            // Results
            this.JSONResponse = jsonSerializer.Serialize(streets);
        }
    }
}