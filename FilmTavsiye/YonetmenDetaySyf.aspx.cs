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
    public partial class WebForm6: System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            String YonetmenAdı = Request.QueryString["YonetmenAdı"]; //
            SqlCommand komut = new SqlCommand("Select * from YonetmenID where YonetmenAdı=@YonetmenAdı", baglanti);

            komut.Parameters.AddWithValue("@YonetmenAdı", YonetmenAdı);  

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["YonetmenAdı"].ToString();
                TextBox2.Text = dr["YDogumYeri"].ToString();
                TextBox3.Text = dr["YDTarihi"].ToString();
                TextBox4.Text = dr["YOTarihi"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            String YonetmenAdı1 = Request.QueryString["YonetmenAdı"];

            SqlDataAdapter da;
            da = new SqlDataAdapter("Select * from Film where YonetmenAdı=@YonetmenAdı", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@YonetmenAdı", YonetmenAdı1);
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