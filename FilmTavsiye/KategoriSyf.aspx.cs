using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication5
{
    public partial class KategoriSyf : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            int KategoriID = Convert.ToInt32(Request.QueryString["KategoriID"]);
            string komut = "Select FilmID ,FilmAdı from Film where KategoriID=@KategoriID";
           
            SqlDataAdapter adaptor = new SqlDataAdapter(komut, baglanti);
            adaptor.SelectCommand.Parameters.AddWithValue("@KategoriID", KategoriID);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            GridView1.DataSource = table;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRowIndex;
            selectedRowIndex = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[selectedRowIndex];
            Response.Redirect("FilmDetaySayfasi.aspx?FilmID="+row.Cells[1].Text);
        }
    }
}