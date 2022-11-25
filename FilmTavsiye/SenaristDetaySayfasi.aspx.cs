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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            String SenaristAdı = Request.QueryString["SenaristAdı"];
            SqlCommand komut = new SqlCommand("Select * from SenaristTanım where SenaristAdı=@SenaristAdı", baglanti);

            komut.Parameters.AddWithValue("@SenaristAdı", SenaristAdı);

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["SenaristAdı"].ToString();
                TextBox2.Text = dr["SDogumYeri"].ToString();
                TextBox3.Text = dr["SDTarihi"].ToString();
                TextBox4.Text = dr["SOTarihi"].ToString();
               
            }
            baglanti.Close();
            baglanti.Open();
            String SenaristAdı1 = Request.QueryString["SenaristAdı"];
          
            SqlDataAdapter da;
            da = new SqlDataAdapter("Select * from Film where SenaristAdı=@SenaristAdı", baglanti); 
            da.SelectCommand.Parameters.AddWithValue("@SenaristAdı", SenaristAdı1);
            DataTable table = new DataTable();
            da.Fill(table);
            GridView1.DataSource = table;
            GridView1.DataBind();//
            baglanti.Close();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRowIndex2;
            selectedRowIndex2 = GridView1.SelectedIndex;
            GridViewRow row2 = GridView1.Rows[selectedRowIndex2];
            Response.Redirect("FilmDetaySayfasi.aspx?FilmID=" + row2.Cells[1].Text);
        }
    }
}