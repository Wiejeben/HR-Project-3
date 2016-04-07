using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ImportTransportStops : Import
{
    public string Content { get; set; }

        public ImportTransportStops(string content)
    {
        this.Content = content;
    }

    public bool Get(string filename)
    {
        //Unfinished
        return false;
    }

    public bool Set()
    {
        //Unfinished
        return false;
    }

    public List<Import> Implements()
    {
        //Unfinished
        return new List<Import>();
    }
}