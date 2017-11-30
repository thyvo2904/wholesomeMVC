using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// It would be root object but I already have another class for json retrieval
// named root object so the closes thing I got is root thing.
namespace Wholesome
{
    public class RootThing
    {
        public List<FarmersMarketResult> results { get; set; }
    }
}