using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImportStreet
/// </summary>
public class ImportStreet : Import
{
    private string Content { get; set; }

    public ImportStreet(string content)
    {
        this.Content = content;
    }

    private bool Get(string filename)
    {
        //unfinished
        return false;
    }

    private bool Set()
    {
        //unfinished
        return false;
    }

    private List<Import> Implements()
    {
        //unfinished
        return new List<Import>();
    }
}