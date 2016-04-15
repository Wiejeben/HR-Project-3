﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Heatmap : System.Web.UI.Page
{
    protected List<Theft> Thefts;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Thefts = Theft.AllGroupedBy("`Street`.`street_id`");
    }
}