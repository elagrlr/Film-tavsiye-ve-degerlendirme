using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class YoneticiSayfasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }              
        protected void Button1_Click(object sender, EventArgs e) //kategori ekle
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Kategoriler (KategoriID,KategoriAdı) values(@KategoriID,@KategoriAdı)", baglanti);
            komut.Parameters.AddWithValue("@KategoriID", TextBox1.Text);
            komut.Parameters.AddWithValue("@KategoriAdı", TextBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }       
        protected void Button2_Click(object sender, EventArgs e) // kategori duzenle
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Kategoriler set KategoriAdı=@KategoriAdı where KategoriID=@KategoriID",baglanti);
            komut.Parameters.AddWithValue("@KategoriID", TextBox3.Text);
            komut.Parameters.AddWithValue("@KategoriAdı", TextBox6.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        protected void Button3_Click(object sender, EventArgs e) //kategori sil
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
           
            SqlCommand komut = new SqlCommand("Delete from Kategoriler where KategoriID=@KategoriID",baglanti);
            komut.Parameters.AddWithValue("@KategoriID", TextBox7.Text);
             baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button4_Click(object sender, EventArgs e) // senarisit ekle 28 29 30
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into SenaristTanım(SenaristID,SenaristAdı,SDogumYeri,SDTarihi,SOTarihi) values(@SenaristID,@SenaristAdı,@SDogumYeri,@SDTarihi,@SOTarihi)",baglanti);
            komut.Parameters.AddWithValue("@SenaristID", TextBox9 .Text);
            komut.Parameters.AddWithValue("@SenaristAdı", TextBox10 .Text);
            komut.Parameters.AddWithValue("@SDTarihi",TextBox28 .Text );
            komut.Parameters.AddWithValue("@SDogumYeri", TextBox29.Text);
            komut.Parameters.AddWithValue("@SOTarihi", TextBox30.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button5_Click(object sender, EventArgs e) //senarist duzenle 
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update SenaristTanım set SenaristAdı=@SenaristAdı,SDogumYeri=@SDogumYeri,SDTarihi=@SDTarihi,SOTarihi=@SOTarihi where SenaristID=@SenaristID",baglanti);
            komut.Parameters.AddWithValue("@SenaristID", TextBox11.Text);
            komut.Parameters.AddWithValue("@SenaristAdı", TextBox12.Text);
            komut.Parameters.AddWithValue("@SDTarihi", TextBox14.Text);
            komut.Parameters.AddWithValue("@SDogumYeri", TextBox13.Text);
            komut.Parameters.AddWithValue("@SOTarihi", TextBox31.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        } 
        protected void Button6_Click(object sender, EventArgs e) // senarist sil 
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" Delete from SenaristTanım where SenaristID=@SenaristID",baglanti);
            komut.Parameters.AddWithValue("@SenaristID", TextBox15.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button7_Click(object sender, EventArgs e) //yonetmen ekle 17 18 25 26 27
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into YonetmenID(Yonetmen_id,YonetmenAdı,YDogumYeri,YDTarihi,YOTarihi) values (@Yonetmen_id,@YonetmenAdı,@YDogumYeri,@YDTarihi,@YOTarihi)", baglanti);
            komut.Parameters.AddWithValue("@Yonetmen_id",TextBox17.Text );
            komut.Parameters.AddWithValue("@YonetmenAdı", TextBox18.Text);
            komut.Parameters.AddWithValue("@YDogumYeri", TextBox26.Text);
            komut.Parameters.AddWithValue("@YDTarihi", TextBox25.Text);
            komut.Parameters.AddWithValue("@YOTarihi", TextBox27.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button8_Click(object sender, EventArgs e) //yonetmen duzenle
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update YonetmenID set YonetmenAdı=@YonetmenAdı,YDogumYeri=@YDogumYeri,YDTarihi=@YDTarihi,YOTarihi=@YOTarihi where Yonetmen_id=@Yonetmen_id",baglanti);
            komut.Parameters.AddWithValue("@Yonetmen_id", TextBox19.Text);
            komut.Parameters.AddWithValue("@YonetmenAdı", TextBox20.Text);
            komut.Parameters.AddWithValue("@YDogumYeri", TextBox22.Text);
            komut.Parameters.AddWithValue("@YDTarihi", TextBox21.Text);
            komut.Parameters.AddWithValue("@YOTarihi", TextBox32.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button9_Click(object sender, EventArgs e) //yonetmen sıl 
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from YonetmenID where Yonetmen_id=@Yonetmen_id", baglanti);
            komut.Parameters.AddWithValue("@Yonetmen_id", TextBox23.Text );
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button10_Click(object sender, EventArgs e)// Film ekle33 34  35 36 37 38 39
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Film(FilmID,FilmAdı,FilmSure,VizyonaGiris,KategoriID,Yonetmen_id,SenaristID,TanıtımBilgisi) values (@FilmID,@FilmAdı,@FilmSure,@VizyonaGiris,@KategoriID,@Yonetmen_id,@SenaristID,@TanıtımBilgisi)", baglanti);
            komut.Parameters.AddWithValue("@FilmID", TextBox33.Text);
            komut.Parameters.AddWithValue("@FilmAdı", TextBox34.Text);
            komut.Parameters.AddWithValue("@FilmSure", TextBox35.Text);
            komut.Parameters.AddWithValue("@VizyonaGiris", TextBox36.Text);
            komut.Parameters.AddWithValue("@KategoriID", TextBox37.Text);
            komut.Parameters.AddWithValue("@KategoriAdı ", TextBox50.Text);
            komut.Parameters.AddWithValue("@Yonetmen_id", TextBox38.Text);
            komut.Parameters.AddWithValue("@YonetmenAdı", TextBox51.Text);
            komut.Parameters.AddWithValue("@SenaristID ", TextBox39.Text);
            komut.Parameters.AddWithValue("@SenaristAdı", TextBox52.Text);
            komut.Parameters.AddWithValue("@TanıtımBilgisi", TextBox48.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button11_Click(object sender, EventArgs e) //Film duzenle 40 46
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Film set FilmAdı=@FilmAdı,FilmSure=@FilmSure,VizyonaGiris=@VizyonaGiris,KategoriID=@KategoriID,Yonetmen_id=@Yonetmen_id,SenaristID=@SenaristID,TanıtımBilgisi=@TanıtımBilgisi where FilmID=@FilmID", baglanti );
            komut.Parameters.AddWithValue("@FilmID", TextBox40.Text);  
            komut.Parameters.AddWithValue("@FilmAdı", TextBox41.Text);
            komut.Parameters.AddWithValue("@FilmSure", TextBox42.Text);
            komut.Parameters.AddWithValue("@VizyonaGiris", TextBox43.Text);
            komut.Parameters.AddWithValue("@KategoriID", TextBox44.Text);
            komut.Parameters.AddWithValue("@Yonetmen_id", TextBox45.Text);
            komut.Parameters.AddWithValue("@SenaristID ", TextBox46.Text);
            komut.Parameters.AddWithValue("@TanıtımBilgisi", TextBox48.Text);
            komut.Parameters.AddWithValue("@YonetmenAdı", TextBox54.Text);
            komut.Parameters.AddWithValue("@SenaristAdı", TextBox55.Text);
            komut.Parameters.AddWithValue("@KategoriAdı", TextBox53.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        protected void Button12_Click(object sender, EventArgs e) //Film sil 47
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Film where FilmID=@FilmID",baglanti);
            komut.Parameters.AddWithValue("@FilmID", TextBox47.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}