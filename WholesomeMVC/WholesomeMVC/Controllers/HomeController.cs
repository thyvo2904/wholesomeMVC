using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WholesomeMVC.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            ViewBag.BannerMessage = @"
                Wholesome can quickly find out the different nutritional values of your food options.
                It's time to decide what works best for you yourself!
            ";
            ViewBag.LabelCategoryButton = "Select Category";

            Response.Redirect("~/WebForms/index.aspx");
        }

		public void NutrientCalculator()
		{
			Response.Redirect("~/WebForms/manual_input.aspx");
		}

		public void Recent()
		{
			Response.Redirect("~/WebForms/recent.aspx");
		}

		public void SavedItems()
		{
			Response.Redirect("~/WebForms/saved_items.aspx");
		}
    }
}