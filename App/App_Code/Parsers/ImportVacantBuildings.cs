using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for ImportVacantBuildings
/// </summary>
public class ImportVacantBuildings : Import
{
    private TextFieldParser Content;
    private List<VacantBuilding> Objects;

    public ImportVacantBuildings(string filename)
    {
        // Get file contents
        if (this.Get(filename))
        {
            // Transform contents to objects
            this.Objects = this.Implements();

            // Clear DB
            Db db = new Db();
            db.query("DELETE FROM `Vacant_Building`;");
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
        foreach (VacantBuilding vacantbuilding in this.Objects)
        {
            if (!vacantbuilding.Insert(db))
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
        int currentline = 0;

        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();

            //Skip table headings
            if (currentline >= 3)
            {
                VacantBuilding vacantbuilding = new VacantBuilding();

                for (int i = 0; i <= fields.Length - 1; i++)
                {
                    switch (i)
                    {
                        case 0:
                            vacantbuilding.HouseNumber = fields[i].Split(' ').Last();
                            string streetName = Regex.Replace(fields[i], vacantbuilding.HouseNumber, "");
                            streetName = streetName.TrimStart();
                            streetName = streetName.TrimEnd();
                            try
                            {
                                vacantbuilding.Street = Street.Get(Street.Find(streetName)[0].ID);
                            }
                            catch
                            {
                                vacantbuilding.Street = Street.Get(1);
                            }
                            break;

                        case 1:
                            vacantbuilding.Type = fields[i];
                            break;

                        case 3:
                            vacantbuilding.Status = fields[i];
                            break;

                        case 5:
                            if (Regex.IsMatch(fields[i], @"^[a-zA-Z]+$") || fields[i].Contains("-")
                                || fields[i].Contains(".") || fields[i].Contains("/"))
                            {
                                vacantbuilding.Space = 0;
                            }
                            else
                            {
                                bool containsaLetter = Regex.IsMatch(fields[i], "[A-Z]");
                                if (fields[i] == "" || containsaLetter == false)
                                {
                                    vacantbuilding.Space = 0;
                                }
                                else
                                {
                                    vacantbuilding.Space = Convert.ToInt32(fields[i]); 
                                }
                            }
                            break;

                        case 6:
                            fields[i] = fields[i].Replace("?", String.Empty);
                            fields[i] = fields[i].Replace(" ", String.Empty);
                            fields[i] = fields[i].Replace(",", ";");

                            bool containsLetter = Regex.IsMatch(fields[i], "[A-Z]");
                            if (fields[i] == "" || containsLetter == false)
                            {
                                vacantbuilding.Space = 0;
                            }
                            else
                            {
                                vacantbuilding.Rent = (float)Convert.ToDouble(fields[i]);
                            }
                            break;
                    }
                }

                results.Add(vacantbuilding);
            }

            currentline += 1;
        }

        return results;
    }
}