using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for List
/// </summary>
public class List
{
    public string q { get; set; }
    public string sr { get; set; }
    public string ds { get; set; }
    public int start { get; set; }
    public int end { get; set; }
    public int total { get; set; }
    public string group { get; set; }
    public string sort { get; set; }
    public IList<Item> item { get; set; }
}