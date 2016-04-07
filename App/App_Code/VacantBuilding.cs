using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class VacantBuilding : Location, DataObject
{
    public Vector2 Pos { get; }
    string Type;
    string Status;
    string Owner;
    int Space;
    float Rent;

    public VacantBuilding(string type, string status, string owner, int space, float rent)
    {
        this.Type = type;
        this.Status = status;
        this.Owner = owner;
        this.Space = space;
        this.Rent = rent;
    }

    public List<DataObject> All()
    {
        //Unfinished
        throw new NotImplementedException();
    }

    public List<DataObject> Find(string query)
    {
        //Unfinished
        throw new NotImplementedException();
    }

    public DataObject Get(int id)
    {
        //Unfinished
        throw new NotImplementedException();
    }
}