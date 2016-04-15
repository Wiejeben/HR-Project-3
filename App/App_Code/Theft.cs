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
    public int ID, Year, Amount;
    public string ObjectName, Name;
    public Street Street;
    public DateTime Date;
    public int Total;

    public Theft()
    {
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

    public static List<Theft> GetByYear()
    {
        Db db = new Db();
        DataTable db_results = db.query("SELECT YEAR(`Theft`.`date`) AS `year`, `Object`.`name`, COUNT(*) AS `amount` FROM `Object` LEFT JOIN `Theft` ON `Theft`.`object_id` = `Object`.`object_id` GROUP BY `Object`.`object_id`, YEAR(`Theft`.`date`)");

        List<Theft> results = new List<Theft>();

        foreach (DataRow row in db_results.Rows)
        {
            Theft theft = new Theft();

            theft.Year = (int)row[0];
            theft.Name = (string)row[1];
            theft.Amount = Convert.ToInt32(row[2]);

            results.Add(theft);
        }

        db.CloseConn();
        return results;
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