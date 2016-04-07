using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface Import
{
    string Contents { get; set; }
    bool Get(string filename);
    bool Set();
    List<Import> Implements();
}