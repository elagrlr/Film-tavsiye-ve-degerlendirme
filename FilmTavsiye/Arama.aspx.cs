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
    public partial class Arama : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KGTU8MC;Initial Catalog=FilmTDS;Integrated Security=True");
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)//kullanıcı ara
        {
            baglanti.Open();
            String aranan = TextBox1.Text;
            String komut = "select KullanıcıAdı from KullanıcıTanım where KullanıcıAdı like '%" + aranan + "%'";
            SqlDataAdapter adaptor = new SqlDataAdapter(komut, baglanti);        
            DataTable table = new DataTable();
            adaptor.Fill(table);
            GridView4.DataSource = table; 
            GridView4.DataBind();

        }
        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e) //Kullanıcı
        {
            int K_ID = Convert.ToInt32(Request.QueryString["K_ID"]);
            int selectedRowIndex1;
            selectedRowIndex1 = GridView4.SelectedIndex;
            GridViewRow row1 = GridView4.Rows[selectedRowIndex1];
            Response.Redirect("KullaniciProfilSyf.aspx?KullanıcıAdı=" + row1.Cells[1].Text + "&K_ID="+ K_ID);    
        }

        protected void Button2_Click(object sender, EventArgs e)//Film ara
        {
            baglanti.Open();
            String aranan = TextBox2.Text;
            String komut = "Select FilmID,FilmAdı from Film where FilmAdı like '%" + aranan + "%'";
            SqlDataAdapter adaptor = new SqlDataAdapter(komut, baglanti);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            GridView5.DataSource = table;
            GridView5.DataBind();
        }
        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)//
        {
            int K_ID = Convert.ToInt32(Request.QueryString["K_ID"]);
            int selectedRowIndex1;
            selectedRowIndex1 = GridView5.SelectedIndex;
            GridViewRow row1 = GridView5.Rows[selectedRowIndex1];
            Response.Redirect("FilmDetaySayfasi.aspx?FilmID=" + row1.Cells[1].Text+"&K_ID="+Session ["K_ID"]);
        }

        protected void Button3_Click(object sender, EventArgs e)//Yonetmen ara
        {
            baglanti.Open();
            String aranan = TextBox4.Text;
            String komut = "Select YonetmenAdı from YonetmenID where YonetmenAdı like '%" + aranan + "%'";
            SqlDataAdapter adaptor = new SqlDataAdapter(komut, baglanti);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            GridView6.DataSource = table;
            GridView6.DataBind();
        }
        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)//Yonetmen
        {
            int selectedRowIndex1;
            selectedRowIndex1 = GridView6.SelectedIndex;
            GridViewRow row1 = GridView6.Rows[selectedRowIndex1];
            Response.Redirect("YonetmenDetaySyf.aspx?YonetmenAdı=" + row1.Cells[1].Text);
        }

        protected void Button4_Click(object sender, EventArgs e)//senarist ara
        {
            baglanti.Open();
            String aranan = TextBox3.Text;
            String komut = "Select SenaristAdı from SenaristTanım where SenaristAdı like '%" + aranan + "%'";
            SqlDataAdapter adaptor = new SqlDataAdapter(komut, baglanti);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            GridView7.DataSource = table;
            GridView7.DataBind();
        }
        protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)//senarist
        {
            int selectedRowIndex1;
            selectedRowIndex1 = GridView7.SelectedIndex;
            GridViewRow row1 = GridView7.Rows[selectedRowIndex1];
            Response.Redirect("SenaristDetaySayfasi.aspx?SenaristAdı=" + row1.Cells[1].Text);//arama icin yaptıgımızın aynısını yapcaz digerleri gibi enar
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)//Populer fılmler
        {            
            int selectedRowIndex;
            selectedRowIndex = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[selectedRowIndex];
            Response.Redirect("FilmDetaySayfasi.aspx?FilmID=" + row.Cells[1].Text);          
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)//populer kategorıler
        {
            int selectedRowIndex;
            selectedRowIndex = GridView2.SelectedIndex;
            GridViewRow row = GridView2.Rows[selectedRowIndex];
            Response.Redirect("FilmDetaySayfasi.aspx?FilmID=" + row.Cells[1].Text);
        }
        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)//yuksek puanlı fılmler
        {
            int selectedRowIndex;
            selectedRowIndex = GridView3.SelectedIndex;
            GridViewRow row = GridView3.Rows[selectedRowIndex];
            Response.Redirect("KategoriSyf.aspx?KategoriID="+row.Cells[1].Text); 
        }       
    }
}







