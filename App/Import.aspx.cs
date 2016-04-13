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
        new ImportStreets("assets/datasets/straatnamen-van-rotterdam.csv");
    }

    public void ButtonImportCrimes(object sender, EventArgs e)
    {
        new ImportCrimes("assets/datasets/fietsdiefstallen.csv");
    }
    public void ButtonImportTr(object sender, EventArgs e)
    {
        new ImportTransportStops("assets/datasets/RET-haltebestand.csv");
    }
}