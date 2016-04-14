using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StreetLocation : System.Web.UI.Page
{
    // Variables that are used in all functionalities.
    protected int Id;

    protected string Name;
    protected string Intro;
    protected string Content;
    protected double Lat;
    protected double Long;
    protected bool Exists;
    protected string Timespan;
    protected double Distance;
    protected List<string> tempString = new List<string>();
    protected StringBuilder sb;

    // Variables that are used in methods.
    protected int attemptedId;

    protected Street foundStreet;

    protected void Page_Load(object sender, EventArgs e)
    {
        OV_ArrayGenerator();

        // Was there a parameter in the link?
        if (Request.QueryString != null && Request.QueryString.Count > 0)
        {
            // Did we receive the right parameter?
            if (Request.QueryString["hid"] != null)
            {
                // convert the parameter to ID
                attemptedId = Int32.Parse(Request.QueryString["hid"]);

                // Check if there's a street with the ID
                if (Street.Get(attemptedId) != null)
                {
                    // Define the variable again so we can use it to define values.
                    foundStreet = Street.Get(attemptedId);

                    Id = foundStreet.ID;
                    Name = foundStreet.Name;
                    Intro = foundStreet.Intro;
                    Content = foundStreet.Content;
                    Lat = foundStreet.Pos.X();
                    Long = foundStreet.Pos.Y();
                    Exists = foundStreet.Exists;
                    Timespan = foundStreet.Timespan;
                    Distance = Actions.getDistance(foundStreet.Pos, new Vector2(51.919980, 4.479993));

                    Page.Title = foundStreet.Name;

                    return;
                }
            }
        }

        throw new HttpException(404, "");
    }

    protected void OV_ArrayGenerator()
    {
        tempString.Add("\'Atlantis\', 35.7022077, 139.2722703");
        sb = new StringBuilder();
        sb.Append("<script type=\"text / javascript\">");
        sb.Append("var locations = new Array;");
        foreach (string str in tempString)
        {
            sb.Append("locations.push(" + str + ");");
        }
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "csname1", sb.ToString());
    }
}