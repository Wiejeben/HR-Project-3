using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public class Search_Result_Street
{
    public int ID;
    public string Name;

    public Search_Result_Street(int id, string name)
    {
        this.ID = id;
        this.Name = name;
    }
}

public partial class Search_Ajax : System.Web.UI.Page
{
    protected string JSONResponse;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["q"] != null)
        {
            string query = Request.QueryString["q"];
            List<Search_Result_Street> streets = new List<Search_Result_Street>();

            // Only give names
            foreach (Street street in Street.Find(query, 10))
            {
                Search_Result_Street result = new Search_Result_Street(street.ID, street.Name);

                streets.Add(result);
            }

            // JSON parser
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            // Results
            this.JSONResponse = jsonSerializer.Serialize(streets);
        }
    }
}