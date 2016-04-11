using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImportPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ButtonImport(object sender, EventArgs e)
    {
        new ImportStreet("assets/datasets/straatnamen-van-rotterdam.csv");
    }
}