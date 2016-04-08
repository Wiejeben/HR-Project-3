using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Init database
        // MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=root;database=project3;");
        // conn.Open();
    }
}
