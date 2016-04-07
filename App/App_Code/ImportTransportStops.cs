using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ImportTransportStops : Import
{
    private string Content { get; set; }

        public ImportTransportStops(string content)
    {
        this.Content = content;
    }

    private bool Get(string filename)
    {
        //Unfinished
        return false;
    }

    private bool Set()
    {
        //Unfinished
        return false;
    }

    private List<Import> Implements()
    {
        //Unfinished
        return new List<Import>();
    }
}