using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;


public class Nutrient
{
    public string nutrient_id { get; set; }
    public string name { get; set; }
    public string derivation { get; set; }
    public string group { get; set; }
    public string unit { get; set; }
    public string value { get; set; }
    public List<Measure> measures { get; set; }

}