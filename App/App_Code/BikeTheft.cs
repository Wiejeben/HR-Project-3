using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BikeTheft
/// </summary>
public class BikeTheft
{
    public int ID;
    public string ObjectName;
    public Street Street;
    public DateTime Date;

    public BikeTheft()
    {
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