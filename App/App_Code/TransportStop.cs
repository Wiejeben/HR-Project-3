using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TransportStop : Location, DataObject
{
    public string Name;
    public Vector2 Pos { get; }

    public TransportStop(string name, Vector2 pos)
    {
        this.Name = name;
        this.Pos = pos;
    }

    public List<DataObject> All()
    {
        //Unfinished
        return new List<DataObject>();
    }

    public List<DataObject> Find(string query)
    {
        //Unfinished
        return new List<DataObject>();
    }

    public DataObject Get(int id)
    {
        //Unfinished
        throw new NotImplementedException();
    }
}