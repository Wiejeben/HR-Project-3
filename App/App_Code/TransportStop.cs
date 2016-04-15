using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class TransportStop : Location
{
    public string Name;
    public Vector2 Pos { get; set; }
    public string Description;

    public TransportStop()
    {
    }

    public static List<TransportStop> All(bool group = false)
    {
        Db db = new Db();
        DataTable db_results = new DataTable();

        if (group)
        {
            db_results = db.query("SELECT * FROM `Public_Transport` GROUP BY `stopname`");
        }
        else
        {
            db_results = db.query("SELECT * FROM `Public_Transport`");
        }

        List<TransportStop> results = new List<TransportStop>();

        foreach (DataRow row in db_results.Rows)
        {
            TransportStop transportstop = new TransportStop();

            transportstop.Name = (string)row["stopname"];
            transportstop.Description = (string)row["description"];
            transportstop.Pos = new Vector2((double)row["lat"], (double)row["long"]);
            results.Add(transportstop);
        }

        db.CloseConn();
        return results;
    }

    public double Distance(Vector2 location)
    {
        return Actions.getDistance(this.Pos, location);
    }

    public bool Insert(Db db)
    {
        db.qBind(new string[] { this.Name, this.Description, this.Pos.X.ToString(), this.Pos.Y.ToString() });
        int affected = db.nQuery("INSERT INTO `Public_Transport` VALUES (null, @0, @1, @2, @3);");

        return (affected >= 1);
    }

    public static List<TransportStop> Find(string query)
    {
        Db db = new Db();
        List<TransportStop> results = new List<TransportStop>();

        db.bind("query", "%" + query + "%");
        DataTable db_results = db.query("SELECT * FROM `Public_Transport` WHERE `name` LIKE @query");

        foreach (DataRow row in db_results.Rows)
        {
            TransportStop transportstop = new TransportStop();

            transportstop.Name = (string)row["name"];
            transportstop.Description = (string)row["description"];
            transportstop.Pos = new Vector2((double)row["lat"], (double)row["long"]);

            results.Add(transportstop);
        }

        db.CloseConn();
        return results;
    }

    public static TransportStop Get(string name)
    {
        // Variables to be used.
        Db db = new Db();

        // Place the row with the query results in a variable.
        db.qBind(new string[] { name });
        string[] attemptedTransportStop = db.row("SELECT * FROM `Public_Transport` WHERE `transport_name` = @0");
        // We have a result
        if (attemptedTransportStop[0] != null)
        {
            TransportStop foundTransportStop = new TransportStop();

            // Set data onto the instance.
            foundTransportStop.Name = attemptedTransportStop[0];
            foundTransportStop.Description = attemptedTransportStop[1];
            foundTransportStop.Pos = new Vector2(Convert.ToDouble(attemptedTransportStop[2]), Convert.ToDouble(attemptedTransportStop[3]));

            return foundTransportStop;
        }

        return null;
    }
}