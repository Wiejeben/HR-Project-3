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

    public Street(int id, string name, Vector2 pos, bool exists)
    {
        this.ID = id;
        this.Name = name;
        this.Pos = pos;
        this.Exists = exists;
    }

    public static List<Street> All()
    {
        Db db = new Db();
        DataTable db_results = db.query("SELECT * FROM `Street`");

        List<Street> results = new List<Street>();

        foreach (DataRow row in db_results.Rows)
        {
            Street street = new Street(
                (int)row["street_id"],
                (string)row["name"],
                new Vector2((double)row["lat"], (double)row["long"]),
                true
            );

            street.Intro = (string)row["intro"];
            street.Content = (string)row["content"];

            results.Add(street);
        }

        return results;
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