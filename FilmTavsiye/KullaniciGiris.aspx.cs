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

    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e) { }

        public bool GirisYap(string KullanıcıAdı, string Sifre)
        {
            SqlCommand komut = new SqlCommand("select * from KullanıcıTanım where KullanıcıAdı=@KullanıcıAdı and Sifre=@Sifre", baglanti);
            komut.Parameters.AddWithValue("@KullanıcıAdı", KullanıcıAdı);
            komut.Parameters.AddWithValue("@Sifre", Sifre);          
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
            {
                sonuc = true;
                Label4.Text = "Giris basarılı" + "";
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
                SqlCommand kmt = new SqlCommand("select * from KullanıcıTanım where KullanıcıAdı=@KullanıcıAdı", baglanti);               
                kmt.Parameters.AddWithValue("@KullanıcıAdı", TextBox1.Text);
                baglanti.Open();
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    Session["K_ID"] = dr["KullanıcıID"].ToString();
                    Response.Redirect("Arama.aspx?K_ID="+Session["K_ID"].ToString ());
                    
                }
                baglanti.Close();
            }

        }
    }
}