using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.FileIO;

/// <summary>
/// Summary description for ImportStreet
/// </summary>
public class ImportCrimes : Import
{
    private TextFieldParser Content;
    private List<Theft> Objects;
    private List<Street> Streets;

    public ImportCrimes(string filename)
    {
        // Get file contents
        if (this.Get(filename))
        {
            // Gather all streets first to improve performance
            this.Streets = Street.All();

            // Transform contents to objects
            this.Objects = this.Implements();

            // Clear DB
            Db db = new Db();
            db.query("DELETE FROM `Thefts`; DELETE FROM `Objects`;");
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

    // Transform to Street objects
    private List<Theft> Implements()
    {
        TextFieldParser parser = this.Content;
        List<Theft> results = new List<Theft>();

        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(";");
        bool firstLine = true;

        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();

            // Skip table headings
            Street street = this.Streets.Find(i => i.Name.ToLower() == fields[9].ToLower());
            if (!firstLine && fields[7].Contains("ROTTERDAM") && street != null)
            {
                Theft theft = new Theft();

                for (int i = 0; i <= fields.Length - 1; i++)
                {
                    switch (i)
                    {
                        case 1:
                            // DateTime
                            theft.Date = DateTime.Parse(fields[i]);
                            break;

                        case 9:
                            // Street
                            theft.Street = street;
                            break;

                        case 21:
                            theft.ObjectName = Actions.FirstCharToUpper(fields[i]);
                            break;
                    }
                }

                results.Add(theft);
            }

            firstLine = false;
        }

        return results;
    }

    // Upload to database
    private bool Set()
    {
        Db db = new Db();
        // Insert all
        foreach (Theft theft in this.Objects)
        {
            if (!theft.Insert(db))
            {
                db.CloseConn();
                return false;
            }
        }

        db.CloseConn();
        return true;
    }
}