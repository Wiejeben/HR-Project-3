using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class VacantBuilding
{
    public int HouseNumber;
    public Street Street;

    public string Type;
    public string Status;
    public string Owner;
    public int Space;
    public float Rent;

    public VacantBuilding()
    {
    }

    public List<VacantBuilding> All()
    {
        Db db = new Db();
        DataTable db_results = db.query("SELECT * FROM `Vacant_Building`");

        List<VacantBuilding> results = new List<VacantBuilding>();

        foreach (DataRow row in db_results.Rows)
        {
            VacantBuilding vacantbuilding = new VacantBuilding();

            vacantbuilding.HouseNumber = (int)row["house_number"];
            vacantbuilding.Street = Street.Get((int)row["street_id"]);
            vacantbuilding.Type = (string)row["type"];
            vacantbuilding.Status = (string)row["status"];
            vacantbuilding.Owner = (string)row["owner"];
            vacantbuilding.Space = (int)row["space"];
            vacantbuilding.Rent = (float)row["rent"];

            results.Add(vacantbuilding);
        }

        db.CloseConn();
        return results;
    }

    public bool Insert(Db db)

    {
        db.qBind(new string[] { this.HouseNumber.ToString(), this.Street.ID.ToString(), this.Type,
            this.Status, this.Owner, this.Space.ToString(), this.Rent.ToString() });
        int affected = db.nQuery("INSERT INTO `Vacant_Building` VALUES (@0, @1, @2, @3, @4, @5, @6);");

        return (affected >= 1);
    }

    public static List<VacantBuilding> Find(string query)
    {
        Db db = new Db();
        List<VacantBuilding> results = new List<VacantBuilding>();

        db.bind("query", "%" + query + "%");
        DataTable db_results = db.query("SELECT * FROM `Vacant_Building` WHERE `name` LIKE @query");

        foreach (DataRow row in db_results.Rows)
        {
            VacantBuilding vacantbuilding = new VacantBuilding();

            vacantbuilding.HouseNumber = (int)row["house_number"];
            vacantbuilding.Street = Street.Get((int)row["street_id"]);
            vacantbuilding.Type = (string)row["type"];
            vacantbuilding.Status = (string)row["status"];
            vacantbuilding.Owner = (string)row["owner"];
            vacantbuilding.Space = (int)row["space"];
            vacantbuilding.Rent = (float)row["rent"];

            results.Add(vacantbuilding);
        }

        db.CloseConn();
        return results;
    }

    public static VacantBuilding Get(string name)
    {
        // Variables to be used.
        Db db = new Db();

        // Place the row with the query results in a variable.
        string[] attemptedTransportStop = db.row("SELECT * FROM `Vacant_Building` WHERE `transport_name` = @transport_name");
        // We have a result
        if (attemptedTransportStop[0] != null)
        {
            VacantBuilding foundVacantBuilding = new VacantBuilding();

            // Set data onto the instance.
            foundVacantBuilding.Name = attemptedTransportStop[0];
            foundVacantBuilding.Description = attemptedTransportStop[1];
            foundVacantBuilding.Pos = new Vector2(Convert.ToDouble(attemptedTransportStop[2]), Convert.ToDouble(attemptedTransportStop[3]));

            return foundTransportStop;
        }
        else
        {
            return null;
        }
    }
}