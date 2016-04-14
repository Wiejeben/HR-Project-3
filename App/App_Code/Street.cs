using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class Street : Location
{
    public int ID;
    public string Name, Intro, Content;
    public Vector2 Pos { get; set; }
    public bool Exists = false;
    public string Timespan;
    public List<Theft> Robberies;

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

        db.CloseConn();
        return results;
    }

    public bool Insert(Db db)
    {
        db.qBind(new string[] { this.ID.ToString(), this.Name, this.Intro, this.Content, this.Pos.Y.ToString(), this.Pos.X.ToString(), Convert.ToInt32(this.Exists).ToString(), this.Timespan });
        int affected = db.nQuery("INSERT INTO `Street` VALUES (@0, @1, @2, @3, @4, @5, @6, @7);");

        return (affected >= 1);
    }

    public static List<Street> Find(string query, int limit = 40)
    {
        Db db = new Db();

        db.bind("query", "%" + query + "%");
        DataTable results = db.query("SELECT * FROM `Street` WHERE `name` LIKE @query LIMIT " + limit);

        db.CloseConn();

        return DataTableToObjects(results);
    }

    public static List<Street> Where(string field, string @operator, string value)
    {
        Db db = new Db();

        db.qBind(new string[] { value });
        DataTable results = db.query("SELECT * FROM `Street` WHERE `" + field + "` " + @operator + " @0");

        db.CloseConn();

        return DataTableToObjects(results);
    }

    private static List<Street> DataTableToObjects(DataTable data)
    {
        List<Street> results = new List<Street>();

        foreach (DataRow row in data.Rows)
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

    public static Street Get(int id)
    {
        // Variables to be used.
        Db db = new Db();
        List<Theft> Robberies = new List<Theft>();

        // Bind the field & value.
        db.bind("street_id", id.ToString());
        // Place the row with the query results in a variable.
        string[] result = db.row("SELECT * FROM `Street` WHERE `street_id` = @street_id");

        // We have a result
        if (result[0] != null)
        {
            Street street = new Street();

            // Set data onto the instance.
            street.ID = Int32.Parse(result[0]);
            street.Name = result[1];
            street.Intro = result[2];
            street.Content = result[3];
            street.Pos = new Vector2(Convert.ToDouble(result[4]), Convert.ToDouble(result[5]));
            street.Exists = Convert.ToBoolean(result[6]);
            street.Timespan = result[7];

            Robberies = Theft.Get(id);
            street.Robberies = Robberies;
            
            return street;
        }

        return null;
    }
}