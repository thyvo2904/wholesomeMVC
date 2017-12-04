using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WholesomeMVC.CsClass;

/// <summary>
/// Summary description for RootObject
/// </summary>
public class RootObject
{
    public List<Food> foods { get; set; }
    public int count { get; set; }
    public int notfound { get; set; }
    public double api { get; set; }

    public string text { get; set; }
    public List<Parsed> parsed { get; set; }
    public List<Hint> hints { get; set; }
    public int page { get; set; }
    public int numPages { get; set; }
  

}