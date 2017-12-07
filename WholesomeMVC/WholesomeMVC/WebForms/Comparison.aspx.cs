using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace WholesomeMVC.WebForms
{
    public partial class Comparison : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				// set page variables
				String strTitle = "Comparison Tool";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				createTable();
            }
        }

        //generate comaprsion table columns
        protected int GenerateCols()
        {
            string stmt = "SELECT COUNT(*) FROM dbo.Comparison_Item";
            int count = 0;
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                {
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();
                }
            }
            return count;
        }

		//generate dataset from Comaprison_Item Table
		private DataTable GetData()
		{
			string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			using (SqlConnection con = new SqlConnection(constr))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT ndb_no,FoodName,nrf6,KCal,SaturatedFat,Sodium,fiber,TotalSugar,protein,VitaminA,VitaminC,Iron,Calcium FROM dbo.Comparison_Item"))
				{
					using (SqlDataAdapter sda = new SqlDataAdapter())
					{
						cmd.Connection = con;
						sda.SelectCommand = cmd;
						using (DataTable dt = new DataTable())
						{
							sda.Fill(dt);
							return dt;
						}
					}
				}
			}
		}

		protected void createTable()
        {
            //HtmlTable table1 = new HtmlTable();
            Table table1 = new Table();

            // Set the table's formatting-related properties.
			table1.CssClass = "table table-striped table-hover";
			table1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
       

            // Start adding content to the table.
            TableRow row;
            TableCell cell;
            for (int i = 0; i <= 13; i++) {
				// Create a new row and set its background color.
				if (i == 0) {
					row = new TableHeaderRow();
					row.TableSection = TableRowSection.TableHeader;
				} else {
					row = new TableRow();
				}

                for (int j = 0; j <= GenerateCols(); j++) {
                    // Create a cell and set its text.
					cell = (i == 0 || j == 0) ? new TableHeaderCell() : new TableCell();
                  
                    // Add the cell to the current row.
                    row.Cells.Add(cell);
                }

                // Add the row to the table.
                table1.Rows.Add(row);
            }
            // set table header
            table1.Rows[0].Cells[0].Text = "FoodNumber";
            table1.Rows[1].Cells[0].Text = "NDBNO";
            table1.Rows[2].Cells[0].Text = "Food Name";
            table1.Rows[3].Cells[0].Text = "ND_Score";
            table1.Rows[4].Cells[0].Text = "Calories";
            table1.Rows[5].Cells[0].Text = "Saturated Fat (g)";
            table1.Rows[6].Cells[0].Text = "Sodium (mg)";
            table1.Rows[7].Cells[0].Text = "Dietary Fiber (g)";
            table1.Rows[8].Cells[0].Text = "Total Sugars (g)";
            table1.Rows[9].Cells[0].Text = "Protein (g)";
            table1.Rows[10].Cells[0].Text = "Vitamin A (IU)";
            table1.Rows[11].Cells[0].Text = "Vitamin C (mg)";
            table1.Rows[12].Cells[0].Text = "Iron (mg)";
            table1.Rows[13].Cells[0].Text = "Calcium (mg)";
            
            // header of # of food compare
            int colno = GenerateCols();
            for (int k = colno; k > 0; k--)
            {
                table1.Rows[0].Cells[k].Text = "#" + k.ToString();
            }

            // add dataset from db table to html table
            DataTable dt = this.GetData();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    // Loop through columns
                    table1.Rows[j + 1].Cells[i + 1].Text = dt.Rows[i][j].ToString();
                }
            }

            // Add the table to the page.
            compare.Controls.Add(table1);
        }

        protected HtmlTable exportTable()
        {
            HtmlTable table1 = new HtmlTable();

			// Set the table's formatting-related properties.
			table1.Border = 1;
			table1.CellPadding = 3;
			table1.CellSpacing = 3;
			table1.BorderColor = "transparent";


            // Start adding content to the table.
            HtmlTableRow row;
            HtmlTableCell cell;
            for (int i = 1; i <= 14; i++)
            {
                // Create a new row and set its background color.
                row = new HtmlTableRow();
				row.BgColor = (i % 2 == 0 ? "#f2f2f2" : "white");
				for (int j = 1; j <= (GenerateCols() + 1); j++)
                {
                    // Create a cell and set its text.
                    cell = new HtmlTableCell();

                    // Add the cell to the current row.
                    row.Cells.Add(cell);
                }

                // Add the row to the table.
                table1.Rows.Add(row);
            }
            // set table header
            table1.Rows[0].Cells[0].InnerText = "FoodNumber";
            table1.Rows[1].Cells[0].InnerText = "NDBNO";
            table1.Rows[2].Cells[0].InnerText = "Food Name";
            table1.Rows[3].Cells[0].InnerText = "ND_Score";
            table1.Rows[4].Cells[0].InnerText = "Calories";
            table1.Rows[5].Cells[0].InnerText = "Saturated Fat|g";
            table1.Rows[6].Cells[0].InnerText = "Sodium|mg";
            table1.Rows[7].Cells[0].InnerText = "Dietary Fiber|g";
            table1.Rows[8].Cells[0].InnerText = "Total Sugars|g";
            table1.Rows[9].Cells[0].InnerText = "Protein|g";
            table1.Rows[10].Cells[0].InnerText = "Vitamin A|IU";
            table1.Rows[11].Cells[0].InnerText = "Vitamin C|mg";
            table1.Rows[12].Cells[0].InnerText = "Iron|mg";
            table1.Rows[13].Cells[0].InnerText = "Calcium|mg";

            // header of # of food compare
            int colno = GenerateCols();
            for (int k = colno; k > 0; k--)
            {
                table1.Rows[0].Cells[k].InnerText = "#" + k.ToString();
            }

            // add dataset from db table to html table
            DataTable dt = this.GetData();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    // Loop through columns
                    table1.Rows[j + 1].Cells[i + 1].InnerText = dt.Rows[i][j].ToString();
                }
            }

            // Add the table to the page.
            return table1; 

        }

        protected void ExportCompareTableToExcel()
        {
            Response.ContentType = "application/x-msexcel";
            string FileName = "FB_COMPARISON" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "attachment;filename = " + FileName);
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            exportTable().RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }

        protected void btntable_Export(object sender, EventArgs e)
        {
            ExportCompareTableToExcel();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Do nothing */
        }



    }
}