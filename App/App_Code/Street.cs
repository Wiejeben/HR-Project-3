using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Street : Location
{
    public int ID;
    public string Name, Intro, Content;
    public Vector2 Pos { get; set; }
    public bool Exists;
    public string Timespan;

    public Street()
    {
    }

    public static List<Street> All()
    {
        Db db = new Db();
        DataTable db_results = db.query("SELECT * FROM `Street`");

        List<Street> results = new List<Street>();

        foreach (DataRow row in db_results.Rows)
        {
            Street street = new Street();

            street.ID = (int)row["street_id"];
            street.Name = (string)row["name"];

            street.Intro = (string)row["intro"];
            street.Content = (string)row["content"];

            street.Pos = new Vector2((double)row["lat"], (double)row["long"]);

            results.Add(street);
        }

        return results;
    }

    public static List<DataObject> Find(string query)
    {
        return new List<DataObject>();
    }
    
    public static Street Get(int id)
    {
        // Variables to be used.
        Db db = new Db();

        // Bind the field & value.
        db.bind("street_id", id.ToString());
        // Place the row with the query results in a variable.
        string[] attemptedStreet = db.row("SELECT * FROM `Street` WHERE `street_id` = @street_id");
        // We have a result
        if(attemptedStreet[0] != null)
        {
            Street foundStreet = new Street();

            // Set data onto the instance.
            foundStreet.ID = Int32.Parse(attemptedStreet[0]);
            foundStreet.Name = attemptedStreet[1];
            foundStreet.Intro = attemptedStreet[2];
            foundStreet.Content = attemptedStreet[3];
            foundStreet.Pos = new Vector2(Convert.ToDouble(attemptedStreet[4]), Convert.ToDouble(attemptedStreet[5]));
            foundStreet.Exists = Convert.ToBoolean(attemptedStreet[6]);
            foundStreet.Timespan = attemptedStreet[7];

            return foundStreet;
        }
        else
        {
            return null;
        }
    }
}