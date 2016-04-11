using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

public class Street : Location
{
    public int ID;
    public string Name, Intro, Content;
    public Vector2 Pos { get; set; }
    public bool Exists;

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
            street.Exists = (bool)row["exists"];

            results.Add(street);
        }

        return results;
    }

    public bool Insert()
    {
        Db db = new Db();

        db.qBind(new string[] { this.ID.ToString(), this.Name, this.Content, this.Intro, this.Pos.Y().ToString(), this.Pos.X().ToString(), Convert.ToInt32(this.Exists).ToString() });
        int affected = db.nQuery("INSERT INTO `Street` VALUES (@0, @1, @2, @3, @4, @5, @6, null);");

        db.CloseConn();

        return (affected >= 1);
    }

    public List<DataObject> Find(string query)
    {
        return new List<DataObject>();
    }

    public DataObject Get(int id)
    {
        throw new NotImplementedException();
    }
}