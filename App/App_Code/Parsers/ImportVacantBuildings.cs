using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImportTransportStop
/// </summary>
public class ImportVacantBuildings : Import
{
    private TextFieldParser Content;
    private List<TransportStop> Objects;

    public ImportVacantBuildings(string filename)
    {
        // Get file contents
        if (this.Get(filename))
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

    // Transform to VacantBuildings objects
    private List<VacantBuilding> Implements()
    {
        TextFieldParser parser = this.Content;
        List<VacantBuilding> results = new List<VacantBuilding>();

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
                VacantBuilding vacantbuilding = new VacantBuilding();
                vacantbuilding.Pos = new Vector2(Actions.ParseDouble(fields[2]), Actions.ParseDouble(fields[3]));

                for (int i = 0; i <= fields.Length - 1; i++)
                {
                    switch (i)
                    {
                        case 0:
                            vacantbuilding.Name = fields[i];
                            break;

                        case 1:
                            vacantbuilding.Description = fields[i];
                            break;
                    }
                }

                results.Add(vacantbuilding);
            }

            firstLine = false;
        }

        return results;
    }
}