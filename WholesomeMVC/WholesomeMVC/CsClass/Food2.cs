using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Food2
/// </summary>
public class Food2
{
    public string sr { get; set; }
    public string type { get; set; }
    public Desc desc { get; set; }
    public Ing ing { get; set; }
    public List<Nutrient> nutrients { get; set; }
    public List<object> footnotes { get; set; }
    public string uri { get; set; }
    public string label { get; set; }

}