using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTavs.Degl.;Integrated Security=True

namespace WebApplication5
{
    public partial class WebForm5 : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
              
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
        protected void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into KullanıcıTanım(KullanıcıID,Adı,Soyadı,Cinsiyet,DogumTarihi ,KullanıcıAdı,Sifre)" +
            " values(@KullanıcıID,@Adı,@SoyAdı,@Cinsiyet,@DogumTarihi,@KullanıcıAdı,@Sifre)", baglanti);
            komut.Parameters.AddWithValue("@KullanıcıID", TextBox10.Text);
            komut.Parameters.AddWithValue("@Adı", TextBox1.Text);
            komut.Parameters.AddWithValue("@Soyadı", TextBox2.Text);
            komut.Parameters.AddWithValue("@DogumTarihi",TextBox11.Text);
            //komut.Parameters.AddWithValue("@DogumTarihi", value: Calendar1.SelectedDate);                                                    
            komut.Parameters.AddWithValue("@KullanıcıAdı",TextBox8.Text);                        
            komut.Parameters.AddWithValue("@Sifre", TextBox9.Text);
            komut.Parameters.AddWithValue("@Cinsiyet",CheckBoxList1.SelectedValue);
            komut.ExecuteNonQuery();
            
           Label9.Text="Kullanıcı Kaydedildi.";
            baglanti.Close();                         
        }     
        /*public void ProcReq(HttpContext cont)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select image from KullanıcıTanım where KullanıcıID= @KullanıcıID");
            komut.Parameters.AddWithValue("@KullanıcıID", cont.Request["id"]);
            byte[] _bytes = (byte[])komut.ExecuteScalar();
            cont.Response.ContentType = "image/jpg";
            cont.Response.BinaryWrite(_bytes);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into KullanıcıTanım(Resim) value(@Resim)",baglanti );
            FileUpload1.SaveAs(Server.MapPath(@"Resim/")+ FileUpload1 .FileName);
            Image1.ImageUrl = "Resim/" + FileUpload1.FileName;
            komut.Parameters.AddWithValue("@Resim",Server.MapPath (@"Resim"));
            baglanti.Close();
        }*/

        
    }
}