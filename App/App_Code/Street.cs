using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Street : Location, DataObject
{
    public int ID;
    public string Name, Intro, Content;
    public Vector2 Pos { get; set; }
    public bool Exists;

    public Street(int id, string name, string intro, string content, Vector2 pos, bool exists)
    {
        this.ID = id;
        this.Name = name;
        this.Intro = intro;
        this.Content = content;
        this.Pos = pos;
        this.Exists = exists;
    }

    public List<DataObject> All()
    {
        return new List<DataObject>();
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