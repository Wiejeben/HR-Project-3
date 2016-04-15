using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Theft
/// </summary>
public class Theft
{
    public int ID;
    public string ObjectName;
    public Street Street;
    public DateTime Date;
    public int Total;

    public Theft()
    {
    }

    public static List<Theft> All()
    {
        Db db = new Db();
        DataTable db_results = db.query("SELECT `Theft`.`theft_id`, `Object`.`name` AS `object_name`, `Theft`.`date`, `Street`.* FROM `Theft` INNER JOIN `Object` ON `Theft`.`object_id` = `Object`.`object_id` INNER JOIN `Street` ON `Theft`.`street_id` = `Street`.`street_id`;");

        List<Theft> results = new List<Theft>();

        foreach (DataRow row in db_results.Rows)
        {
            Theft theft = new Theft();

            theft.ID                = (int)row["theft_id"];
            theft.ObjectName        = (string)row["object_name"];

            // Create street
            theft.Street            = new Street();
            theft.Street.Name       = (string)row["name"];
            theft.Street.Intro      = (string)row["intro"];
            theft.Street.Content    = (string)row["content"];
            theft.Street.Pos        = new Vector2((double)row["lat"], (double)row["long"]);
            theft.Street.Exists     = (bool)row["exists"];
            theft.Street.Timespan   = (string)row["timespan"];

            theft.Date = (DateTime)row["date"];

            results.Add(theft);
        }

        db.CloseConn();
        return results;
    }

    public static List<Theft> AllGroupedBy(string column)
    {
        Db db = new Db();
        string query = "SELECT `Theft`.`theft_id`, `Object`.`name` AS `object_name`, `Theft`.`date`, `Street`.*, COUNT(`Street`.`street_id`) AS `amount` FROM `Theft` INNER JOIN `Object` ON `Theft`.`object_id` = `Object`.`object_id` INNER JOIN `Street` ON `Theft`.`street_id` = `Street`.`street_id` GROUP BY `Street`.`street_id`";
        DataTable db_results = db.query(query);

        List<Theft> results = new List<Theft>();

        foreach (DataRow row in db_results.Rows)
        {
            Theft theft = new Theft();

            theft.ID = Convert.ToInt32((uint)row["theft_id"]);
            theft.ObjectName = (string)row["object_name"];

            // Create street
            theft.Street = new Street();
            theft.Street.Name = (string)row["name"];
            theft.Street.Intro = (string)row["intro"];
            theft.Street.Content = (string)row["content"];
            theft.Street.Pos = new Vector2((double)row["lat"], (double)row["long"]);
            theft.Street.Exists = (bool)row["exists"];
            theft.Street.Timespan = (string)row["timespan"];

            theft.Date = (DateTime)row["date"];
            theft.Total = Convert.ToInt32(row["amount"]);

            results.Add(theft);
        }

        db.CloseConn();
        return results;
    }

    public static List<Theft> GetByYear()
    {
        Db db = new Db();
        DataTable db_results = db.query("SELECT YEAR(`Theft`.`date`) AS `year`, `Object`.`name`, COUNT(*) AS `amount` FROM `Object` LEFT JOIN `Theft` ON `Theft`.`object_id` = `Object`.`object_id` GROUP BY `Object`.`object_id`, YEAR(`Theft`.`date`)");

        List<Theft> results = new List<Theft>();

        foreach (DataRow row in db_results.Rows)
        {
            Theft theft = new Theft();

            theft.Date = new DateTime((int)row[0], 1, 1); ;
            theft.ObjectName = (string)row[1];
            theft.Total = Convert.ToInt32(row[2]);

            results.Add(theft);
        }

        db.CloseConn();
        return results;
    }

    public static List<Theft> Get(int id)
    {
        // Variables to be used.
        Db db = new Db();

        // Bind the field & value.
        db.bind("street_id", id.ToString());
        // Place the row with the query results in a variable.
        DataTable results = db.query("SELECT `name`, COUNT(o.object_id) as `total` FROM `Theft` as t LEFT JOIN `Object` as o ON t.object_id = o.object_id WHERE `street_id` = @street_id GROUP BY `name`");

        db.CloseConn();

        return DataTableToObjects(results);
        
    }

    private static List<Theft> DataTableToObjects(DataTable data)
    {
        List<Theft> results = new List<Theft>();

        foreach (DataRow row in data.Rows)
        {
            Theft robbery = new Theft();
            
            robbery.ObjectName = (string)row["name"];
            robbery.Total = Convert.ToInt32(row["total"]);
            results.Add(robbery);
        }

        return results;
    }

    public bool Insert(Db db)
    {
        db.qBind(new string[] { this.ObjectName });
        int object_id;
        string db_object_id = db.single("SELECT `object_id` FROM `Objects` WHERE `name` = @0");

        if (db_object_id != "")
        {
            object_id = Int32.Parse(db_object_id);
        }
        else
        {
            // Create new object if it doesn't exist yet
            db.qBind(new string[] { this.ObjectName });
            db.query("INSERT INTO `Objects` VALUES (null, @0);");

            object_id = db.last_inserted_id;
        }


        db.qBind(new string[] { object_id.ToString(), this.Street.ID.ToString(), this.Date.ToString("yyyy-MM-dd") });
        int affected = db.nQuery("INSERT INTO `Bike_Thefts` VALUES (null, @0, @1, @2);");

        return (affected >= 1);
    }
}