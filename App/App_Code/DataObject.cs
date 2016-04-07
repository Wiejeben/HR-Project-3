using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataObject
/// </summary>
interface DataObject
{
    List<DataObject> All();
    List<DataObject> Find(string query);
    DataObject Get(int id);
}
