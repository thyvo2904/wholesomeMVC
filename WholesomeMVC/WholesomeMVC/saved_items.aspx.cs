using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WholesomeMVC;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;

public partial class saved_items : System.Web.UI.Page
{
    double protein = 0;
    double fiber = 0;
    double vitaminA = 0;
    double vitaminC = 0;
    double calcium = 0;
    double iron = 0;
    double kCal = 0;
    double satFat = 0;
    double totalSugar = 0;
    double sodium = 0;

    double nR6 = 0;
    double liMT = 0;
    double NRF6 = 0;

    string ndbno1 = "0";
    string ndbno2 = "0";
    string ndbno3 = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            GridView1.DataBind();
            GridView1.Visible = true;
            GridView1.RowStyle.Height = 50;
        }
    }

    protected void btnSearch(object sender, EventArgs e)
    {


        if (txtSearch.Text != "")
        {
            String foodSearch = "";
            foodSearch = txtSearch.Text;
            FoodItem.findNdbno(foodSearch);
            Response.Redirect("~/IndexResults.aspx");
        }

        else
        {
            Response.Write("<script>alert('Please enter a value');</script>");
        }


    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = e.Row.Cells[3];
            foreach (char c in cell.Text)
            {
                if (char.IsNumber(c))
                {
                    double quantity = double.Parse(cell.Text);


                    if (quantity < 4.66)
                    {
                        cell.BackColor = Color.Red;
                    }
                    if (quantity > 4.66 && quantity <= 27.99)
                    {
                        cell.BackColor = Color.Yellow;
                    }
                    if (quantity >= 28)
                    {
                        cell.BackColor = Color.Green;
                    }
                }
            }
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.RowStyle.Height = 20;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Do nothing */
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }

    protected void btntable_Export(object sender, EventArgs e)
    {
        ExportCompareTableToExcel();
    }

    protected void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "FB_SAVEDITEMS" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        GridView1.GridLines = GridLines.Both;
        GridView1.HeaderStyle.Font.Bold = true;
        GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    protected void ExportCompareTableToExcel()
    {
        Response.ContentType = "application/x-msexcel";
        string FileName = "FB_COMPARISON" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "attachment;filename = " + FileName);
        Response.ContentEncoding = Encoding.UTF8;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        comparetable.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

    protected void Compare(object sender, EventArgs e)
    {
        if (txtfood1.Value != String.Empty && txtfood2.Value != String.Empty && txtfood3.Value != String.Empty)
        {
            food1(ndbno1);
            food2(ndbno2);
            food3(ndbno3);
            comparetable.Visible = true;
        }
        else if (txtfood1.Value != String.Empty && txtfood2.Value != String.Empty)
        {
            food1(ndbno1);
            food2(ndbno2);
            comparetable.Visible = true;
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Please select at least 2 food items to compare" + "');", true);



    }
    public void food1(string ndbno)
    {
        returnNdbno(txtfood1.Value.Substring(0, txtfood1.Value.IndexOf(" "))); lblNDScore1.Text = NRF6.ToString();

        if (kCal.ToString().Equals(0))
        {
            lblNDScore1.Text = "Uncategorized";
        }
        else
            lblNDScore1.Text = NRF6.ToString();
        lblCal1.Text = kCal.ToString();
        lblFat1.Text = satFat.ToString();
        lblSodium1.Text = sodium.ToString();
        lblFiber1.Text = fiber.ToString();
        lblSugar1.Text = totalSugar.ToString();
        lblProtein1.Text = protein.ToString();
        lblVitA1.Text = vitaminA.ToString();
        lblVitC1.Text = vitaminC.ToString();
        lblIron1.Text = iron.ToString();
        lblCalcium1.Text = calcium.ToString();


        if (NRF6 < 4.66)
        {
            lblNDScore1.BackColor = Color.Red;
        }
        if (NRF6 > 4.66 && NRF6 <= 27.99)
        {
            lblNDScore1.BackColor = Color.Yellow;
        }
        if (NRF6 >= 28)
        {
            lblNDScore1.BackColor = Color.Green;
        }
    }

    public void food2(string ndbno)
    {
        returnNdbno(txtfood2.Value.Substring(0, txtfood2.Value.IndexOf(" ")));
        if (kCal.ToString().Equals(0))
        {
            lblNDScore2.Text = "Uncategorized";
        }
        else
            lblNDScore2.Text = NRF6.ToString();
        lblCal2.Text = kCal.ToString();
        lblFat2.Text = satFat.ToString();
        lblSodium2.Text = sodium.ToString();
        lblFiber2.Text = fiber.ToString();
        lblSugar2.Text = totalSugar.ToString();
        lblProtein2.Text = protein.ToString();
        lblVitA2.Text = vitaminA.ToString();
        lblVitC2.Text = vitaminC.ToString();
        lblIron2.Text = iron.ToString();
        lblCalcium2.Text = calcium.ToString();
        if (NRF6 < 4.66)
        {
            lblNDScore2.BackColor = Color.Red;
        }
        if (NRF6 > 4.66 && NRF6 <= 27.99)
        {
            lblNDScore2.BackColor = Color.Yellow;
        }
        if (NRF6 >= 28)
        {
            lblNDScore2.BackColor = Color.Green;
        }
    }
    public void food3(string ndbno)
    {
        returnNdbno(txtfood3.Value.Substring(0, txtfood3.Value.IndexOf(" ")));
        if (kCal.ToString().Equals(0))
        {
            lblNDScore3.Text = "Uncategorized";
        }
        else
            lblNDScore3.Text = NRF6.ToString();
        lblCal3.Text = kCal.ToString();
        lblFat3.Text = satFat.ToString();
        lblSodium3.Text = sodium.ToString();
        lblFiber3.Text = fiber.ToString();
        lblSugar3.Text = totalSugar.ToString();
        lblProtein3.Text = protein.ToString();
        lblVitA3.Text = vitaminA.ToString();
        lblVitC3.Text = vitaminC.ToString();
        lblIron3.Text = iron.ToString();
        lblCalcium3.Text = calcium.ToString();
        if (NRF6 < 4.66)
        {
            lblNDScore3.BackColor = Color.Red;
        }
        if (NRF6 > 4.66 && NRF6 <= 27.99)
        {
            lblNDScore3.BackColor = Color.Yellow;
        }
        if (NRF6 >= 28)
        {
            lblNDScore3.BackColor = Color.Green;
        }
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  int counter = 0;
        if ((String.IsNullOrEmpty(txtfood1.Value) == true) || (String.IsNullOrWhiteSpace(txtfood1.Value) == true))
        {
          //  ndbno1 = 
            txtfood1.Value = GridView1.SelectedRow.Cells[1].Text.Trim() + " "+ GridView1.SelectedRow.Cells[2].Text.Trim();
        }
        else if ((String.IsNullOrEmpty(txtfood2.Value) == true) || (String.IsNullOrWhiteSpace(txtfood2.Value) == true))
        {
         //   ndbno2 = GridView1.SelectedRow.Cells[1].Text.Trim();
            txtfood2.Value = GridView1.SelectedRow.Cells[1].Text.Trim() + " " + GridView1.SelectedRow.Cells[2].Text.Trim();
        }
        else if ((String.IsNullOrEmpty(txtfood3.Value) == true) || (String.IsNullOrWhiteSpace(txtfood3.Value) == true))
        {
           // ndbno3 = GridView1.SelectedRow.Cells[1].Text.Trim();
            txtfood3.Value = GridView1.SelectedRow.Cells[1].Text.Trim() + " " + GridView1.SelectedRow.Cells[2].Text.Trim();
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Only can combine 3 food" + "');", true);


    }
    //this should be named something different 
    public void returnNdbno(string ndbNo)
    {

        String urlPartOne = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
        String urlPartTwo = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


        String url = urlPartOne + ndbNo + urlPartTwo;

        var json = new WebClient().DownloadString(url);

        var result = JsonConvert.DeserializeObject<RootObject>(json);
        
        foreach (Nutrient item in result.foods[0].food.nutrients)
        {
            // Good nutrients
            if (Int32.Parse(item.nutrient_id) == 203)
            {
                protein = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 291)
            {
                fiber = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 318)
            {
                vitaminA = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 401)
            {
                vitaminC = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 301)
            {
                calcium = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 303)
            {
                iron = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 208)
            {
                kCal = Double.Parse(item.value);
            }
            

            // Bad nutrients
            if (Int32.Parse(item.nutrient_id) == 606)
            {
                satFat = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 269)
            {
                totalSugar = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 307)
            {
                sodium = Double.Parse(item.value);
            }
        }



        nR6 = (protein / 50) + (fiber / 25) + (vitaminA / 5000) + (vitaminC / 60) + (calcium / 1000) + (iron / 18);

        liMT = (satFat / 20) + (totalSugar / 125) + (sodium / 2400);

        double good = ((nR6 * 100) / kCal) * 100;
        double bad = ((liMT * 100) / kCal) * 100;

        NRF6 = good - bad;

        NRF6 = Math.Round(NRF6, 5);

        //   return NRF6;
    }
    
}
