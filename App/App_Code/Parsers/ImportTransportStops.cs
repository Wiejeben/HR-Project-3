using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.FileIO;

/// <summary>
/// Summary description for ImportTransportStop
/// </summary>
public class ImportTransportStops : Import
{
    private TextFieldParser Content;
    private List<TransportStop> Objects;

    public ImportTransportStops(string filename)
    {
        // Get file contents
        if(this.Get(filename))
        {
            // Transform contents to objects
            this.Objects = this.Implements();

            // Clear DB
            Db db = new Db();
            db.query("DELETE FROM `transportstops`;");
            db.CloseConn();

            // Upload to database
            bool success = this.Set();
        }
    }

    // Get file contents
    private bool Get(string filename)
    {
        try
        {
            this.Content = new TextFieldParser(HttpContext.Current.Server.MapPath(filename));

            return true;
        }
        catch (System.IO.FileNotFoundException message)
        {
            return false;
        }
    }

    // Upload to database
    private bool Set()
    {
        Db db = new Db();
        // Insert all
        foreach (TransportStop transportstop in this.Objects)
        {
            if (!transportstop.Insert(db))
            {
                db.CloseConn();
                return false;
            }
        }

        db.CloseConn();
        return true;
    }

    // Transform to transportstops objects
    private List<TransportStop> Implements()
    {
        TextFieldParser parser = this.Content;
        List<TransportStop> results = new List<TransportStop>();

        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(";");
        bool firstLine = true;

        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();

            // Skip table headings
            if (!firstLine)
            {
                TransportStop transportstop = new TransportStop();
                transportstop.Pos = new Vector2(Actions.ParseDouble(fields[2]), Actions.ParseDouble(fields[3]));

                for (int i = 0; i <= fields.Length - 1; i++)
                {
                    switch (i)
                    {
                        case 0:
                            transportstop.Name = fields[i];
                            break;

                        case 1:
                            transportstop.Description = fields[i];
                            break;
                    }
                }

                results.Add(transportstop);
            }

            firstLine = false;
        }

        return results;
    }
}