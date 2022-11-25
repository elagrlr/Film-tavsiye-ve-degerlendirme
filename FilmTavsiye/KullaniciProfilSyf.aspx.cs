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
    public partial class KullaniciProfilSyf : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            String KullanıcıAdı = Request.QueryString["KullanıcıAdı"];
            SqlCommand komut = new SqlCommand("Select * from KullanıcıTanım where KullanıcıAdı=@KullanıcıAdı", baglanti);

            komut.Parameters.AddWithValue("@KullanıcıAdı", KullanıcıAdı);  

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();//
            if (dr.Read())
            {
                TextBox1.Text = dr["KullanıcıAdı"].ToString();
                TextBox2.Text = dr["Adı"].ToString();
                TextBox3.Text = dr["Soyadı"].ToString();

            } 
            baglanti.Close();
            int K_ID = Convert.ToInt32(Request.QueryString["K_ID"]);
            SqlDataAdapter da;
            da = new SqlDataAdapter("Select * from Filmİzlenme where KullanıcıID=@KullanıcıID ", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@KullanıcıID", K_ID);
            DataTable table = new DataTable();
            da.Fill(table);
            GridView1.DataSource = table;
            GridView1.DataBind();//
            baglanti.Close();

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            int K_ID = Convert.ToInt32(Request.QueryString["K_ID"]);// arama bölümünden kullanıcıyı aradı,Profile girdi,Arkadas olarak ekledi.
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Insert into KullanıcıArkadas (KullanıcıID,ArkadasID,ArkadaslıkTarihi) values(@KullanıcıID,ArkadasID,@ArkadaslıkTarihi)", baglanti);
            string ArkadasAdı = Request.QueryString["KullanıcıAdı"];
            komut1.Parameters.AddWithValue("@KullanıcıID", K_ID);
            
            int AID= Convert.ToInt32(Request.QueryString["AID"]);
            SqlCommand komut = new SqlCommand("Select * from KullanıcıTanım where KullanıcıAdı=@KullanıcıAdı", baglanti);
            komut.Parameters.AddWithValue("@KullanıcıAdı", ArkadasAdı);
            baglanti.Close();

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {           
                 AID = Convert.ToInt32(dr["KullanıcıID"]);
            }
            baglanti.Close();

            baglanti.Open();
            komut1.Parameters.AddWithValue("@ArkadasID", AID); 
            komut1.Parameters.AddWithValue("@ArkadaslıkTarihi", DateTime.Now);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            SqlCommand komut2 = new SqlCommand("select FilmAdı from Filmİzlenme where KullanıcıID=@KullanıcıID", baglanti);
            komut2.Parameters.AddWithValue("@KullanıcıID", AID);

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)//izledigi filmler
        {
            int selectedRowIndex;
            selectedRowIndex = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[selectedRowIndex];
            Response.Redirect("FilmDetaySayfasi.aspx?FilmID=" + row.Cells[1].Text);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}