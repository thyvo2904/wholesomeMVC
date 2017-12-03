using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Item
/// </summary>
public class Item
{
    public int offset { get; set; }
    public string group { get; set; }
    public string name { get; set; }
    public string ndbno { get; set; }
    public string ds { get; set; }

    //public static List<string> names = new List<string>();
    public static ArrayList ndbnoList = new ArrayList();
}