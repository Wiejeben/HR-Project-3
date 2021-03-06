﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;


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
                this.query = Request.QueryString["q"];

                this.results = Street.Find(this.query);

                Page.Title = this.query;
                search_ac.Value = this.query;
            }
        }
    }

    [WebMethod]
    public static string Find(string query)
    {
        // Get all the results with the entered query.
        List<Street> results = Street.Find(query, 10);

        List<string> streetNames = new List<string>();
        // We only want the names, so we place this in a string list.
        foreach (Street street in results)
        {
            streetNames.Add(street.Name);
        }
        // Json serializer to convert the names into a json string
        var jsonSerializer = new JavaScriptSerializer();
        var jsonNames = jsonSerializer.Serialize(streetNames);

        if(jsonNames != "[]")
        {
            // Return the json string to the ajax call
            return jsonNames;
        }
        else
        {
            return null;
        }
    }
}