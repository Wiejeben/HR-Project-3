using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.FileIO;

/// <summary>
/// Summary description for ImportStreet
/// </summary>
public class ImportStreet : Import
{
    private TextFieldParser Content;
    private List<Street> Object;

    public ImportStreet(string filename)
    {
        // Get file contents
        if(this.Get(filename))
        {
            // Transform contents to objects
            List<Street> objects = this.Implements();
            this.Object = objects;

            // Clear DB
            Db db = new Db();
            db.query("TRUNCATE `Street`;");
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
            string path = HttpContext.Current.Server.MapPath(filename);
            TextFieldParser result = new TextFieldParser(HttpContext.Current.Server.MapPath(filename));
            this.Content = result;

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
        // Insert all
        foreach (Street street in this.Object)
        {
            street.Insert();
        }

        return true;
    }

    // Transform to Street objects
    private List<Street> Implements()
    {
        TextFieldParser parser = this.Content;
        List<Street> results = new List<Street>();

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
                Street street = new Street();
                street.Pos = new Vector2(Actions.ParseDouble(fields[6]), Actions.ParseDouble(fields[7]));

                for (int i = 0; i <= fields.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            street.ID = int.Parse(fields[i]);
                            break;

                        case 11:
                            street.Name = fields[i];
                            break;

                        case 12:
                            street.Intro = fields[i];
                            break;

                        case 13:
                            street.Content = fields[i];
                            break;

                        case 15:
                            street.Exists = (fields[i] == "Bestaand");
                            break;
                    }
                }

                results.Add(street);
            }

            firstLine = false;
        }

        return results;
    }
}