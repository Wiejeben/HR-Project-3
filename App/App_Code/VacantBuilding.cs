using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class VacantBuilding
{
    public string HouseNumber;
    public Street Street;

    public string Type;
    public string Status;
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

            vacantbuilding.HouseNumber = (string)row["house_number"];
            vacantbuilding.Street = Street.Get((int)row["street_id"]);
            vacantbuilding.Type = (string)row["type"];
            vacantbuilding.Status = (string)row["status"];
            vacantbuilding.Space = (int)row["space"];
            vacantbuilding.Rent = (float)row["rent"];

            results.Add(vacantbuilding);
        }

        db.CloseConn();
        return results;
    }

    public bool Insert(Db db)

    {
        db.qBind(new string[] { this.HouseNumber, this.Street.ID.ToString(), this.Type,
            this.Status, this.Space.ToString(), this.Rent.ToString() });
        int affected = db.nQuery("INSERT INTO `Vacant_Building` VALUES (@0, @1, @2, @3, @4, @5);");

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

            vacantbuilding.HouseNumber = (string)row["house_number"];
            vacantbuilding.Street = Street.Get((int)row["street_id"]);
            vacantbuilding.Type = (string)row["type"];
            vacantbuilding.Status = (string)row["status"];
            vacantbuilding.Space = (int)row["space"];
            vacantbuilding.Rent = (float)row["rent"];

            results.Add(vacantbuilding);
        }

        db.CloseConn();
        return results;
    }

    public static VacantBuilding Get(int house_number, int street_id)
    {
        // Variables to be used.
        Db db = new Db();

        // Place the row with the query results in a variable.
        db.qBind(new string[] { house_number.ToString(), street_id.ToString() });
        string[] attemptedVacantBuilding = db.row("SELECT * FROM `Vacant_Building` WHERE `house_number` = @0 AND `street_id` = @1");
        // We have a result
        if (attemptedVacantBuilding[0] != null)
        {
            VacantBuilding foundVacantBuilding = new VacantBuilding();

            // Set data onto the instance.
            foundVacantBuilding.HouseNumber = attemptedVacantBuilding[0];
            foundVacantBuilding.Street = Street.Get(Convert.ToInt32(attemptedVacantBuilding[1]));
            foundVacantBuilding.Type = attemptedVacantBuilding[2];
            foundVacantBuilding.Status = attemptedVacantBuilding[3];
            foundVacantBuilding.Space = Convert.ToInt32(attemptedVacantBuilding[4]);
            foundVacantBuilding.Rent = (float)Convert.ToDouble(attemptedVacantBuilding[5]);

            return foundVacantBuilding;
        }
        else
        {
            return null;
        }
    }
}