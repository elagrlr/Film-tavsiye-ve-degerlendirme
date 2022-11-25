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
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
        public bool GirisYap(string KullanıcıAdı, string Sifre)
        {

            SqlCommand command = new SqlCommand("select * from YoneticiTanım where KullanıcıAdı=@KullanıcıAdı and Sifre=@Sifre", baglanti);
            command.Parameters.AddWithValue("@KullanıcıAdı", KullanıcıAdı);
            command.Parameters.AddWithValue("@Sifre", Sifre);

            SqlDataAdapter adaptor = new SqlDataAdapter(command);
            DataSet sonucDS1 = new DataSet();
            adaptor.Fill(sonucDS1);
            baglanti.Close(); 

            bool sonuc = false;
            if (sonucDS1.Tables[0].Rows.Count > 0)
            {
                sonuc = true;
                Label4.Text = "Giris basarılı";
            }
            else
            {
                Label4.Text = "Hatalı gırıs";
            }
            return sonuc;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            GirisYap(TextBox1.Text, TextBox2.Text);
            if (Label4.Text == "Giris basarılı")
            {
                Response.Redirect("YoneticiSayfasi.aspx");
            }
            baglanti.Close();
        }
    }
}