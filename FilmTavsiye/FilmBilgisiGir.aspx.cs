using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class FilmBilgisiGir : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            int FilmID = Convert.ToInt32(Request.QueryString["FilmID"]);
            SqlCommand komut = new SqlCommand("Select * from Film where FilmID=@FilmID", baglanti);

            komut.Parameters.AddWithValue("@FilmID", FilmID);

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();//
            if (dr.Read())
            {
                TextBox4.Text = dr["FilmAdı"].ToString();

            }
            baglanti.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)//inceleme
        {
            int FilmID = Convert.ToInt32(Request.QueryString["FilmID"]);
            int K_ID = Convert.ToInt32(Request.QueryString["K_ID"]);
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Insert into Filmİnceleme (FilmID,KullanıcıID,İnceleme) values(@FilmID,@KullanıcıID,@İnceleme)", baglanti);

            komut2.Parameters.AddWithValue("@FilmID", FilmID);
            komut2.Parameters.AddWithValue("@İnceleme", TextBox1.Text);
            komut2.Parameters.AddWithValue("@KullanıcıID", Session["K_ID"].ToString());
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int FilmID = Convert.ToInt32(Request.QueryString["FilmID"]);
            int K_ID = Convert.ToInt32(Request.QueryString["K_ID"]);
            SqlCommand komut1 = new SqlCommand("Select * from Film where FilmID=@FilmID", baglanti);

            komut1.Parameters.AddWithValue("@FilmID", FilmID);

            baglanti.Open();
            SqlDataReader dr = komut1.ExecuteReader();//
            if (dr.Read())
            {
                TextBox4.Text = dr["FilmAdı"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into FilmAlıntıSoz (FilmID,KullanıcıID,Cümle,FilmAdı) values(@FilmID,@KullanıcıID,@Cümle,@FilmAdı)", baglanti);

            komut.Parameters.AddWithValue("@FilmID", FilmID);
            komut.Parameters.AddWithValue("@Cümle", TextBox2.Text);
            komut.Parameters.AddWithValue("@KullanıcıID", Session["K_ID"].ToString());
            komut.Parameters.AddWithValue("@FilmAdı", TextBox4.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void Button3_Click(object sender, EventArgs e)//inceleme 1 alıntı 2 puan3
        {
            //Tanıştırayım; rafadan, lop bu da cıvık. sid den baska kımden alıntı yapabılırım o fılmde acaba  essek ya :D sey diccem bak simdi buraya sey yapmamız lazım if (checkbox degeri varsa tik koyduysa) (veritabanı sorgusu izlenme sayısı olan sonra artırmaya calscaz  diye düsünyürom wpden bısy attım baksana bı bn hala ikna olmadım bu ızlenme seysıne  neden ya bız bunu nası arttırıcaz onu anlamıyoum film IDsi atıoyurm 2 olanın izlnemesi lazım bunu sql sorgusundan yapcaz sonra ??eee
         


            int FilmID = Convert.ToInt32(Request.QueryString["FilmID"]);
            int K_ID = Convert.ToInt32(Request.QueryString["K_ID"]);
          

           
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into FilmPuan(FilmID,KullanıcıID,FilmAdı,Puan) values (@FilmID,@KullanıcıID,@FilmAdı,@Puan)", baglanti );

            komut3.Parameters.AddWithValue("@FilmID", FilmID);
            komut3.Parameters.AddWithValue("@KullanıcıID", Session["K_ID"].ToString ());
            komut3.Parameters.AddWithValue("@FilmAdı", TextBox4.Text);
            komut3.Parameters.AddWithValue("@Puan", TextBox3.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
                        //checkbox 
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from Filmİzlenme where FilmID=@FilmID", baglanti);
            komut4.Parameters.AddWithValue("FilmID", FilmID);
            
            SqlDataReader dr2 = komut4.ExecuteReader();//
           
            int İzlenme;
            if (dr2.Read())
            {
                
                İzlenme = Convert.ToInt32(dr2["İzlenmeSayısı"]);
                baglanti.Close();
                if (CheckBox1.Checked == true)
                {
                    baglanti.Open();
                    SqlCommand komut5 = new SqlCommand("Update Filmİzlenme set İzlenmeSayısı=@İzlenmeSayısı+1 where FilmID=@FilmID", baglanti);
                    komut5.Parameters.AddWithValue("@FilmID", FilmID);
                    komut5.Parameters.AddWithValue("@İzlenmeSayısı", İzlenme);
                    komut5.ExecuteNonQuery();
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komut6 = new SqlCommand("insert into Filmİzlenme (FilmID,KullanıcıID,FilmAdı,İzlenmeSayısı)values(@FilmID,@KullanıcıID,@FilmAdı,@İzlenmeSayısı)", baglanti);
                    komut6.Parameters.AddWithValue("@FilmID", FilmID);
                    komut6.Parameters.AddWithValue("@FilmAdı", TextBox4.Text);
                    komut6.Parameters.AddWithValue("@KullanıcıID", K_ID);
                    komut6.Parameters.AddWithValue("@İzlenmeSayısı", İzlenme);
                    komut6.ExecuteNonQuery();
                    Label4.Text = "Eklendi";
                    baglanti.Close();


                }
            }
            baglanti.Close();
        }        
      

    }
}